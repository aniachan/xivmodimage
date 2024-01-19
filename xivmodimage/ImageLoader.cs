namespace xivmodimage
{
    public class ImageLoader
    {
        private Action<string> logMessageCallback;

        public ImageLoader(Action<string> logMessageCallback)
        {
            this.logMessageCallback = logMessageCallback;
        }

        public async Task<Image> LoadImageAsync(string imageUrl)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(imageUrl);

                if (response.IsSuccessStatusCode)
                {
                    var contentType = response.Content.Headers.ContentType?.MediaType;

                    // Check if the content type is not GIF
                    if (contentType != null && !contentType.Equals("image/gif", StringComparison.OrdinalIgnoreCase))
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            return Image.FromStream(stream);
                        }
                    }
                    else
                    {
                        logMessageCallback("Skipping GIF image loading to prevent crashes.");
                        return null;
                    }
                }
                else
                {
                    logMessageCallback($"Failed to download image. Status code: {response.StatusCode}");
                    return null;
                }
            }
        }
    }
}
