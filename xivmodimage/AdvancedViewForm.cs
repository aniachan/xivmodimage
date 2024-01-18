using System.Diagnostics;
using System.Net;

namespace xivmodimage
{
    public partial class AdvancedViewForm : Form
    {
        private SimpleViewForm simpleView;
        private ModProcessingAction modProcessingAction = ModProcessingAction.Accept; // Default action
        private List<ModInfo> unprocessedMods;
        private int currentIndex = 0;
        private Dictionary<int, int> currentImageIndices = new Dictionary<int, int>(); // Dictionary to store current image index for each row
        private Dictionary<int, List<ImageInfo>> modImages = new Dictionary<int, List<ImageInfo>>(); // Dictionary to store all the images for the mods currently loaded
        private ImageScanner imageScanner;
        private ImageLoader imageLoader;
        private ModAcceptanceHandler modAcceptanceHandler;

        public AdvancedViewForm(SimpleViewForm simpleView, List<ModInfo> unprocessedMods)
        {
            InitializeComponent();
            this.simpleView = simpleView;
            this.unprocessedMods = unprocessedMods;

            imageScanner = new ImageScanner(simpleView.LogMessage);
            imageLoader = new ImageLoader(simpleView.LogMessage);
            modAcceptanceHandler = new ModAcceptanceHandler(simpleView.LogMessage);

            // Initialize the DataGridView
            InitializeDataGridView();

            // Detach the event handler first to avoid multiple attachments
            dataGridView1.CellContentClick -= DataGridView1_CellContentClick;

            // Attach event handlers for the Next and Previous buttons
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

            // Initialize the current image indices for each row
            for (int i = 0; i < unprocessedMods.Count; i++)
            {
                currentImageIndices[i] = 0;
            }
        }

        private void InitializeDataGridView()
        {
            // Add data to DataGridView
            UpdateModData();
        }

        private async void UpdateModData()
        {
            btnProcess.Enabled = false;
            labelModCounter.Text = "Loading...";

            // Clear existing rows
            dataGridView1.Rows.Clear();
            modImages.Clear();

            // Display the first 20 mods in the unprocessed list
            int endIndex = Math.Min(currentIndex + 20, unprocessedMods.Count);

            for (int i = currentIndex; i < endIndex; i++)
            {
                ModInfo mod = unprocessedMods[i];

                int rowIndex = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                // Set the image column (you may need to replace this with the actual image data)
                List<ImageInfo> images = await imageScanner.ScanImagesForModAsync(mod);

                modImages.Add(rowIndex, images);
                DisplayCurrentImage(rowIndex);

                // Set the mod details column
                row.Cells["colModDetails"].Value = $"{mod.Name} by {mod.Author}";

                // Set mod index column
                row.Cells["colModIndex"].Value = currentIndex + rowIndex + 1;
            }
            // Update the label to show the mod counter
            UpdateModCounterLabel(currentIndex + 1, endIndex);
            btnProcess.Enabled = true;
        }

        private void UpdateModCounterLabel(int startIndex, int endIndex)
        {
            labelModCounter.Text = $"Mods {startIndex} - {endIndex}";
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            // Process the selected mods
            if (ProcessSelectedMods()) {
                // Move to the next batch
                currentIndex += 20;

                // Update the DataGridView with the new batch
                UpdateModData();
            }
        }

        private bool ProcessSelectedMods()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Access mod information using the row index
                int modIndex = currentIndex + row.Index;
                if (modIndex < unprocessedMods.Count)
                {
                    ModInfo mod = unprocessedMods[modIndex];
                    int currentImageIndex = currentImageIndices.GetValueOrDefault(row.Index, 0);
                    List<ImageInfo> images = modImages.GetValueOrDefault(row.Index, new List<ImageInfo>());

                    // Access the selected action from the combo box
                    string selectedAction = row.Cells["colModAction"].Value?.ToString();

                    // Check if an action is selected
                    if (string.IsNullOrEmpty(selectedAction))
                    {
                        // Display an error dialog
                        MessageBox.Show("Please select an action for all selected mods.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; // Stop processing if an error occurs
                    }

                    // Process the mod based on the selected action
                    switch (selectedAction)
                    {
                        case "Accept":
                            // Process for Accept
                            simpleView.LogMessage($"Processing mod '{mod.Name}' - Accept");
                            modAcceptanceHandler.AcceptModImage(mod, images[currentImageIndex]);
                            break;
                        case "Skip":
                            // Process for Skip
                            simpleView.LogMessage($"Processing mod '{mod.Name}' - Skip");
                            // Do nothing...
                            break;
                        case "No Image":
                            // Process for No Image
                            simpleView.LogMessage($"Processing mod '{mod.Name}' - No Image");
                            modAcceptanceHandler.AcceptNoImage(mod);
                            break;
                            // Add additional cases if needed
                    }
                }
            }
            return true;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is a button cell and corresponds to the Next or Previous button
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewButtonColumn buttonColumn = (DataGridViewButtonColumn)dataGridView1.Columns[e.ColumnIndex];

                // Handle the Next button click
                if (buttonColumn.Name == "btnNextImage")
                {
                    MoveToNextImage(e.RowIndex);
                }
                // Handle the Previous button click
                else if (buttonColumn.Name == "btnPrevImage")
                {
                    MoveToPreviousImage(e.RowIndex);
                }
            }

            // Check if the clicked cell is in the colPageTitle column
            if (e.ColumnIndex == dataGridView1.Columns["colPageTitle"].Index && e.RowIndex >= 0)
            {
                // Get the URL from the Tag property
                string url = dataGridView1.Rows[e.RowIndex].Cells["colPageTitle"].Tag as string;

                // Open the webpage in the default web browser
                if (!string.IsNullOrEmpty(url))
                {
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
            }
        }

        private void MoveToNextImage(int rowIndex)
        {
            // Retrieve the images for the specified row
            List<ImageInfo> images = modImages.GetValueOrDefault(rowIndex, new List<ImageInfo>());

            if (currentImageIndices.ContainsKey(rowIndex) && currentImageIndices[rowIndex] < images.Count - 1)
            {
                currentImageIndices[rowIndex]++;
                DisplayCurrentImage(rowIndex);
            }
        }

        private void MoveToPreviousImage(int rowIndex)
        {
            if (currentImageIndices.ContainsKey(rowIndex) && currentImageIndices[rowIndex] > 0)
            {
                currentImageIndices[rowIndex]--;
                DisplayCurrentImage(rowIndex);
            }
        }

        private async void DisplayCurrentImage(int rowIndex)
        {
            // Retrieve the images for the specified row
            List<ImageInfo> images = modImages.GetValueOrDefault(rowIndex, new List<ImageInfo>());

            if (images.Count > 0 && currentImageIndices.ContainsKey(rowIndex) &&
                currentImageIndices[rowIndex] >= 0 && currentImageIndices[rowIndex] < images.Count)
            {
                // Set the current image index for the specified row
                int currentImageIndexForThisRow = currentImageIndices[rowIndex];

                // Set the current image information for the specified row
                var imageInfoForThisRow = images[currentImageIndexForThisRow];

                // Get the DataGridViewRow for the specified row index
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                // Set the link text and value for the colPageTitle column
                DataGridViewLinkCell linkCell = (DataGridViewLinkCell)row.Cells["colPageTitle"];
                linkCell.Value = imageInfoForThisRow.PageTitle;
                linkCell.LinkVisited = false; // Reset the visited state

                // Attach the CellContentClick event handler
                row.Cells["colPageTitle"].Tag = imageInfoForThisRow.PageUrl;
                row.Cells["colPageTitle"].Value = imageInfoForThisRow.PageTitle;

                // Set image index value
                row.Cells["colImageIndex"].Value = $"{currentImageIndexForThisRow + 1} of {images.Count}";

                try
                {
                    // Load the image asynchronously using Task.Run
                    row.Cells["colImage"].Value = await Task.Run(() => imageLoader.LoadImageAsync(imageInfoForThisRow.ImageUrl));
                }
                catch (WebException webEx)
                {
                    // Handle web-related exceptions (e.g., network issues, 404 not found)
                    simpleView.LogMessage($"WebException loading image: {webEx.Message}");
                    row.Cells["colImage"].Value = null;
                }
                catch (ArgumentException argEx)
                {
                    // Handle image-related exceptions (e.g., invalid image format)
                    simpleView.LogMessage($"ArgumentException loading image: {argEx.Message}");
                    row.Cells["colImage"].Value = null;
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    simpleView.LogMessage($"Error loading image: {ex.Message}");
                    row.Cells["colImage"].Value = null;
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check for the desired key combinations
            if (e.KeyCode == Keys.Q)
            {
                // Pressed 'Q': Go to previous image for highlighted row
                MoveToPreviousImage(dataGridView1.CurrentRow.Index);
            }
            else if (e.KeyCode == Keys.E)
            {
                // Pressed 'E': Go to next image for highlighted row
                MoveToNextImage(dataGridView1.CurrentRow.Index);
            }
            else if (e.KeyCode == Keys.R)
            {
                // Pressed 'R': Set dropdown to 'Accept'
                SetComboBoxValue(dataGridView1.CurrentRow.Index, "colModAction", "Accept");
            }
            else if (e.KeyCode == Keys.T)
            {
                // Pressed 'T': Set dropdown to 'Skip'
                SetComboBoxValue(dataGridView1.CurrentRow.Index, "colModAction", "Skip");
            }
            else if (e.KeyCode == Keys.Y)
            {
                // Pressed 'Y': Set dropdown to 'No Image'
                SetComboBoxValue(dataGridView1.CurrentRow.Index, "colModAction", "No Image");
            }
            else if (e.KeyCode == Keys.W)
            {
                // Pressed 'W': Move up one row
                MoveToRow(dataGridView1.CurrentRow.Index - 1);
            }
            else if (e.KeyCode == Keys.S)
            {
                // Pressed 'S': Move down one row
                MoveToRow(dataGridView1.CurrentRow.Index + 1);
            }
        }

        private void SetComboBoxValue(int rowIndex, string columnName, string value)
        {
            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)dataGridView1.Rows[rowIndex].Cells[columnName];
                comboBoxCell.Value = value;
            }
        }

        private void MoveToRow(int targetRowIndex)
        {
            // Ensure the targetRowIndex is within the valid range
            targetRowIndex = Math.Max(0, Math.Min(targetRowIndex, dataGridView1.Rows.Count - 1));

            // Select the cell in the first column of the target row
            dataGridView1.CurrentCell = dataGridView1.Rows[targetRowIndex].Cells[0];
            dataGridView1.Rows[targetRowIndex].Selected = true;
        }

    }
}
