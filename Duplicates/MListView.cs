using System.Collections;
using System.Collections.Generic;

namespace System.Windows.Forms
{
    class MListView : ListView
    {

        public void CheckAllItems(bool check)
        {
            foreach (ListViewItem lvi in this.Items)
            {
                lvi.Checked = check;
                Application.DoEvents();
            }
        }
        
        public void AddItems(Dictionary<string, List<string>> items)
        {
            foreach (string k in items.Keys)
            {
                ListViewGroup lvg = new ListViewGroup(k);
                this.Groups.Add(lvg);

                foreach (string v in items[k])
                {
                    this.Items.Add(new ListViewItem(v, lvg));
                    Application.DoEvents();
                }
            }
        }

        private void HClear(IList list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                list.RemoveAt(i);
                Application.DoEvents();
            }
        }

        public void ClearGroups()
        {
            this.HClear(this.Groups);
        }

        public void ClearItems()
        {
            this.HClear(this.Items);
        }
    }
}
