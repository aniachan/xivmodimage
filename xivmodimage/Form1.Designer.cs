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
            this.descTitle = new System.Windows.Forms.Label();
            this.descAuthor = new System.Windows.Forms.Label();
            this.textModDir = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnCustom = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPrevImage = new System.Windows.Forms.Button();
            this.btnNextImage = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.descModName = new System.Windows.Forms.Label();
            this.labelModName = new System.Windows.Forms.Label();
            this.descModAuthor = new System.Windows.Forms.Label();
            this.labelModAuthor = new System.Windows.Forms.Label();
            this.btnPackMods = new System.Windows.Forms.Button();
            this.progressBarExportMods = new System.Windows.Forms.ProgressBar();
            this.descPageTitle = new System.Windows.Forms.Label();
            this.labelPageTitle = new System.Windows.Forms.Label();
            this.labelImageProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // descTitle
            // 
            this.descTitle.AutoSize = true;
            this.descTitle.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.descTitle.Location = new System.Drawing.Point(0, -1);
            this.descTitle.Name = "descTitle";
            this.descTitle.Size = new System.Drawing.Size(270, 50);
            this.descTitle.TabIndex = 0;
            this.descTitle.Text = "XIVmodimage";
            // 
            // descAuthor
            // 
            this.descAuthor.AutoSize = true;
            this.descAuthor.Location = new System.Drawing.Point(7, 43);
            this.descAuthor.Name = "descAuthor";
            this.descAuthor.Size = new System.Drawing.Size(85, 15);
            this.descAuthor.TabIndex = 1;
            this.descAuthor.Text = "by anialothaire";
            // 
            // textModDir
            // 
            this.textModDir.Location = new System.Drawing.Point(12, 423);
            this.textModDir.Name = "textModDir";
            this.textModDir.Size = new System.Drawing.Size(317, 23);
            this.textModDir.TabIndex = 2;
            // 
            // btnAccept
            // 
            this.btnAccept.Enabled = false;
            this.btnAccept.Location = new System.Drawing.Point(566, 376);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(117, 32);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(334, 423);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnScan
            // 
            this.btnScan.Enabled = false;
            this.btnScan.Location = new System.Drawing.Point(411, 376);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(143, 70);
            this.btnScan.TabIndex = 5;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnCustom
            // 
            this.btnCustom.Enabled = false;
            this.btnCustom.Location = new System.Drawing.Point(566, 414);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(117, 32);
            this.btnCustom.TabIndex = 6;
            this.btnCustom.Text = "Custom Image";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(398, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(390, 268);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnPrevImage
            // 
            this.btnPrevImage.Enabled = false;
            this.btnPrevImage.Location = new System.Drawing.Point(398, 291);
            this.btnPrevImage.Name = "btnPrevImage";
            this.btnPrevImage.Size = new System.Drawing.Size(75, 23);
            this.btnPrevImage.TabIndex = 8;
            this.btnPrevImage.Text = "Prev";
            this.btnPrevImage.UseVisualStyleBackColor = true;
            this.btnPrevImage.Click += new System.EventHandler(this.btnPrevImage_Click);
            // 
            // btnNextImage
            // 
            this.btnNextImage.Enabled = false;
            this.btnNextImage.Location = new System.Drawing.Point(479, 291);
            this.btnNextImage.Name = "btnNextImage";
            this.btnNextImage.Size = new System.Drawing.Size(75, 23);
            this.btnNextImage.TabIndex = 9;
            this.btnNextImage.Text = "Next";
            this.btnNextImage.UseVisualStyleBackColor = true;
            this.btnNextImage.Click += new System.EventHandler(this.btnNextImage_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(12, 71);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(372, 346);
            this.logBox.TabIndex = 10;
            this.logBox.Text = "";
            // 
            // descModName
            // 
            this.descModName.AutoSize = true;
            this.descModName.Location = new System.Drawing.Point(398, 317);
            this.descModName.Name = "descModName";
            this.descModName.Size = new System.Drawing.Size(70, 15);
            this.descModName.TabIndex = 11;
            this.descModName.Text = "Mod Name:";
            // 
            // labelModName
            // 
            this.labelModName.AutoSize = true;
            this.labelModName.Location = new System.Drawing.Point(474, 317);
            this.labelModName.Name = "labelModName";
            this.labelModName.Size = new System.Drawing.Size(27, 15);
            this.labelModName.TabIndex = 12;
            this.labelModName.Text = "null";
            // 
            // descModAuthor
            // 
            this.descModAuthor.AutoSize = true;
            this.descModAuthor.Location = new System.Drawing.Point(400, 337);
            this.descModAuthor.Name = "descModAuthor";
            this.descModAuthor.Size = new System.Drawing.Size(78, 15);
            this.descModAuthor.TabIndex = 13;
            this.descModAuthor.Text = "Mod Author: ";
            // 
            // labelModAuthor
            // 
            this.labelModAuthor.AutoSize = true;
            this.labelModAuthor.Location = new System.Drawing.Point(474, 337);
            this.labelModAuthor.Name = "labelModAuthor";
            this.labelModAuthor.Size = new System.Drawing.Size(27, 15);
            this.labelModAuthor.TabIndex = 14;
            this.labelModAuthor.Text = "null";
            // 
            // btnPackMods
            // 
            this.btnPackMods.Enabled = false;
            this.btnPackMods.Location = new System.Drawing.Point(689, 376);
            this.btnPackMods.Name = "btnPackMods";
            this.btnPackMods.Size = new System.Drawing.Size(99, 32);
            this.btnPackMods.TabIndex = 15;
            this.btnPackMods.Text = "Pack Mods";
            this.btnPackMods.UseVisualStyleBackColor = true;
            this.btnPackMods.Click += new System.EventHandler(this.btnPackMods_Click);
            // 
            // progressBarExportMods
            // 
            this.progressBarExportMods.Location = new System.Drawing.Point(689, 414);
            this.progressBarExportMods.Name = "progressBarExportMods";
            this.progressBarExportMods.Size = new System.Drawing.Size(99, 32);
            this.progressBarExportMods.TabIndex = 16;
            this.progressBarExportMods.Visible = false;
            // 
            // descPageTitle
            // 
            this.descPageTitle.AutoSize = true;
            this.descPageTitle.Location = new System.Drawing.Point(400, 358);
            this.descPageTitle.Name = "descPageTitle";
            this.descPageTitle.Size = new System.Drawing.Size(61, 15);
            this.descPageTitle.TabIndex = 17;
            this.descPageTitle.Text = "Page Title:";
            // 
            // labelPageTitle
            // 
            this.labelPageTitle.AutoSize = true;
            this.labelPageTitle.Location = new System.Drawing.Point(474, 358);
            this.labelPageTitle.Name = "labelPageTitle";
            this.labelPageTitle.Size = new System.Drawing.Size(27, 15);
            this.labelPageTitle.TabIndex = 18;
            this.labelPageTitle.Text = "null";
            this.labelPageTitle.UseMnemonic = false;
            // 
            // labelImageProgress
            // 
            this.labelImageProgress.AutoSize = true;
            this.labelImageProgress.Location = new System.Drawing.Point(750, 295);
            this.labelImageProgress.Name = "labelImageProgress";
            this.labelImageProgress.Size = new System.Drawing.Size(27, 15);
            this.labelImageProgress.TabIndex = 19;
            this.labelImageProgress.Text = "null";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelImageProgress);
            this.Controls.Add(this.labelPageTitle);
            this.Controls.Add(this.descPageTitle);
            this.Controls.Add(this.progressBarExportMods);
            this.Controls.Add(this.btnPackMods);
            this.Controls.Add(this.labelModAuthor);
            this.Controls.Add(this.descModAuthor);
            this.Controls.Add(this.labelModName);
            this.Controls.Add(this.descModName);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.btnNextImage);
            this.Controls.Add(this.btnPrevImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCustom);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.textModDir);
            this.Controls.Add(this.descAuthor);
            this.Controls.Add(this.descTitle);
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}