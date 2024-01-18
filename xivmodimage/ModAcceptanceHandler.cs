using System.Net;

namespace xivmodimage
{
    public class ModAcceptanceHandler
    {
        private Action<string> logMessageCallback;

        public ModAcceptanceHandler(Action<string> logMessageCallback)
        {
            this.logMessageCallback = logMessageCallback;
        }

        public void AcceptModImage(ModInfo currentMod, ImageInfo selectedImage)
        {
            string imageUrl = selectedImage.ImageUrl;
            string modImagesDirectory = Path.Combine(currentMod.ModPath, "images");

            try
            {
                if (!Directory.Exists(modImagesDirectory))
                {
                    Directory.CreateDirectory(modImagesDirectory);
                }

                string imagePath = Path.Combine(modImagesDirectory, $"xmi-image_{DateTime.Now:yyyyMMddHHmmss}.jpg");
                using (var client = new WebClient())
                {
                    client.DownloadFile(new Uri(imageUrl), imagePath);
                }

                logMessageCallback($"Image saved successfully: {imagePath}");
            }
            catch (Exception ex)
            {
                logMessageCallback($"Error saving image: {ex.Message}");
            }
        }

        public void AcceptCustomImage(ModInfo currentMod, string selectedImagePath)
        {
            string modImagesDirectory = Path.Combine(currentMod.ModPath, "images");

            try
            {
                if (!Directory.Exists(modImagesDirectory))
                {
                    Directory.CreateDirectory(modImagesDirectory);
                }

                string imageName = Path.GetFileName(selectedImagePath);
                string destinationPath = Path.Combine(modImagesDirectory, imageName);
                File.Copy(selectedImagePath, destinationPath, true);

                logMessageCallback($"Custom image saved successfully: {destinationPath}");
            }
            catch (Exception ex)
            {
                logMessageCallback($"Error saving custom image: {ex.Message}");
            }
        }
    }
}
