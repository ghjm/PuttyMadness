using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuttyMadness
{
    public partial class EditHostsForm : Form
    {
        public EditHostsForm()
        {
            InitializeComponent();
        }
        public void LoadHosts()
        {
            listBox1.Items.Clear();
            foreach (var host in GlobalData.Instance.HostList.Keys)
            {
                listBox1.Items.Add(host);
            }
        }
        public void PositionToPartialHost(string host)
        {
            if (listBox1.Items.Count <= 0)
                return;
            int i = 0;
            while ((i < listBox1.Items.Count) && (String.Compare(listBox1.Items[i].ToString(), host) < 0))
                i++;
            listBox1.SelectedIndex = i;
        }
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                editToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                deleteToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if ((e.KeyCode == Keys.C) && (e.Alt))
            {
                var host = listBox1.Items[listBox1.SelectedIndex].ToString();
                var hd = GlobalData.Instance.HostList[host];
                ConnectToHost.Instance.Connect_To_Host(host, hd);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((listBox1.SelectedIndex >= 0) && (GlobalData.Instance != null))
            {
                var host = listBox1.Items[listBox1.SelectedIndex].ToString();
                var hd = GlobalData.Instance.HostList[host];
                var hdf = new HostDetailForm();
                hdf.InitFromObject(host, hd);
                if (hdf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var newhost = hdf.Hostname();
                    if (newhost == host)
                    {
                        GlobalData.Instance.HostList[host] = hdf.SaveToObject();
                    }
                    else
                    {
                        GlobalData.Instance.HostList.Remove(host);
                        GlobalData.Instance.HostList.Add(newhost, hdf.SaveToObject());
                        listBox1.Items[listBox1.SelectedIndex] = newhost;
                    }
                    GlobalData.Instance.ToRegistry();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                var host = listBox1.Items[listBox1.SelectedIndex].ToString();
                listBox1.Items.Remove(host);
                GlobalData.Instance.HostList.Remove(host);
                GlobalData.Instance.ToRegistry();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hdf = new HostDetailForm();
            if (hdf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GlobalData.Instance.HostList.Add(hdf.Hostname(), hdf.SaveToObject());
                listBox1.Items.Add(hdf.Hostname());
                GlobalData.Instance.ToRegistry();
            }
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                var host = listBox1.Items[listBox1.SelectedIndex].ToString();
                var hd = GlobalData.Instance.HostList[host];
                var hdf = new HostDetailForm();
                hdf.InitFromObject(host, hd);
                if (hdf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var newhost = hdf.Hostname();
                    if (listBox1.Items.Contains(newhost))
                    {
                        throw new ApplicationException("Host named " + newhost + " is already in the list.");
                    }
                    else
                    {
                        GlobalData.Instance.HostList.Add(newhost, hdf.SaveToObject());
                        listBox1.Items.Insert(listBox1.SelectedIndex+1, newhost);
                        GlobalData.Instance.ToRegistry();
                    }
                }
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int idx = listBox1.IndexFromPoint(new Point(e.X, e.Y));
            if (idx >= 0)
                listBox1.SelectedIndex = idx;
        }

    }
}
