
namespace SkiaHarfbuzzCSharp
{
    partial class Form1
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
            this.openFontFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bOpenFontFile = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbText = new System.Windows.Forms.TextBox();
            this.cbRTL = new System.Windows.Forms.CheckBox();
            this.cbHarfbuzz = new System.Windows.Forms.CheckBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.cbAntiAliasing = new System.Windows.Forms.CheckBox();
            this.cbKerning = new System.Windows.Forms.CheckBox();
            this.cbLigatures = new System.Windows.Forms.CheckBox();
            this.cbCapSpacing = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbFontSize = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFontName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFontFileDialog
            // 
            this.openFontFileDialog.Filter = "TrueType font files|*.ttf|OpenType font files|*.otf";
            // 
            // bOpenFontFile
            // 
            this.bOpenFontFile.Location = new System.Drawing.Point(12, 12);
            this.bOpenFontFile.Name = "bOpenFontFile";
            this.bOpenFontFile.Size = new System.Drawing.Size(126, 237);
            this.bOpenFontFile.TabIndex = 0;
            this.bOpenFontFile.Text = "Open font file";
            this.bOpenFontFile.UseVisualStyleBackColor = true;
            this.bOpenFontFile.Click += new System.EventHandler(this.bOpenFontFile_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 255);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1673, 760);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tbText
            // 
            this.tbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbText.Location = new System.Drawing.Point(158, 45);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(686, 44);
            this.tbText.TabIndex = 2;
            this.tbText.Text = "阿德莱德分行";
            this.tbText.TextChanged += new System.EventHandler(this.onControlChanged);
            // 
            // cbRTL
            // 
            this.cbRTL.AutoSize = true;
            this.cbRTL.Location = new System.Drawing.Point(6, 65);
            this.cbRTL.Name = "cbRTL";
            this.cbRTL.Size = new System.Drawing.Size(169, 29);
            this.cbRTL.TabIndex = 3;
            this.cbRTL.Text = "Right-To-Left";
            this.cbRTL.UseVisualStyleBackColor = true;
            this.cbRTL.CheckedChanged += new System.EventHandler(this.onControlChanged);
            // 
            // cbHarfbuzz
            // 
            this.cbHarfbuzz.AutoSize = true;
            this.cbHarfbuzz.Location = new System.Drawing.Point(6, 30);
            this.cbHarfbuzz.Name = "cbHarfbuzz";
            this.cbHarfbuzz.Size = new System.Drawing.Size(246, 29);
            this.cbHarfbuzz.TabIndex = 4;
            this.cbHarfbuzz.Text = "Use Harfbuzz shaper";
            this.cbHarfbuzz.UseVisualStyleBackColor = true;
            this.cbHarfbuzz.CheckedChanged += new System.EventHandler(this.onControlChanged);
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(257, 63);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(190, 33);
            this.comboBoxLanguage.TabIndex = 5;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.onControlChanged);
            // 
            // cbAntiAliasing
            // 
            this.cbAntiAliasing.AutoSize = true;
            this.cbAntiAliasing.Checked = true;
            this.cbAntiAliasing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAntiAliasing.Location = new System.Drawing.Point(258, 28);
            this.cbAntiAliasing.Name = "cbAntiAliasing";
            this.cbAntiAliasing.Size = new System.Drawing.Size(155, 29);
            this.cbAntiAliasing.TabIndex = 6;
            this.cbAntiAliasing.Text = "Antialiasing";
            this.cbAntiAliasing.UseVisualStyleBackColor = true;
            this.cbAntiAliasing.CheckedChanged += new System.EventHandler(this.onControlChanged);
            // 
            // cbKerning
            // 
            this.cbKerning.AutoSize = true;
            this.cbKerning.Location = new System.Drawing.Point(6, 30);
            this.cbKerning.Name = "cbKerning";
            this.cbKerning.Size = new System.Drawing.Size(118, 29);
            this.cbKerning.TabIndex = 7;
            this.cbKerning.Text = "Kerning";
            this.cbKerning.UseVisualStyleBackColor = true;
            this.cbKerning.CheckedChanged += new System.EventHandler(this.onControlChanged);
            // 
            // cbLigatures
            // 
            this.cbLigatures.AutoSize = true;
            this.cbLigatures.Location = new System.Drawing.Point(6, 65);
            this.cbLigatures.Name = "cbLigatures";
            this.cbLigatures.Size = new System.Drawing.Size(133, 29);
            this.cbLigatures.TabIndex = 8;
            this.cbLigatures.Text = "Ligatures";
            this.cbLigatures.UseVisualStyleBackColor = true;
            this.cbLigatures.CheckedChanged += new System.EventHandler(this.onControlChanged);
            // 
            // cbCapSpacing
            // 
            this.cbCapSpacing.AutoSize = true;
            this.cbCapSpacing.Location = new System.Drawing.Point(6, 100);
            this.cbCapSpacing.Name = "cbCapSpacing";
            this.cbCapSpacing.Size = new System.Drawing.Size(195, 29);
            this.cbCapSpacing.TabIndex = 9;
            this.cbCapSpacing.Text = "Capital Spacing";
            this.cbCapSpacing.UseVisualStyleBackColor = true;
            this.cbCapSpacing.CheckedChanged += new System.EventHandler(this.onControlChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbFontSize);
            this.groupBox1.Controls.Add(this.cbHarfbuzz);
            this.groupBox1.Controls.Add(this.cbRTL);
            this.groupBox1.Controls.Add(this.comboBoxLanguage);
            this.groupBox1.Controls.Add(this.cbAntiAliasing);
            this.groupBox1.Location = new System.Drawing.Point(856, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 237);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text layout settings";
            // 
            // tbFontSize
            // 
            this.tbFontSize.Location = new System.Drawing.Point(11, 129);
            this.tbFontSize.Maximum = 1000;
            this.tbFontSize.Minimum = 100;
            this.tbFontSize.Name = "tbFontSize";
            this.tbFontSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbFontSize.Size = new System.Drawing.Size(436, 90);
            this.tbFontSize.TabIndex = 13;
            this.tbFontSize.TickFrequency = 100;
            this.tbFontSize.Value = 200;
            this.tbFontSize.Scroll += new System.EventHandler(this.onControlChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Text to layout:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbKerning);
            this.groupBox2.Controls.Add(this.cbLigatures);
            this.groupBox2.Controls.Add(this.cbCapSpacing);
            this.groupBox2.Location = new System.Drawing.Point(1327, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 237);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OpenType Features";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Font:";
            // 
            // lblFontName
            // 
            this.lblFontName.AutoSize = true;
            this.lblFontName.Location = new System.Drawing.Point(226, 135);
            this.lblFontName.Name = "lblFontName";
            this.lblFontName.Size = new System.Drawing.Size(113, 25);
            this.lblFontName.TabIndex = 14;
            this.lblFontName.Text = "not loaded";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Font size";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1697, 1027);
            this.Controls.Add(this.lblFontName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bOpenFontFile);
            this.Name = "Form1";
            this.Text = "Test Skia and Hurfbuzz";
            this.Resize += new System.EventHandler(this.onControlChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFontFileDialog;
        private System.Windows.Forms.Button bOpenFontFile;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.CheckBox cbRTL;
        private System.Windows.Forms.CheckBox cbHarfbuzz;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.CheckBox cbAntiAliasing;
        private System.Windows.Forms.CheckBox cbKerning;
        private System.Windows.Forms.CheckBox cbLigatures;
        private System.Windows.Forms.CheckBox cbCapSpacing;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar tbFontSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFontName;
        private System.Windows.Forms.Label label3;
    }
}

