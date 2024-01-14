namespace xivmodimage
{
    partial class Form1
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
            labelPageTitle = new Label();
            labelImageProgress = new Label();
            btnSkip = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // descTitle
            // 
            descTitle.AutoSize = true;
            descTitle.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            descTitle.Location = new Point(0, -1);
            descTitle.Name = "descTitle";
            descTitle.Size = new Size(270, 50);
            descTitle.TabIndex = 0;
            descTitle.Text = "XIVmodimage";
            // 
            // descAuthor
            // 
            descAuthor.AutoSize = true;
            descAuthor.Location = new Point(7, 43);
            descAuthor.Name = "descAuthor";
            descAuthor.Size = new Size(85, 15);
            descAuthor.TabIndex = 1;
            descAuthor.Text = "by anialothaire";
            // 
            // textModDir
            // 
            textModDir.Location = new Point(12, 423);
            textModDir.Name = "textModDir";
            textModDir.Size = new Size(317, 23);
            textModDir.TabIndex = 2;
            // 
            // btnAccept
            // 
            btnAccept.Enabled = false;
            btnAccept.Location = new Point(566, 376);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(117, 32);
            btnAccept.TabIndex = 3;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(334, 423);
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
            btnScan.Location = new Point(411, 376);
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
            btnCustom.Location = new Point(566, 414);
            btnCustom.Name = "btnCustom";
            btnCustom.Size = new Size(117, 32);
            btnCustom.TabIndex = 6;
            btnCustom.Text = "Custom Image";
            btnCustom.UseVisualStyleBackColor = true;
            btnCustom.Click += btnCustom_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(398, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(390, 268);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // btnPrevImage
            // 
            btnPrevImage.Enabled = false;
            btnPrevImage.Location = new Point(398, 291);
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
            btnNextImage.Location = new Point(479, 291);
            btnNextImage.Name = "btnNextImage";
            btnNextImage.Size = new Size(75, 23);
            btnNextImage.TabIndex = 9;
            btnNextImage.Text = "Next";
            btnNextImage.UseVisualStyleBackColor = true;
            btnNextImage.Click += btnNextImage_Click;
            // 
            // logBox
            // 
            logBox.Location = new Point(12, 71);
            logBox.Name = "logBox";
            logBox.Size = new Size(372, 346);
            logBox.TabIndex = 10;
            logBox.Text = "";
            // 
            // descModName
            // 
            descModName.AutoSize = true;
            descModName.Location = new Point(398, 317);
            descModName.Name = "descModName";
            descModName.Size = new Size(70, 15);
            descModName.TabIndex = 11;
            descModName.Text = "Mod Name:";
            // 
            // labelModName
            // 
            labelModName.AutoSize = true;
            labelModName.Location = new Point(474, 317);
            labelModName.Name = "labelModName";
            labelModName.Size = new Size(27, 15);
            labelModName.TabIndex = 12;
            labelModName.Text = "null";
            // 
            // descModAuthor
            // 
            descModAuthor.AutoSize = true;
            descModAuthor.Location = new Point(400, 337);
            descModAuthor.Name = "descModAuthor";
            descModAuthor.Size = new Size(78, 15);
            descModAuthor.TabIndex = 13;
            descModAuthor.Text = "Mod Author: ";
            // 
            // labelModAuthor
            // 
            labelModAuthor.AutoSize = true;
            labelModAuthor.Location = new Point(474, 337);
            labelModAuthor.Name = "labelModAuthor";
            labelModAuthor.Size = new Size(27, 15);
            labelModAuthor.TabIndex = 14;
            labelModAuthor.Text = "null";
            // 
            // btnPackMods
            // 
            btnPackMods.Enabled = false;
            btnPackMods.Location = new Point(689, 376);
            btnPackMods.Name = "btnPackMods";
            btnPackMods.Size = new Size(99, 32);
            btnPackMods.TabIndex = 15;
            btnPackMods.Text = "Pack Mods";
            btnPackMods.UseVisualStyleBackColor = true;
            btnPackMods.Click += btnPackMods_Click;
            // 
            // progressBarExportMods
            // 
            progressBarExportMods.Location = new Point(689, 414);
            progressBarExportMods.Name = "progressBarExportMods";
            progressBarExportMods.Size = new Size(99, 32);
            progressBarExportMods.TabIndex = 16;
            progressBarExportMods.Visible = false;
            // 
            // descPageTitle
            // 
            descPageTitle.AutoSize = true;
            descPageTitle.Location = new Point(400, 358);
            descPageTitle.Name = "descPageTitle";
            descPageTitle.Size = new Size(61, 15);
            descPageTitle.TabIndex = 17;
            descPageTitle.Text = "Page Title:";
            // 
            // labelPageTitle
            // 
            labelPageTitle.AutoSize = true;
            labelPageTitle.Location = new Point(474, 358);
            labelPageTitle.Name = "labelPageTitle";
            labelPageTitle.Size = new Size(27, 15);
            labelPageTitle.TabIndex = 18;
            labelPageTitle.Text = "null";
            labelPageTitle.UseMnemonic = false;
            // 
            // labelImageProgress
            // 
            labelImageProgress.AutoSize = true;
            labelImageProgress.Location = new Point(750, 295);
            labelImageProgress.Name = "labelImageProgress";
            labelImageProgress.Size = new Size(27, 15);
            labelImageProgress.TabIndex = 19;
            labelImageProgress.Text = "null";
            // 
            // btnSkip
            // 
            btnSkip.Enabled = false;
            btnSkip.Location = new Point(689, 414);
            btnSkip.Name = "btnSkip";
            btnSkip.Size = new Size(99, 32);
            btnSkip.TabIndex = 20;
            btnSkip.Text = "Skip Mod";
            btnSkip.UseVisualStyleBackColor = true;
            btnSkip.Visible = false;
            btnSkip.Click += btnSkip_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSkip);
            Controls.Add(labelImageProgress);
            Controls.Add(labelPageTitle);
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
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Label labelPageTitle;
        private Label labelImageProgress;
        private Button btnSkip;
    }
}