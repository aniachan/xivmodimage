namespace xivmodimage
{
    partial class SimpleViewForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleViewForm));
            descTitle = new Label();
            descAuthor = new Label();
            textModDir = new TextBox();
            btnAccept = new Button();
            btnBrowse = new Button();
            btnScan = new Button();
            btnCustom = new Button();
            pictureBox1 = new PictureBox();
            btnPrevImage = new Button();
            btnNextImage = new Button();
            logBox = new RichTextBox();
            descModName = new Label();
            labelModName = new Label();
            descModAuthor = new Label();
            labelModAuthor = new Label();
            btnPackMods = new Button();
            progressBarExportMods = new ProgressBar();
            descPageTitle = new Label();
            labelImageProgress = new Label();
            btnSkip = new Button();
            pictureBox2 = new PictureBox();
            btnNoImage = new Button();
            labelPageTitle = new LinkLabel();
            btnBulkProcess = new Button();
            btnDeleteMod = new Button();
            btnAutoSort = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // descTitle
            // 
            descTitle.AutoSize = true;
            descTitle.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            descTitle.ForeColor = SystemColors.Control;
            descTitle.Location = new Point(182, 4);
            descTitle.Name = "descTitle";
            descTitle.Size = new Size(270, 50);
            descTitle.TabIndex = 0;
            descTitle.Text = "XIVmodimage";
            // 
            // descAuthor
            // 
            descAuthor.AutoSize = true;
            descAuthor.ForeColor = SystemColors.Control;
            descAuthor.Location = new Point(189, 45);
            descAuthor.Name = "descAuthor";
            descAuthor.Size = new Size(85, 15);
            descAuthor.TabIndex = 1;
            descAuthor.Text = "by anialothaire";
            // 
            // textModDir
            // 
            textModDir.Location = new Point(12, 632);
            textModDir.Name = "textModDir";
            textModDir.Size = new Size(317, 23);
            textModDir.TabIndex = 2;
            // 
            // btnAccept
            // 
            btnAccept.Enabled = false;
            btnAccept.Location = new Point(754, 583);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(117, 32);
            btnAccept.TabIndex = 3;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(334, 632);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnScan
            // 
            btnScan.Enabled = false;
            btnScan.Location = new Point(482, 583);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(143, 70);
            btnScan.TabIndex = 5;
            btnScan.Text = "Scan";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += btnScan_Click;
            // 
            // btnCustom
            // 
            btnCustom.Enabled = false;
            btnCustom.Location = new Point(631, 621);
            btnCustom.Name = "btnCustom";
            btnCustom.Size = new Size(117, 32);
            btnCustom.TabIndex = 6;
            btnCustom.Text = "Custom Image";
            btnCustom.UseVisualStyleBackColor = true;
            btnCustom.Click += btnCustom_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(458, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(518, 413);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // btnPrevImage
            // 
            btnPrevImage.Enabled = false;
            btnPrevImage.Location = new Point(457, 423);
            btnPrevImage.Name = "btnPrevImage";
            btnPrevImage.Size = new Size(75, 23);
            btnPrevImage.TabIndex = 8;
            btnPrevImage.Text = "Prev";
            btnPrevImage.UseVisualStyleBackColor = true;
            btnPrevImage.Click += btnPrevImage_Click;
            // 
            // btnNextImage
            // 
            btnNextImage.Enabled = false;
            btnNextImage.Location = new Point(538, 423);
            btnNextImage.Name = "btnNextImage";
            btnNextImage.Size = new Size(75, 23);
            btnNextImage.TabIndex = 9;
            btnNextImage.Text = "Next";
            btnNextImage.UseVisualStyleBackColor = true;
            btnNextImage.Click += btnNextImage_Click;
            // 
            // logBox
            // 
            logBox.BackColor = Color.FromArgb(99, 99, 99);
            logBox.ForeColor = SystemColors.Window;
            logBox.Location = new Point(12, 180);
            logBox.Name = "logBox";
            logBox.Size = new Size(425, 446);
            logBox.TabIndex = 10;
            logBox.Text = "";
            // 
            // descModName
            // 
            descModName.AutoSize = true;
            descModName.ForeColor = SystemColors.Control;
            descModName.Location = new Point(457, 449);
            descModName.Name = "descModName";
            descModName.Size = new Size(70, 15);
            descModName.TabIndex = 11;
            descModName.Text = "Mod Name:";
            // 
            // labelModName
            // 
            labelModName.AutoSize = true;
            labelModName.ForeColor = SystemColors.Control;
            labelModName.Location = new Point(533, 449);
            labelModName.Name = "labelModName";
            labelModName.Size = new Size(27, 15);
            labelModName.TabIndex = 12;
            labelModName.Text = "null";
            // 
            // descModAuthor
            // 
            descModAuthor.AutoSize = true;
            descModAuthor.ForeColor = SystemColors.Control;
            descModAuthor.Location = new Point(457, 470);
            descModAuthor.Name = "descModAuthor";
            descModAuthor.Size = new Size(78, 15);
            descModAuthor.TabIndex = 13;
            descModAuthor.Text = "Mod Author: ";
            // 
            // labelModAuthor
            // 
            labelModAuthor.AutoSize = true;
            labelModAuthor.ForeColor = SystemColors.Control;
            labelModAuthor.Location = new Point(533, 470);
            labelModAuthor.Name = "labelModAuthor";
            labelModAuthor.Size = new Size(27, 15);
            labelModAuthor.TabIndex = 14;
            labelModAuthor.Text = "null";
            // 
            // btnPackMods
            // 
            btnPackMods.Enabled = false;
            btnPackMods.Location = new Point(877, 583);
            btnPackMods.Name = "btnPackMods";
            btnPackMods.Size = new Size(99, 32);
            btnPackMods.TabIndex = 15;
            btnPackMods.Text = "Pack Mods";
            btnPackMods.UseVisualStyleBackColor = true;
            btnPackMods.Click += btnPackMods_Click;
            // 
            // progressBarExportMods
            // 
            progressBarExportMods.Location = new Point(754, 545);
            progressBarExportMods.Name = "progressBarExportMods";
            progressBarExportMods.Size = new Size(218, 32);
            progressBarExportMods.TabIndex = 16;
            progressBarExportMods.Visible = false;
            // 
            // descPageTitle
            // 
            descPageTitle.AutoSize = true;
            descPageTitle.ForeColor = SystemColors.Control;
            descPageTitle.Location = new Point(457, 490);
            descPageTitle.Name = "descPageTitle";
            descPageTitle.Size = new Size(61, 15);
            descPageTitle.TabIndex = 17;
            descPageTitle.Text = "Page Title:";
            // 
            // labelImageProgress
            // 
            labelImageProgress.AutoSize = true;
            labelImageProgress.ForeColor = SystemColors.Control;
            labelImageProgress.Location = new Point(930, 423);
            labelImageProgress.Name = "labelImageProgress";
            labelImageProgress.Size = new Size(27, 15);
            labelImageProgress.TabIndex = 19;
            labelImageProgress.Text = "null";
            // 
            // btnSkip
            // 
            btnSkip.Enabled = false;
            btnSkip.Location = new Point(877, 621);
            btnSkip.Name = "btnSkip";
            btnSkip.Size = new Size(99, 32);
            btnSkip.TabIndex = 20;
            btnSkip.Text = "Skip Mod";
            btnSkip.UseVisualStyleBackColor = true;
            btnSkip.Click += btnSkip_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(8, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(176, 154);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // btnNoImage
            // 
            btnNoImage.Enabled = false;
            btnNoImage.Location = new Point(754, 621);
            btnNoImage.Name = "btnNoImage";
            btnNoImage.Size = new Size(117, 32);
            btnNoImage.TabIndex = 22;
            btnNoImage.Text = "No Image";
            btnNoImage.UseVisualStyleBackColor = true;
            btnNoImage.Click += btnNoImage_Click;
            // 
            // labelPageTitle
            // 
            labelPageTitle.AutoSize = true;
            labelPageTitle.LinkColor = Color.FromArgb(192, 192, 255);
            labelPageTitle.Location = new Point(533, 490);
            labelPageTitle.Name = "labelPageTitle";
            labelPageTitle.Size = new Size(27, 15);
            labelPageTitle.TabIndex = 23;
            labelPageTitle.TabStop = true;
            labelPageTitle.Text = "null";
            labelPageTitle.VisitedLinkColor = Color.FromArgb(255, 192, 255);
            labelPageTitle.LinkClicked += labelPageTitle_LinkClicked;
            // 
            // btnBulkProcess
            // 
            btnBulkProcess.Enabled = false;
            btnBulkProcess.Location = new Point(631, 583);
            btnBulkProcess.Name = "btnBulkProcess";
            btnBulkProcess.Size = new Size(117, 32);
            btnBulkProcess.TabIndex = 24;
            btnBulkProcess.Text = "Bulk Process";
            btnBulkProcess.UseVisualStyleBackColor = true;
            btnBulkProcess.Click += btnBulkProcess_Click;
            // 
            // btnDeleteMod
            // 
            btnDeleteMod.BackColor = Color.FromArgb(255, 128, 128);
            btnDeleteMod.Location = new Point(631, 545);
            btnDeleteMod.Name = "btnDeleteMod";
            btnDeleteMod.Size = new Size(117, 32);
            btnDeleteMod.TabIndex = 25;
            btnDeleteMod.Text = "DELETE!";
            btnDeleteMod.UseVisualStyleBackColor = false;
            btnDeleteMod.Click += btnDeleteMod_Click;
            // 
            // btnAutoSort
            // 
            btnAutoSort.Location = new Point(482, 545);
            btnAutoSort.Name = "btnAutoSort";
            btnAutoSort.Size = new Size(143, 32);
            btnAutoSort.TabIndex = 26;
            btnAutoSort.Text = "Auto Sort";
            btnAutoSort.UseVisualStyleBackColor = true;
            btnAutoSort.Click += btnAutoSort_Click;
            // 
            // SimpleViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(99, 99, 99);
            ClientSize = new Size(984, 661);
            Controls.Add(btnAutoSort);
            Controls.Add(btnDeleteMod);
            Controls.Add(btnBulkProcess);
            Controls.Add(labelPageTitle);
            Controls.Add(btnNoImage);
            Controls.Add(pictureBox2);
            Controls.Add(btnSkip);
            Controls.Add(labelImageProgress);
            Controls.Add(descPageTitle);
            Controls.Add(progressBarExportMods);
            Controls.Add(btnPackMods);
            Controls.Add(labelModAuthor);
            Controls.Add(descModAuthor);
            Controls.Add(labelModName);
            Controls.Add(descModName);
            Controls.Add(logBox);
            Controls.Add(btnNextImage);
            Controls.Add(btnPrevImage);
            Controls.Add(pictureBox1);
            Controls.Add(btnCustom);
            Controls.Add(btnScan);
            Controls.Add(btnBrowse);
            Controls.Add(btnAccept);
            Controls.Add(textModDir);
            Controls.Add(descAuthor);
            Controls.Add(descTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1000, 700);
            MinimumSize = new Size(1000, 700);
            Name = "SimpleViewForm";
            Text = "XIVmodimage";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label descTitle;
        private Label descAuthor;
        private TextBox textModDir;
        private Button btnAccept;
        private Button btnBrowse;
        private Button btnScan;
        private Button btnCustom;
        private PictureBox pictureBox1;
        private Button btnPrevImage;
        private Button btnNextImage;
        private RichTextBox logBox;
        private Label descModName;
        private Label labelModName;
        private Label descModAuthor;
        private Label labelModAuthor;
        private Button btnPackMods;
        private ProgressBar progressBarExportMods;
        private Label descPageTitle;
        private Label labelImageProgress;
        private Button btnSkip;
        private PictureBox pictureBox2;
        private Button btnNoImage;
        private LinkLabel labelPageTitle;
        private Button btnBulkProcess;
        private Button btnDeleteMod;
        private Button btnAutoSort;
    }
}