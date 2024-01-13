using System;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using GScraper;
using GScraper.Google;

namespace xivmodimage
{
    public partial class Form1 : Form
    {
        // Variables
        private string penumbraDirectory;
        private List<ModInfo> modInfoList = new List<ModInfo>();
        private int currentModIndex = 0;
        private List<string> imageUrls;
        private int currentImageIndex;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                penumbraDirectory = folderBrowser.SelectedPath;
                textModDir.Text = penumbraDirectory;
            }
        }

        private void DisplayCurrentModInfo()
        {
            if (currentModIndex < modInfoList.Count)
            {
                ModInfo currentMod = modInfoList[currentModIndex];
                LogMessage($"Processing Mod {currentModIndex + 1} of {modInfoList.Count}: {currentMod.Name} by {currentMod.Author}");
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            // Disable the scan button during the entire process
            btnScan.Enabled = false;

            // Perform scanning to create modInfoList
            ScanDirectories(penumbraDirectory);

            if (modInfoList.Count > 0)
            {
                // Display information for the first mod
                DisplayCurrentModInfo();

                // Trigger scanning for images for the first mod
                ScanImagesForCurrentMod(modInfoList[0]);
            }
            else
            {
                LogMessage("No mods found in the specified directory. Scanning complete.");

                // Re-enable the scan button since there are no mods to process
                btnScan.Enabled = true;
            }
        }

        private void ScanDirectories(string rootDirectory)
        {
            string[] subDirectories = Directory.GetDirectories(rootDirectory);

            foreach (string subDirectory in subDirectories)
            {
                string imagesDirectory = Path.Combine(subDirectory, "images");

                if (!Directory.Exists(imagesDirectory))
                {
                    ProcessMetaJson(subDirectory);
                }
            }
        }

        private void ProcessMetaJson(string modDirectory)
        {
            string metaJsonPath = Path.Combine(modDirectory, "meta.json");

            if (File.Exists(metaJsonPath))
            {
                try
                {
                    // Read the contents of the meta.json file
                    string jsonContent = File.ReadAllText(metaJsonPath);

                    // Deserialize the JSON into a ModInfo object
                    ModInfo modInfo = JsonSerializer.Deserialize<ModInfo>(jsonContent);

                    // Set the ModPath property
                    modInfo.ModPath = modDirectory;

                    // Add the ModInfo object to the list
                    modInfoList.Add(modInfo);

                    // Log information (optional)
                    LogMessage($"Processed {modInfo.Name} in {modDirectory}");
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., invalid JSON format)
                    LogMessage($"Error processing meta.json in {modDirectory}: {ex.Message}");
                }
            }
        }

        private async void ScanImagesForCurrentMod(ModInfo currentMod)
        {
            try
            {
                using var scraper = new GoogleScraper();
                imageUrls = (await scraper.GetImagesAsync($"{currentMod.Name} {currentMod.Author}")).Select(image => image.Url).ToList();

                if (imageUrls.Count > 0)
                {
                    currentImageIndex = 0;
                    DisplayCurrentImage();

                    // Enable navigation buttons
                    btnNextImage.Enabled = true;
                    btnPrevImage.Enabled = true;

                    // Log initial message
                    LogMessage($"Found {imageUrls.Count} images for {currentMod.Name}");

                    // Optionally, you can log additional information if needed
                    LogMessage($"Image 1: {imageUrls[0]}");
                }
                else
                {
                    LogMessage($"No images found for {currentMod.Name}");
                }
            }
            catch (Exception e)
            {
                // Handle exceptions
                LogMessage($"Error searching images for {currentMod.Name}: {e.Message}");
            }
        }

        private void DisplayCurrentImage()
        {
            if (imageUrls.Count > 0 && currentImageIndex >= 0 && currentImageIndex < imageUrls.Count)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
                pictureBox1.LoadAsync(imageUrls[currentImageIndex]);
            }
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            if (currentImageIndex < imageUrls.Count - 1)
            {
                currentImageIndex++;
                DisplayCurrentImage();

                // Log the change
                LogMessage($"Displayed image {currentImageIndex + 1}: {imageUrls[currentImageIndex]}");
            }
        }

        private void btnPrevImage_Click(object sender, EventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                DisplayCurrentImage();

                // Log the change
                LogMessage($"Displayed image {currentImageIndex + 1}: {imageUrls[currentImageIndex]}");
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // Your code to handle user acceptance goes here
            // Create "images" directory and store the image if accepted
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            // Select a custom image
        }

        private void HandleNoSuitableImage(string modName)
        {
            // Your code to store the mod name to a text file for manual parsing
        }

        private void LogMessage(string message)
        {
            logBox.AppendText($"{DateTime.Now}: {message}\n");
        }
    }
}
