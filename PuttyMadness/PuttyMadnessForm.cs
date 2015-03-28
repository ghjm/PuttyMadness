using System;
using System.Collections;
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
    public partial class PuttyMadnessForm : Form
    {
        public PuttyMadnessForm()
        {
            InitializeComponent();
            GlobalData.Instance.FromRegistry();
            UpdateAutoComplete();
        }

        public void UpdateAutoComplete()
        {
            textBox1.AutoCompleteCustomSource = GlobalData.Instance.ToACSC();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (textBox1.Text == "")
                {
                    e.SuppressKeyPress = true;
                    Application.Exit();
                }
                else
                {
                    e.SuppressKeyPress = true;
                    textBox1.Text = "";
                }
            }
        }

        private void Create_New_Host(string host)
        {
            var hdf = new HostDetailForm();
            hdf.InitFromObject(host, null);
            hdf.AcceptButton = hdf.btnJustConnect;
            var dlg_result = hdf.ShowDialog();
            if (dlg_result != System.Windows.Forms.DialogResult.Cancel)
            {
                var hd = hdf.SaveToObject();
                if (dlg_result == System.Windows.Forms.DialogResult.OK)
                {
                    GlobalData.Instance.HostList.Add(hdf.Hostname(), hd);
                    GlobalData.Instance.ToRegistry();
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                if (textBox1.Text == "")
                {
                    return;
                }
                else if (textBox1.Text.EndsWith(" (group)"))
                {
                    string GroupName = textBox1.Text.Remove(textBox1.Text.LastIndexOf(" (group)"));
                    GroupDetail gd = null;
                    foreach (string key in GlobalData.Instance.GroupList.Keys)
                    {
                        if (key.ToLower() == GroupName.ToLower())
                        {
                            gd = GlobalData.Instance.GroupList[key];
                        }
                    }
                    if (gd != null)
                    {
                        ConnectToHost.Instance.Connect_To_Group(gd);
                    }
                    else
                    {
                        MessageBox.Show("No such group: " + GroupName);
                    }
                }
                else
                {
                    if (GlobalData.Instance.HostList.ContainsKey(textBox1.Text.ToLower()))
                    {
                        ConnectToHost.Instance.Connect_To_Host(textBox1.Text, GlobalData.Instance.HostList[textBox1.Text.ToLower()]);
                    }
                    else
                    {
                        Create_New_Host(textBox1.Text);
                    }
                }
            }
            else if ((e.KeyCode == Keys.E) && (e.Alt))
            {
                e.Handled = true;
                if (GlobalData.Instance.HostList.ContainsKey(textBox1.Text))
                {
                    var hd = GlobalData.Instance.HostList[textBox1.Text];
                    var hdf = new HostDetailForm();
                    hdf.InitFromObject(textBox1.Text, hd);
                    if (hdf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        var newhost = hdf.Hostname();
                        if (newhost == textBox1.Text)
                        {
                            GlobalData.Instance.HostList[textBox1.Text] = hdf.SaveToObject();
                        }
                        else
                        {
                            GlobalData.Instance.HostList.Remove(textBox1.Text);
                            GlobalData.Instance.HostList.Add(newhost, hdf.SaveToObject());
                            textBox1.Text = newhost;
                        }
                        GlobalData.Instance.ToRegistry();
                    }
                }
                else
                {
                    button1_Click(sender, e);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ehf = new EditHostsForm();
            ehf.LoadHosts();
            ehf.PositionToPartialHost(textBox1.Text);
            ehf.ShowDialog();
            UpdateAutoComplete();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CenterFormOnMe(Form form)
        {
            Point StartLoc = this.Location;
            StartLoc.X -= (form.Size.Width - this.Size.Width) / 2;
            StartLoc.Y -= (form.Size.Height - this.Size.Height) / 2;
            form.Location = StartLoc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var gwf = new GroupListForm();
            CenterFormOnMe(gwf);
            gwf.LoadGroups();
            gwf.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var khf = new KeyHookForm();
            CenterFormOnMe(khf);
            khf.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sf = new KnownKeysForm();
            sf.LoadKeys();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                sf.SaveKeys();
                GlobalData.Instance.ToRegistry();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            using (var af = new AboutForm())
            {
                af.ShowDialog();
            }
        }

    }
}
