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
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        return Image.FromStream(stream);
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
