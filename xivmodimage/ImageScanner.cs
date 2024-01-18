using GScraper.Google;

namespace xivmodimage
{
    public class ImageScanner
    {
        private List<ImageInfo> images;
        private Action<string> logMessageCallback;

        public ImageScanner(Action<string> logMessageCallback)
        {
            this.logMessageCallback = logMessageCallback;
        }

        public async Task<List<ImageInfo>> ScanImagesForModAsync(ModInfo modInfo)
        {
            images = new List<ImageInfo>();

            try
            {
                using var scraper = new GoogleScraper();

                // Step 1: Search for the exact name of the mod in quotes
                string exactNameSearch = $"\"{modInfo.Name}\"";
                var exactNameResults = await scraper.GetImagesAsync(exactNameSearch);

                // Add the first 5 results with images larger than 100x100
                var filteredExactNameResults = exactNameResults
                    .Where(image => image.Width >= 100 && image.Height >= 100)
                    .Take(5)
                    .Select(image => new ImageInfo { ImageUrl = image.Url, PageTitle = image.Title ?? "", PageUrl = image.SourceUrl ?? "" })
                    .ToList();

                // Step 2: Search for the name of the mod along with the author and "ffxiv mod"
                string authorAndModSearch = $"{modInfo.Name} {modInfo.Author} ffxiv mod";
                var authorAndModResults = await scraper.GetImagesAsync(authorAndModSearch);

                // Add the first 10 results with images larger than 100x100
                var filteredAuthorAndModResults = authorAndModResults
                    .Where(image => image.Width >= 100 && image.Height >= 100)
                    .Take(10)
                    .Select(image => new ImageInfo { ImageUrl = image.Url, PageTitle = image.Title ?? "", PageUrl = image.SourceUrl ?? "" })
                    .ToList();

                // Combine the results from both searches
                images =  filteredAuthorAndModResults.Concat(filteredExactNameResults).ToList();

            }
            catch (Exception e)
            {
                logMessageCallback($"Error searching images for {modInfo.Name}: {e.Message}");
            }

            return images;
        }
    }
}
