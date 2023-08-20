namespace Duplicates
{
    partial class SelectDirectoriesForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAnalysisByContent = new System.Windows.Forms.RadioButton();
            this.rbAnalysisByName = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.bRemoveDirectory = new System.Windows.Forms.Button();
            this.bAddDirectory = new System.Windows.Forms.Button();
            this.lbDirectories = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAnalysisByContent);
            this.groupBox1.Controls.Add(this.rbAnalysisByName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bRemoveDirectory);
            this.groupBox1.Controls.Add(this.bAddDirectory);
            this.groupBox1.Controls.Add(this.lbDirectories);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Foldery";
            // 
            // rbAnalysisByContent
            // 
            this.rbAnalysisByContent.AutoSize = true;
            this.rbAnalysisByContent.Location = new System.Drawing.Point(316, 133);
            this.rbAnalysisByContent.Name = "rbAnalysisByContent";
            this.rbAnalysisByContent.Size = new System.Drawing.Size(75, 17);
            this.rbAnalysisByContent.TabIndex = 5;
            this.rbAnalysisByContent.Text = "zawartości";
            this.rbAnalysisByContent.UseVisualStyleBackColor = true;
            this.rbAnalysisByContent.CheckedChanged += new System.EventHandler(this.rbAnalysisByContent_CheckedChanged);
            // 
            // rbAnalysisByName
            // 
            this.rbAnalysisByName.AutoSize = true;
            this.rbAnalysisByName.Checked = true;
            this.rbAnalysisByName.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbAnalysisByName.Location = new System.Drawing.Point(252, 133);
            this.rbAnalysisByName.Name = "rbAnalysisByName";
            this.rbAnalysisByName.Size = new System.Drawing.Size(58, 17);
            this.rbAnalysisByName.TabIndex = 4;
            this.rbAnalysisByName.TabStop = true;
            this.rbAnalysisByName.Text = "nazwie";
            this.rbAnalysisByName.UseVisualStyleBackColor = true;
            this.rbAnalysisByName.CheckedChanged += new System.EventHandler(this.rbAnalysisByName_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Szukaj po:";
            // 
            // bRemoveDirectory
            // 
            this.bRemoveDirectory.Location = new System.Drawing.Point(93, 130);
            this.bRemoveDirectory.Name = "bRemoveDirectory";
            this.bRemoveDirectory.Size = new System.Drawing.Size(75, 23);
            this.bRemoveDirectory.TabIndex = 2;
            this.bRemoveDirectory.Text = "Usuń";
            this.bRemoveDirectory.UseVisualStyleBackColor = true;
            this.bRemoveDirectory.Click += new System.EventHandler(this.bRemoveDirectory_Click);
            // 
            // bAddDirectory
            // 
            this.bAddDirectory.Location = new System.Drawing.Point(9, 130);
            this.bAddDirectory.Name = "bAddDirectory";
            this.bAddDirectory.Size = new System.Drawing.Size(75, 23);
            this.bAddDirectory.TabIndex = 1;
            this.bAddDirectory.Text = "Dodaj";
            this.bAddDirectory.UseVisualStyleBackColor = true;
            this.bAddDirectory.Click += new System.EventHandler(this.bAddDirectory_Click);
            // 
            // lbDirectories
            // 
            this.lbDirectories.FormattingEnabled = true;
            this.lbDirectories.Location = new System.Drawing.Point(6, 19);
            this.lbDirectories.Name = "lbDirectories";
            this.lbDirectories.Size = new System.Drawing.Size(385, 108);
            this.lbDirectories.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(334, 181);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Anuluj";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button4.Location = new System.Drawing.Point(253, 181);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "OK";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // SelectDirectoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 216);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectDirectoriesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wybierz foldery";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAnalysisByContent;
        private System.Windows.Forms.RadioButton rbAnalysisByName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bRemoveDirectory;
        private System.Windows.Forms.Button bAddDirectory;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        internal System.Windows.Forms.ListBox lbDirectories;
    }
}