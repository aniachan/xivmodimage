namespace xivmodimage
{
    partial class AdvancedViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedViewForm));
            dataGridView1 = new DataGridView();
            colModIndex = new DataGridViewTextBoxColumn();
            colImage = new DataGridViewImageColumn();
            colImageIndex = new DataGridViewTextBoxColumn();
            btnPrevImage = new DataGridViewButtonColumn();
            btnNextImage = new DataGridViewButtonColumn();
            colModDetails = new DataGridViewTextBoxColumn();
            colPageTitle = new DataGridViewLinkColumn();
            colModAction = new DataGridViewComboBoxColumn();
            panel1 = new Panel();
            label1 = new Label();
            btnProcess = new Button();
            labelModCounter = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colModIndex, colImage, colImageIndex, btnPrevImage, btnNextImage, colModDetails, colPageTitle, colModAction });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.RowTemplate.Height = 140;
            dataGridView1.Size = new Size(1184, 511);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            // 
            // colModIndex
            // 
            colModIndex.HeaderText = "Mod #";
            colModIndex.MinimumWidth = 50;
            colModIndex.Name = "colModIndex";
            colModIndex.ReadOnly = true;
            colModIndex.Width = 50;
            // 
            // colImage
            // 
            colImage.HeaderText = "Image";
            colImage.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colImage.MinimumWidth = 250;
            colImage.Name = "colImage";
            colImage.Width = 250;
            // 
            // colImageIndex
            // 
            colImageIndex.HeaderText = "Index";
            colImageIndex.Name = "colImageIndex";
            colImageIndex.ReadOnly = true;
            // 
            // btnPrevImage
            // 
            btnPrevImage.HeaderText = "Prev";
            btnPrevImage.MinimumWidth = 40;
            btnPrevImage.Name = "btnPrevImage";
            btnPrevImage.Text = "";
            btnPrevImage.ToolTipText = "Move to the previous image.";
            btnPrevImage.UseColumnTextForButtonValue = true;
            btnPrevImage.Width = 40;
            // 
            // btnNextImage
            // 
            btnNextImage.HeaderText = "Next";
            btnNextImage.MinimumWidth = 40;
            btnNextImage.Name = "btnNextImage";
            btnNextImage.Text = "";
            btnNextImage.ToolTipText = "Move to the next image.";
            btnNextImage.Width = 40;
            // 
            // colModDetails
            // 
            colModDetails.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colModDetails.FillWeight = 50F;
            colModDetails.HeaderText = "Mod Details";
            colModDetails.Name = "colModDetails";
            colModDetails.ReadOnly = true;
            // 
            // colPageTitle
            // 
            colPageTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPageTitle.FillWeight = 50F;
            colPageTitle.HeaderText = "Page Title";
            colPageTitle.Name = "colPageTitle";
            colPageTitle.ReadOnly = true;
            // 
            // colModAction
            // 
            colModAction.HeaderText = "Action";
            colModAction.Items.AddRange(new object[] { "Accept", "Skip", "No Image" });
            colModAction.MinimumWidth = 100;
            colModAction.Name = "colModAction";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridView1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 0, 0, 50);
            panel1.Size = new Size(1184, 561);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(3, 513);
            label1.Name = "label1";
            label1.Size = new Size(204, 45);
            label1.TabIndex = 1;
            label1.Text = "E = Next Image    Q = Previous Image\r\nR = Accept\r\nT = Skip                  Y = No Image";
            // 
            // btnProcess
            // 
            btnProcess.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnProcess.Location = new Point(1004, 515);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(168, 40);
            btnProcess.TabIndex = 2;
            btnProcess.Text = "Process";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // labelModCounter
            // 
            labelModCounter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelModCounter.AutoSize = true;
            labelModCounter.Location = new Point(911, 537);
            labelModCounter.Name = "labelModCounter";
            labelModCounter.Size = new Size(59, 15);
            labelModCounter.TabIndex = 3;
            labelModCounter.Text = "Loading...";
            // 
            // AdvancedViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 561);
            Controls.Add(labelModCounter);
            Controls.Add(btnProcess);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(3000, 3000);
            MinimumSize = new Size(1200, 400);
            Name = "AdvancedViewForm";
            Text = "XIVmodimage - Bulk Process";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private Button btnProcess;
        private Label labelModCounter;
        private DataGridViewTextBoxColumn colModIndex;
        private DataGridViewImageColumn colImage;
        private DataGridViewTextBoxColumn colImageIndex;
        private DataGridViewButtonColumn btnPrevImage;
        private DataGridViewButtonColumn btnNextImage;
        private DataGridViewTextBoxColumn colModDetails;
        private DataGridViewLinkColumn colPageTitle;
        private DataGridViewComboBoxColumn colModAction;
        private Label label1;
    }
}