using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Duplicates
{
    class WorkEventsArgs : EventArgs
    {
        public object Param { get; private set; }
        public object Result { get; set; }

        public WorkEventsArgs(object param)
        {
            this.Param = param;
        }
    }

    class ProgressChangedEventArgs : EventArgs
    {
        public int Percent { get; private set; }
        public object State { get; private set; }

        public ProgressChangedEventArgs(int percent, object state)
        {
            Percent = percent;
            State = state;
        }
    }

    class WorkCompletedEventArgs : EventArgs
    {
        public object Result { get; set; }
        
        public WorkCompletedEventArgs(object r)
        {
            this.Result = r;
        }
    }

    class BackgroundWorker
    {
        private Thread t;
        private Form f;

        public delegate void PrepareForWorkHandler(object sender, EventArgs e);
        public event PrepareForWorkHandler PrepareForWork;

        public delegate void DoWorkHandler(object sender, WorkEventsArgs e);
        public event DoWorkHandler DoWork;

        public delegate void WorkCompletedHandler(object sender, WorkCompletedEventArgs e);
        public event WorkCompletedHandler WorkCompleted;

        public delegate void WorkAbortedHandler(object sender, EventArgs e);
        public event WorkAbortedHandler WorkAborted;
 
        public delegate void ProgressChangedHandler(object sender, ProgressChangedEventArgs e);
        public event ProgressChangedHandler ProgressChanged;

        public delegate void CleanAfterWorkHandler(object sender, EventArgs e);
        public event CleanAfterWorkHandler CleanAfterWork;

        public bool IsBusy { get { if (t != null) return t.IsAlive; return false; } }

        public BackgroundWorker(Form f)
        {
            this.f = f;
        }

        public void Run(object param)
        {
            if (t != null && t.IsAlive)
                return;

            ParameterizedThreadStart ts = new ParameterizedThreadStart(Work);
            t = new Thread(ts);
            t.IsBackground = true;
            t.Start(param);
        }

        public void Abort()
        {
            if (t == null && !t.IsAlive)
                return;
            
            t.Abort();
        }

        private void Work(object param)
        {
            try
            {
                f.BeginInvoke(PrepareForWork, new object[] { this, new EventArgs() });

                WorkEventsArgs we = new WorkEventsArgs(param);
                this.DoWork(this, we);

                f.BeginInvoke(WorkCompleted, new object[] { this, new WorkCompletedEventArgs(we.Result) });
            }
            catch (ThreadAbortException)
            {
                f.BeginInvoke(WorkAborted, new object[] { this, new EventArgs() });
            }
            finally
            {
                f.BeginInvoke(CleanAfterWork, new object[] { this, new EventArgs() });
            }
        }

        public void ReportProgress(int percent, object state)
        {
            f.BeginInvoke(ProgressChanged, new object[] { this, new ProgressChangedEventArgs(percent, state) }); 
        }
    }
}