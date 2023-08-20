using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using Microsoft.VisualBasic.FileIO;

namespace Duplicates
{
    enum MethodOfAnalysis { Name, Content };
    enum OperationState { Finding, Analysis, Trash};

    class ErrorEventArgs : EventArgs
    {
        public Exception ex { get; private set; }

        public ErrorEventArgs(Exception e)
        {
            this.ex = e;
        }
    }

    class ItemEventArgs : EventArgs
    {
        public string Group { get; private set; }
        public string Item { get; private set; }

        public ItemEventArgs(string group, string item)
        {
            this.Group = group;
            this.Item = item;
        }
    }

    class Duplicates
    {
        public delegate void ProgressChangedHandler(object sender, ProgressChangedEventArgs e);
        public event ProgressChangedHandler ProgressChangedE;

        public delegate void ReportErrorHandler(object sender, ErrorEventArgs e);
        public event ReportErrorHandler ReportErrorE;

        public delegate void FoundDuplicateHandler(object sender, ItemEventArgs e);
        public event FoundDuplicateHandler FoundDuplicateE;

        public delegate void MovedToTrashHandler(object sender, ItemEventArgs e);
        public event MovedToTrashHandler MovedToTrashE;

        private delegate string AnalysisMethodHandler(string filename);
        private AnalysisMethodHandler AnalysisMethod;

        private void ReportProgress(int percent, object state)
        {
            if (this.ProgressChangedE != null)
                this.ProgressChangedE(this, new ProgressChangedEventArgs(percent, state));
        }

        private void ReportError(Exception ex)
        {
            if (this.ReportErrorE != null)
                this.ReportErrorE(this, new ErrorEventArgs(ex));
        }

        private void ReportDuplicateFound(string group, string item)
        {
            if (this.FoundDuplicateE != null)
                this.FoundDuplicateE(this, new ItemEventArgs(group, item));
        }

        private void ReportFileMovedToTrash(string group, string item)
        {
            if (this.MovedToTrashE != null)
                this.MovedToTrashE(this, new ItemEventArgs(group, item));
        }

        private int Percent(int i, int count)
        {
            return i * 100 / count;
        }

        private void SetAnalysisMethod(MethodOfAnalysis moa)
        {
            switch (moa)
            {
                case MethodOfAnalysis.Content:
                    this.AnalysisMethod = new AnalysisMethodHandler(AnalysisByContent);
                    break;
                default:
                    this.AnalysisMethod = new AnalysisMethodHandler(AnalysisByName);
                    break;
            }
        }

        private string AnalysisByName(string filename)
        {
            return Path.GetFileName(filename);
        }

        private string AnalysisByContent(string filename)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] value = md5.ComputeHash(f);
            f.Close();

            StringBuilder sb = new StringBuilder();
            foreach (byte b in value)
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }

        private List<string> GetFiles(List<string> dirs)
        {
            this.ReportProgress(0, OperationState.Finding);

            List<string> result = new List<string>();

            foreach (string dir in dirs)
            {
                try
                {
                    result.AddRange(Directory.GetFiles(dir, "*", System.IO.SearchOption.AllDirectories));
                }
                catch (UnauthorizedAccessException) { }
            }

            return result;
        }

        private void Analysis(List<string> files)
        {
            Dictionary<string, string> duplicates = new Dictionary<string, string>();
            
            for (int i = 0; i < files.Count; i++)
            {
                this.ReportProgress(this.Percent(i, files.Count), OperationState.Analysis);

                string key = this.AnalysisMethod(files[i]);

                if (!duplicates.ContainsKey(key))
                {
                    duplicates.Add(key, files[i]);
                }
                else
                {
                    if (duplicates[key] != String.Empty)
                    {
                        this.ReportDuplicateFound(key, duplicates[key]);
                        duplicates[key] = String.Empty;
                    }
                    this.ReportDuplicateFound(key, files[i]);
                }
            }
        }

        public void Find(List<string> dirs, MethodOfAnalysis moa)
        {
            this.SetAnalysisMethod(moa);
            this.Analysis(this.GetFiles(dirs));
        }

        public void MoveToTrash(List<string> files)
        {
            for (int i = 0; i < files.Count; i++)
            {
                try
                {
                    FileSystem.DeleteFile(files[i], UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    this.ReportFileMovedToTrash(String.Empty, files[i]);
                }
                catch (Exception) { }
                this.ReportProgress(this.Percent(i, files.Count), OperationState.Trash);
            }
        }
    }
}