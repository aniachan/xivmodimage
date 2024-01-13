using System;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using GScraper;
using GScraper.Google;
using System.Net;
using System.IO.Compression;
using System.ComponentModel;

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
        private BackgroundWorker exportWorker;

        public Form1()
        {
            // Initialize the BackgroundWorker
            exportWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            // Attach event handlers for background worker
            exportWorker.DoWork += ExportModsWorker;
            exportWorker.ProgressChanged += ExportModsProgressChanged;
            exportWorker.RunWorkerCompleted += ExportModsCompleted;
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                penumbraDirectory = folderBrowser.SelectedPath;
                textModDir.Text = penumbraDirectory;
                btnPackMods.Enabled = true;
                btnScan.Enabled = true;
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
                ScanImagesForCurrentModAsync(modInfoList[0]);
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

        private async Task ScanImagesForCurrentModAsync(ModInfo currentMod)
        {
            try
            {
                using var scraper = new GoogleScraper();

                // Step 1: Search for the exact name of the mod in quotes
                string exactNameSearch = $"\"{currentMod.Name}\"";
                var exactNameResults = await scraper.GetImagesAsync(exactNameSearch);

                // Add the first 5 results with images larger than 100x100
                var filteredExactNameResults = exactNameResults
                    .Where(image => image.Width >= 100 && image.Height >= 100)
                    .Take(5)
                    .Select(image => image.Url)
                    .ToList();

                // Step 2: Search for the name of the mod along with the author and "ffxiv mod"
                string authorAndModSearch = $"{currentMod.Name} {currentMod.Author} ffxiv mod";
                var authorAndModResults = await scraper.GetImagesAsync(authorAndModSearch);

                // Add the first 10 results with images larger than 100x100
                var filteredAuthorAndModResults = authorAndModResults
                    .Where(image => image.Width >= 100 && image.Height >= 100)
                    .Take(10)
                    .Select(image => image.Url)
                    .ToList();

                // Combine the results from both searches
                imageUrls = filteredExactNameResults.Concat(filteredAuthorAndModResults).ToList();

                if (imageUrls.Count > 0)
                {
                    currentImageIndex = 0;
                    DisplayCurrentImage();

                    // Enable navigation buttons
                    btnNextImage.Enabled = true;
                    btnPrevImage.Enabled = true;

                    // Set labels for currently selected mod
                    labelModName.Text = currentMod.Name;
                    labelModAuthor.Text = currentMod.Author;

                    // Log initial message
                    LogMessage($"Found {imageUrls.Count} images for {currentMod.Name}");

                    // Optionally, you can log additional information if needed
                    LogMessage($"Image 1: {imageUrls[0]}");

                    // Enable the Accept button and the custom button
                    btnAccept.Enabled = true;
                    btnCustom.Enabled = true;
                }
                else
                {
                    LogMessage($"No images found for {currentMod.Name}");
                    pictureBox1.Image = null;
                    // Enable the custom button
                    btnCustom.Enabled = true;
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

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            if (imageUrls != null && currentImageIndex >= 0 && currentImageIndex < imageUrls.Count)
            {
                string imageUrl = imageUrls[currentImageIndex];
                string modImagesDirectory = Path.Combine(modInfoList[currentModIndex].ModPath, "images");

                try
                {
                    // Ensure the images directory exists
                    if (!Directory.Exists(modImagesDirectory))
                    {
                        Directory.CreateDirectory(modImagesDirectory);
                    }

                    // Download the image and save it to the images directory
                    string imagePath = Path.Combine(modImagesDirectory, $"xmi-image_{DateTime.Now:yyyyMMddHHmmss}.jpg");
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(new Uri(imageUrl), imagePath);
                    }

                    // Log success message
                    LogMessage($"Image saved successfully: {imagePath}");

                    // Trigger the next mod if available
                    await ProcessNextModAsync();
                }
                catch (Exception ex)
                {
                    // Log error message
                    LogMessage($"Error saving image: {ex.Message}");
                }
            }
        }

        private async void btnCustom_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    string modImagesDirectory = Path.Combine(modInfoList[currentModIndex].ModPath, "images");

                    try
                    {
                        // Ensure the images directory exists
                        if (!Directory.Exists(modImagesDirectory))
                        {
                            Directory.CreateDirectory(modImagesDirectory);
                        }

                        // Copy the selected image to the images directory
                        string imageName = Path.GetFileName(selectedImagePath);
                        string destinationPath = Path.Combine(modImagesDirectory, imageName);
                        File.Copy(selectedImagePath, destinationPath, true);

                        // Log success message
                        LogMessage($"Custom image saved successfully: {destinationPath}");

                        // Trigger the next mod if available
                        await ProcessNextModAsync();
                    }
                    catch (Exception ex)
                    {
                        // Log error message
                        LogMessage($"Error saving custom image: {ex.Message}");
                    }
                }
            }
        }

        private async Task ProcessNextModAsync()
        {
            currentImageIndex = 0; // Reset the image index
            pictureBox1.Image = null; // Clear the PictureBox

            if (++currentModIndex < modInfoList.Count)
            {
                DisplayCurrentModInfo();
                await ScanImagesForCurrentModAsync(modInfoList[currentModIndex]);
            }
            else
            {
                // End of the list
                LogMessage("All mods processed. Scanning complete.");
            }
        }

        private void LogMessage(string message)
        {
            logBox.AppendText($"{DateTime.Now}: {message}\n");
        }

        private void btnPackMods_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                // Ask the user where they want to save the exported mods
                folderBrowserDialog.Description = "Select a folder to save exported mods";
                folderBrowserDialog.ShowNewFolderButton = true;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string exportPath = folderBrowserDialog.SelectedPath;
                    List<string> subDirectories = new List<string>(Directory.GetDirectories(penumbraDirectory));

                    progressBarExportMods.Visible = true;
                    // Start the background worker
                    exportWorker.RunWorkerAsync(argument: new ExportModsArguments(subDirectories, exportPath));
                }
            }
        }
        private class ExportModsArguments
        {
            public List<string> ModDirectories { get; }
            public string ExportPath { get; }

            public ExportModsArguments(List<string> modDirectories, string exportPath)
            {
                ModDirectories = modDirectories;
                ExportPath = exportPath;
            }
        }
        private void ExportModsWorker(object sender, DoWorkEventArgs e)
        {
            var arguments = (ExportModsArguments)e.Argument;
            var worker = (BackgroundWorker)sender;

            for (int i = 0; i < arguments.ModDirectories.Count; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                string modDirectory = arguments.ModDirectories[i];
                int progressPercentage = (i + 1) * 100 / arguments.ModDirectories.Count;

                worker.ReportProgress(progressPercentage, $"Exporting mod {i + 1}/{arguments.ModDirectories.Count}");

                if (Directory.Exists(modDirectory))
                {
                    string metaJsonPath = Path.Combine(modDirectory, "meta.json");

                    if (File.Exists(metaJsonPath))
                    {
                        try
                        {
                            string exportFileName = Path.Combine(arguments.ExportPath, $"{Path.GetFileName(modDirectory)}.pmp");
                            ZipFile.CreateFromDirectory(modDirectory, exportFileName, CompressionLevel.Optimal, false);
                        }
                        catch (Exception ex)
                        {
                            worker.ReportProgress(progressPercentage, $"Error exporting mod: {ex.Message}");
                        }
                    }
                    else
                    {
                        worker.ReportProgress(progressPercentage, $"Error exporting mod: Missing meta.json - {modDirectory}");
                    }
                }
                else
                {
                    worker.ReportProgress(progressPercentage, $"Error exporting mod: Directory not found - {modDirectory}");
                }
            }
        }

        private void ExportModsProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update progress in the UI
            progressBarExportMods.Value = e.ProgressPercentage;
            LogMessage(e.UserState.ToString());
        }

        private void ExportModsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Handle completion, if needed
            if (e.Cancelled)
            {
                LogMessage("Export operation canceled.");
            }
            else if (e.Error != null)
            {
                LogMessage($"Error during export operation: {e.Error.Message}");
            }
            else
            {
                LogMessage("Export operation completed successfully.");
            }
            progressBarExportMods.Visible = false;
        }
    }
}