using System.Reflection;
namespace Duplicates
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsActionButton = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReverseSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmResetSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMoveToTrash = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSelectDirectories = new System.Windows.Forms.ToolStripMenuItem();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tbFilter = new System.Windows.Forms.ToolStripTextBox();
            this.lStatus = new System.Windows.Forms.Label();
            this.lvDuplicates = new System.Windows.Forms.ListView();
            this.chFiles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsActionButton,
            this.tsProgressBar,
            this.tbFilter});
            this.statusStrip1.Location = new System.Drawing.Point(0, 243);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(527, 23);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsActionButton
            // 
            this.tsActionButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAbout,
            this.toolStripMenuItem2,
            this.tsmSelection,
            this.tsmCancel,
            this.tsmMoveToTrash,
            this.tsmSelectDirectories});
            this.tsActionButton.Image = ((System.Drawing.Image)(resources.GetObject("tsActionButton.Image")));
            this.tsActionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsActionButton.Name = "tsActionButton";
            this.tsActionButton.Size = new System.Drawing.Size(110, 21);
            this.tsActionButton.Text = "ActionButton";
            this.tsActionButton.ButtonClick += new System.EventHandler(this.tsActionButton_Click);
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.Size = new System.Drawing.Size(166, 22);
            this.tsmAbout.Text = "O programie";
            this.tsmAbout.Click += new System.EventHandler(this.tsmAbout_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(163, 6);
            // 
            // tsmSelection
            // 
            this.tsmSelection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSelectAll,
            this.tsmReverseSelection,
            this.tsmResetSelection});
            this.tsmSelection.Name = "tsmSelection";
            this.tsmSelection.Size = new System.Drawing.Size(166, 22);
            this.tsmSelection.Text = "Zaznaczenie";
            this.tsmSelection.Visible = false;
            // 
            // tsmSelectAll
            // 
            this.tsmSelectAll.Name = "tsmSelectAll";
            this.tsmSelectAll.Size = new System.Drawing.Size(166, 22);
            this.tsmSelectAll.Text = "Zaznacz wszystko";
            this.tsmSelectAll.Click += new System.EventHandler(this.tsmSelectAll_Click);
            // 
            // tsmReverseSelection
            // 
            this.tsmReverseSelection.Name = "tsmReverseSelection";
            this.tsmReverseSelection.Size = new System.Drawing.Size(166, 22);
            this.tsmReverseSelection.Text = "Odwróć";
            this.tsmReverseSelection.Click += new System.EventHandler(this.tsmReverseSelection_Click);
            // 
            // tsmResetSelection
            // 
            this.tsmResetSelection.Name = "tsmResetSelection";
            this.tsmResetSelection.Size = new System.Drawing.Size(166, 22);
            this.tsmResetSelection.Text = "Resetuj";
            this.tsmResetSelection.Click += new System.EventHandler(this.tsmResetSelection_Click);
            // 
            // tsmCancel
            // 
            this.tsmCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsmCancel.Image")));
            this.tsmCancel.Name = "tsmCancel";
            this.tsmCancel.Size = new System.Drawing.Size(166, 22);
            this.tsmCancel.Text = "Anuluj";
            this.tsmCancel.Visible = false;
            this.tsmCancel.Click += new System.EventHandler(this.tsmCancel_Click);
            // 
            // tsmMoveToTrash
            // 
            this.tsmMoveToTrash.Image = ((System.Drawing.Image)(resources.GetObject("tsmMoveToTrash.Image")));
            this.tsmMoveToTrash.Name = "tsmMoveToTrash";
            this.tsmMoveToTrash.Size = new System.Drawing.Size(166, 22);
            this.tsmMoveToTrash.Text = "Przenieś do kosza";
            this.tsmMoveToTrash.Visible = false;
            this.tsmMoveToTrash.Click += new System.EventHandler(this.tsmMoveToTrash_Click);
            // 
            // tsmSelectDirectories
            // 
            this.tsmSelectDirectories.Image = ((System.Drawing.Image)(resources.GetObject("tsmSelectDirectories.Image")));
            this.tsmSelectDirectories.Name = "tsmSelectDirectories";
            this.tsmSelectDirectories.Size = new System.Drawing.Size(166, 22);
            this.tsmSelectDirectories.Text = "Wybierz foldery";
            this.tsmSelectDirectories.Click += new System.EventHandler(this.tsmSelectDirectories_Click);
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.Margin = new System.Windows.Forms.Padding(30, 3, 1, 3);
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(150, 17);
            this.tsProgressBar.Visible = false;
            // 
            // tbFilter
            // 
            this.tbFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.tbFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbFilter.Margin = new System.Windows.Forms.Padding(30, 3, 1, 3);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(200, 17);
            this.tbFilter.ToolTipText = "Zaznaczenie wg filtru";
            this.tbFilter.Visible = false;
            this.tbFilter.Enter += new System.EventHandler(this.tbFilter_Enter);
            this.tbFilter.Leave += new System.EventHandler(this.tbFilter_Leave);
            this.tbFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbFilter_KeyUp);
            this.tbFilter.VisibleChanged += new System.EventHandler(this.tbFilter_VisibleChanged);
            // 
            // lStatus
            // 
            this.lStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lStatus.Location = new System.Drawing.Point(0, 0);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(527, 243);
            this.lStatus.TabIndex = 1;
            this.lStatus.Text = "Duplicates v1.0";
            this.lStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvDuplicates
            // 
            this.lvDuplicates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvDuplicates.CheckBoxes = true;
            this.lvDuplicates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFiles});
            this.lvDuplicates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDuplicates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvDuplicates.HideSelection = false;
            this.lvDuplicates.Location = new System.Drawing.Point(0, 0);
            this.lvDuplicates.MultiSelect = false;
            this.lvDuplicates.Name = "lvDuplicates";
            this.lvDuplicates.Size = new System.Drawing.Size(527, 243);
            this.lvDuplicates.TabIndex = 2;
            this.lvDuplicates.UseCompatibleStateImageBehavior = false;
            this.lvDuplicates.View = System.Windows.Forms.View.Details;
            this.lvDuplicates.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvDuplicates_MouseDoubleClick);
            // 
            // chFiles
            // 
            this.chFiles.Text = "Pliki";
            this.chFiles.Width = 507;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 266);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.lvDuplicates);
            this.Controls.Add(this.statusStrip1);
            this.Icon = global::Duplicates.Properties.Resources.Icon;
            this.Name = "MainForm";
            this.Text = "Duplicates";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSplitButton tsActionButton;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmCancel;
        private System.Windows.Forms.ToolStripMenuItem tsmMoveToTrash;
        private System.Windows.Forms.ToolStripMenuItem tsmSelectDirectories;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.ListView lvDuplicates;
        private System.Windows.Forms.ColumnHeader chFiles;
        private System.Windows.Forms.ToolStripTextBox tbFilter;
        private System.Windows.Forms.ToolStripMenuItem tsmSelection;
        private System.Windows.Forms.ToolStripMenuItem tsmSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmReverseSelection;
        private System.Windows.Forms.ToolStripMenuItem tsmResetSelection;
    }
}

