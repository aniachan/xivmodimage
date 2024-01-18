using System;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using GScraper;
using GScraper.Google;
using System.Net;
using System.IO.Compression;
using System.ComponentModel;
using System.Linq;
using System.Diagnostics;

namespace xivmodimage
{
    public partial class SimpleView : Form
    {
        // Instances
        private ModScanner modScanner;
        private ImageScanner imageScanner;
        private ImageLoader imageLoader;
        private ModAcceptanceHandler modAcceptanceHandler;
        private ModExporter modExporter;

        // Variables
        private string penumbraDirectory;
        private List<ModInfo> modInfoList = new List<ModInfo>();
        private int currentModIndex = 0;
        private List<ImageInfo> images = new List<ImageInfo>();
        private int currentImageIndex;
        private BackgroundWorker exportWorker;

        public SimpleView()
        {
            modScanner = new ModScanner(LogMessage);
            imageScanner = new ImageScanner(LogMessage);
            imageLoader = new ImageLoader(LogMessage);
            modAcceptanceHandler = new ModAcceptanceHandler(LogMessage);
            modExporter = new ModExporter(LogMessage);

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

            labelModAuthor.Text = "";
            labelModName.Text = "";
            labelPageTitle.Text = "";
            labelImageProgress.Text = "";
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
            modInfoList = modScanner.ScanDirectories(penumbraDirectory);

            if (modInfoList.Count > 0)
            {
                LogMessage("Scanning for mods...");
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

        private async Task ScanImagesForCurrentModAsync(ModInfo currentMod)
        {
            try
            {
                images = await imageScanner.ScanImagesForModAsync(currentMod);

                if (images.Count > 0)
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
                    LogMessage($"Found {images.Count} images for {currentMod.Name}");

                    // Enable the Accept button and the custom button
                    btnAccept.Enabled = true;
                    btnCustom.Enabled = true;
                    btnSkip.Enabled = true;
                    btnNoImage.Enabled = true;
                }
                else
                {
                    LogMessage($"No images found for {currentMod.Name}");
                    pictureBox1.Image = null;
                    // Enable the custom button
                    btnAccept.Enabled = false;
                    btnCustom.Enabled = true;
                    labelPageTitle.Text = "";
                    labelImageProgress.Text = "";
                    btnSkip.Enabled = true;
                    btnNoImage.Enabled = true;
                }
            }
            catch (Exception e)
            {
                // Handle exceptions
                LogMessage($"Error searching images for {currentMod.Name}: {e.Message}");
            }
        }


        private async void DisplayCurrentImage()
        {
            if (images.Count > 0 && currentImageIndex >= 0 && currentImageIndex < images.Count)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio

                try
                {
                    var imageInfo = images[currentImageIndex];
                    labelPageTitle.Text = imageInfo.PageTitle;
                    labelImageProgress.Text = $"{currentImageIndex + 1} / {images.Count}";

                    // Load the image asynchronously using Task.Run
                    pictureBox1.Image = await Task.Run(() => LoadImageAsync(imageInfo.ImageUrl));
                }
                catch (WebException webEx)
                {
                    // Handle web-related exceptions (e.g., network issues, 404 not found)
                    LogMessage($"WebException loading image: {webEx.Message}");
                    DisplayBlankImage();
                }
                catch (ArgumentException argEx)
                {
                    // Handle image-related exceptions (e.g., invalid image format)
                    LogMessage($"ArgumentException loading image: {argEx.Message}");
                    DisplayBlankImage();
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    LogMessage($"Error loading image: {ex.Message}");
                    DisplayBlankImage();
                }
            }
        }

        private void DisplayBlankImage()
        {
            // Set the image to null or clear it to display a blank spot
            pictureBox1.Image = null;
        }

        private async Task<Image> LoadImageAsync(string imageUrl)
        {
            return await imageLoader.LoadImageAsync(imageUrl);
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            if (currentImageIndex < images.Count - 1)
            {
                currentImageIndex++;
                DisplayCurrentImage();
            }
        }

        private void btnPrevImage_Click(object sender, EventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                DisplayCurrentImage();
            }
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            if (images != null && currentImageIndex >= 0 && currentImageIndex < images.Count)
            {
                modAcceptanceHandler.AcceptModImage(modInfoList[currentModIndex], images[currentImageIndex]);
                await ProcessNextModAsync();
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
                    modAcceptanceHandler.AcceptCustomImage(modInfoList[currentModIndex], selectedImagePath);
                    await ProcessNextModAsync();
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
                labelModAuthor.Text = "";
                labelModName.Text = "";
                labelPageTitle.Text = "";
                btnSkip.Enabled = false;
                btnAccept.Enabled = false;
                btnCustom.Enabled = false;
                btnNoImage.Enabled = false;
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
                folderBrowserDialog.Description = "Select a folder to save exported mods";
                folderBrowserDialog.ShowNewFolderButton = true;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string exportPath = folderBrowserDialog.SelectedPath;
                    List<string> subDirectories = new List<string>(Directory.GetDirectories(penumbraDirectory));

                    progressBarExportMods.Visible = true;
                    exportWorker.RunWorkerAsync(argument: new ExportModsArguments(subDirectories, exportPath));
                }
            }
        }

        private void ExportModsWorker(object sender, DoWorkEventArgs e)
        {
            var arguments = (ExportModsArguments)e.Argument;
            var worker = (BackgroundWorker)sender;

            modExporter.ExportMods(arguments.ModDirectories, arguments.ExportPath, worker);
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

        private async void btnSkip_Click(object sender, EventArgs e)
        {
            // Log success message
            LogMessage($"Skipping mod");

            // Trigger the next mod if available
            await ProcessNextModAsync();
        }

        private async void btnNoImage_Click(object sender, EventArgs e)
        {
            // Log success message
            LogMessage($"Marking mod as not containing images.");

            // Create the images directory if it doesn't exist
            string modImagesDirectory = Path.Combine(modInfoList[currentModIndex].ModPath, "images");
            if (!Directory.Exists(modImagesDirectory))
            {
                Directory.CreateDirectory(modImagesDirectory);
            }

            // Create a blank file called '.noimage'
            string noImageFilePath = Path.Combine(modImagesDirectory, ".noimage");
            File.WriteAllText(noImageFilePath, string.Empty);

            // Trigger the next mod if available
            await ProcessNextModAsync();
        }

        private void labelPageTitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (images != null && currentImageIndex >= 0 && currentImageIndex < images.Count)
            {
                string pageUrl = images[currentImageIndex].PageUrl;
                if (!string.IsNullOrEmpty(pageUrl))
                {
                    Process.Start(new ProcessStartInfo(pageUrl) { UseShellExecute = true });
                }
            }
        }
    }
}