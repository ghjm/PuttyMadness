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
    public partial class GroupListForm : Form
    {
        public GroupListForm()
        {
            InitializeComponent();
        }

        public void LoadGroups()
        {
            listBox1.Items.Clear();
            foreach (string key in GlobalData.Instance.GroupList.Keys)
            {
                var nt = new KeyValuePair<string, GroupDetail>(key, GlobalData.Instance.GroupList[key]);
                listBox1.Items.Add(nt);
            }
        }

        public void SaveGroups()
        {
            GlobalData.Instance.GroupList.Clear();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                var nt = (KeyValuePair<string, GroupDetail>)listBox1.Items[i];
                GlobalData.Instance.GroupList.Add(nt.Key, nt.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ngf = new NewGroupForm();
            if (ngf.ShowDialog() == DialogResult.OK)
            {
                var gd = new GroupDetail();
                ngf.SaveWindowsToGroupDetail(gd);
                var nt = new KeyValuePair<string, GroupDetail>(txtNewGroupName.Text, gd);
                listBox1.SelectedIndex = listBox1.Items.Add(nt);
                SaveGroups();
                GlobalData.Instance.ToRegistry();
            }
            txtNewGroupName.Text = "";
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if ((e.Index >= 0) && (e.Index < listBox1.Items.Count)) {
                var nt = (KeyValuePair<string, GroupDetail>)listBox1.Items[e.Index];
                e.DrawBackground();
                e.Graphics.DrawString(nt.Key, Control.DefaultFont, Brushes.Black, e.Bounds);
                e.DrawFocusRectangle();
            }
        }

        private void GroupListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.Location);
            var nt = (KeyValuePair<string, GroupDetail>)listBox1.Items[index];
            ConnectToHost.Instance.Connect_To_Group(nt.Value);
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((listBox1.SelectedIndex >= 0) && (listBox1.SelectedIndex < listBox1.Items.Count) &&
                (e.KeyCode == Keys.Delete))
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                SaveGroups();
                GlobalData.Instance.ToRegistry();
            }
        }
    }
}
