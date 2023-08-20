using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Duplicates
{
    public partial class MainForm : Form
    {
        public const string NAME_VERSION = "Duplicates v1.0";
        
        BackgroundWorker bw;
        OperationState operation;

        private delegate void AddItemHandler(string group, string item);
        private AddItemHandler AddItem;
        private delegate void RemoveItemHandler(string item);
        private RemoveItemHandler RemoveItem;

        public MainForm()
        {
            InitializeComponent();

            this.AddItem += new AddItemHandler(AddItemToList);
            this.RemoveItem += new RemoveItemHandler(RemoveItemFromList);

            bw = new BackgroundWorker(this);
            bw.PrepareForWork += new BackgroundWorker.PrepareForWorkHandler(bw_PrepareForWork);
            bw.DoWork += new BackgroundWorker.DoWorkHandler(bw_DoWork);
            bw.ProgressChanged += new BackgroundWorker.ProgressChangedHandler(bw_ProgressChanged);
            bw.WorkCompleted += new BackgroundWorker.WorkCompletedHandler(bw_WorkCompleted);
            bw.WorkAborted += new BackgroundWorker.WorkAbortedHandler(bw_WorkAborted);
            bw.CleanAfterWork += new BackgroundWorker.CleanAfterWorkHandler(bw_CleanAfterWork);

            this.SetActionButton(tsmSelectDirectories);
        }

        private void AddItemToList(string group, string item)
        {
            if (lvDuplicates.Groups[group] == null)
                lvDuplicates.Groups.Add(new ListViewGroup(group, group));

            ListViewItem lvi = new ListViewItem(item, lvDuplicates.Groups[group]);
            lvi.Name = item;
            lvDuplicates.Items.Add(lvi);
        }

        private void RemoveItemFromList(string item)
        {
            ListViewGroup lvg = lvDuplicates.Items[item].Group;
            
            lvDuplicates.Items.RemoveByKey(item);
            
            if (lvg.Items.Count == 1 && !lvg.Items[0].Checked)
                lvg.Items[0].Remove();

            if (lvg.Items.Count == 0)
                lvDuplicates.Groups.Remove(lvg);
        }

        void bw_PrepareForWork(object sender, EventArgs e)
        {
            string text = "Wyszukiwanie duplikatów";
            if (operation == OperationState.Trash)
                text = "Przenoszenie do kosza";

            this.SetStatus(text);

            tsmSelectDirectories.Visible = false;
            tsmMoveToTrash.Visible = false;
            tsmSelection.Visible = false;
            tbFilter.Visible = false;

            lStatus.Visible = true;
            tsmCancel.Visible = true;
            tsProgressBar.Value = 0;
            tsProgressBar.Visible = true;

            lvDuplicates.BeginUpdate();

            this.SetActionButton(tsmCancel);
        }

        void bw_DoWork(object sender, WorkEventsArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            Duplicates d = new Duplicates();

            d.ProgressChangedE += delegate(object s, ProgressChangedEventArgs ea)
            {
                bw.ReportProgress(ea.Percent, ea.State);
            };

            d.ReportErrorE += delegate(object s, ErrorEventArgs ea)
            {
                MessageBox.Show(ea.ex.Message);
            };

            d.FoundDuplicateE += delegate(object s, ItemEventArgs ea)
            {
                this.BeginInvoke(AddItem, new object[] { ea.Group, ea.Item });
            };

            d.MovedToTrashE += delegate(object s, ItemEventArgs ea)
            {
                this.BeginInvoke(RemoveItem, new object[] { ea.Item });
            };

            object[] args = e.Param as object[];
            if (operation == OperationState.Analysis)
                d.Find(args[0] as List<string>, (MethodOfAnalysis)args[1]);
            else
                d.MoveToTrash(args[0] as List<string>);
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if ((OperationState)e.State == OperationState.Finding)
                tsProgressBar.Style = ProgressBarStyle.Marquee;
            else
                tsProgressBar.Style = ProgressBarStyle.Blocks;

            if (e.Percent > 0)
                tsProgressBar.Value = e.Percent;
        }

        void bw_WorkCompleted(object sender, WorkCompletedEventArgs e)
        {
            bool isVisible = false;
            if (lvDuplicates.Items.Count > 0)
            {
                isVisible = true;
                this.SetActionButton(tsmMoveToTrash);
                this.lStatus.Visible = false;
            }
            else
            {
                this.SetActionButton(tsmSelectDirectories);
                this.SetStatus("Brak duplikatów");
            }

            tsmMoveToTrash.Visible = isVisible;
            tsmSelection.Visible = isVisible;
            tbFilter.Visible = isVisible;
        }

        void bw_WorkAborted(object sender, EventArgs e)
        {
            this.SetStatus("Anulowano.");
            this.SetActionButton(tsmSelectDirectories);
        }

        void bw_CleanAfterWork(object sender, EventArgs e)
        {
            lvDuplicates.EndUpdate();

            tsProgressBar.Visible = false;
            tsmSelectDirectories.Visible = true;
            tsmCancel.Visible = false;
        }

        void SetActionButton(ToolStripMenuItem tsmi)
        {
            tsActionButton.Text = tsmi.Text;
            tsActionButton.Image = tsmi.Image;
            tsActionButton.Tag = tsmi;
        }

        private void tsActionButton_Click(object sender, EventArgs e)
        {
            ToolStripSplitButton ts = sender as ToolStripSplitButton;
            (ts.Tag as ToolStripMenuItem).PerformClick();
        }

        void SetStatus(string text)
        {
            lStatus.Text = NAME_VERSION + "\n\nStatus: " + text;
        }

        void FindDuplicates(List<string> dirs, MethodOfAnalysis moa)
        {
            if (dirs.Count == 0)
                return;

            lvDuplicates.BeginUpdate();
            lvDuplicates.Items.Clear();
            lvDuplicates.Groups.Clear();
            lvDuplicates.EndUpdate();

            operation = OperationState.Analysis;
            bw.Run(new object[] {dirs, moa});
        }

        private void tsmSelectDirectories_Click(object sender, EventArgs e)
        {
            SelectDirectoriesForm sdf = new SelectDirectoriesForm();
            if (sdf.ShowDialog() == DialogResult.OK)
            {
                List<string> dirs = new List<string>();
                foreach (object i in sdf.lbDirectories.Items)
                {
                    dirs.Add(i.ToString());
                    Application.DoEvents();
                }
                FindDuplicates(dirs, sdf.AnalysisMethod);
            }
        }

        private void tsmCancel_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy)
                bw.Abort();
        }

        private void tsmMoveToTrash_Click(object sender, EventArgs e)
        {
            if (lvDuplicates.Groups.Count == 0)
                return;

            List<string> files = new List<string>();
            foreach (ListViewItem lvi in lvDuplicates.CheckedItems)
            {
                files.Add(lvi.Text);
                Application.DoEvents();
            }

            operation = OperationState.Trash;
            bw.Run(new object[] { files, null });
        }

        private void tsmAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void lvDuplicates_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right && lvDuplicates.SelectedItems.Count == 1)
                    System.Diagnostics.Process.Start(lvDuplicates.SelectedItems[0].Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmSelectAll_Click(object sender, EventArgs e)
        {
            lvDuplicates.Cursor = Cursors.WaitCursor;
            
            lvDuplicates.BeginUpdate();
            foreach (ListViewItem lvi in lvDuplicates.Items)
            {
                lvi.Checked = true;
                Application.DoEvents();
            }
            lvDuplicates.EndUpdate();

            lvDuplicates.Cursor = Cursors.Default;
        }

        private void tsmReverseSelection_Click(object sender, EventArgs e)
        {
            lvDuplicates.Cursor = Cursors.WaitCursor;

            lvDuplicates.BeginUpdate();
            foreach (ListViewItem lvi in lvDuplicates.Items)
            {
                if (lvi.Checked)
                    lvi.Checked = false;
                else
                    lvi.Checked = true;
                Application.DoEvents();
            }
            lvDuplicates.EndUpdate();

            lvDuplicates.Cursor = Cursors.Default;
        }

        private void tbFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(tbFilter.Text) || e.KeyCode != Keys.Enter)
                return;

            tbFilter.Select(0, 0);
            lvDuplicates.Cursor = Cursors.WaitCursor;

            lvDuplicates.BeginUpdate();
            foreach(ListViewItem lvi in lvDuplicates.Items)
            {
                if (lvi.Text.StartsWith(tbFilter.Text, true, null))
                    lvi.Checked = true;
                Application.DoEvents();
            }
            lvDuplicates.EndUpdate();

            lvDuplicates.Cursor = Cursors.Default;
        }

        private void tbFilter_VisibleChanged(object sender, EventArgs e)
        {
            if (tbFilter.Visible)
            {
                tbFilter.Text = tbFilter.ToolTipText;
                tbFilter.ForeColor = Color.Gray;
            }
            else
                tbFilter.Clear();
        }

        private void tbFilter_Enter(object sender, EventArgs e)
        {
            if (tbFilter.ForeColor == Color.Gray)
            {
                tbFilter.Clear();
                tbFilter.ForeColor = Color.Black;
            }
        }

        private void tbFilter_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbFilter.Text))
            {
                tbFilter.Text = tbFilter.ToolTipText;
                tbFilter.ForeColor = Color.Gray;
            }
        }

        private void tsmResetSelection_Click(object sender, EventArgs e)
        {
            lvDuplicates.Cursor = Cursors.WaitCursor;

            lvDuplicates.BeginUpdate();
            foreach (ListViewItem lvi in lvDuplicates.Items)
            {
                lvi.Checked = false;
                Application.DoEvents();
            }
            lvDuplicates.EndUpdate();

            lvDuplicates.Cursor = Cursors.Default;
        }
    }
}
