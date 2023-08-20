using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Duplicates
{
    public partial class SelectDirectoriesForm : Form
    {
        internal MethodOfAnalysis AnalysisMethod { get; private set; }

        public SelectDirectoriesForm()
        {
            InitializeComponent();
            this.AnalysisMethod = MethodOfAnalysis.Name;
        }

        private void bAddDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                    lbDirectories.Items.Add(fbd.SelectedPath);
            }
        }

        private void bRemoveDirectory_Click(object sender, EventArgs e)
        {
            if (lbDirectories.SelectedIndex >= 0)
                lbDirectories.Items.RemoveAt(lbDirectories.SelectedIndex);
        }

        private void rbAnalysisByName_CheckedChanged(object sender, EventArgs e)
        {
            this.AnalysisMethod = MethodOfAnalysis.Name;
        }

        private void rbAnalysisByContent_CheckedChanged(object sender, EventArgs e)
        {
            this.AnalysisMethod = MethodOfAnalysis.Content;
        }
    }
}
