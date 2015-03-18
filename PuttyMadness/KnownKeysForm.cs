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
    public partial class KnownKeysForm : Form
    {
        public KnownKeysForm()
        {
            InitializeComponent();
        }

        public void LoadKeys()
        {
            lstKeys.Items.Clear();
            foreach (string key in GlobalData.Instance.KeyList.Keys)
            {
                var nt = new KeyValuePair<string, KeyDetail>(key, GlobalData.Instance.KeyList[key]);
                lstKeys.Items.Add(nt);
            }
        }

        public void SaveKeys()
        {
            GlobalData.Instance.KeyList.Clear();
            for (int i = 0; i < lstKeys.Items.Count; i++)
            {
                var nt = (KeyValuePair<string, KeyDetail>)lstKeys.Items[i];
                GlobalData.Instance.KeyList.Add(nt.Key, nt.Value);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((sender == rbnPPK) || (sender == rbnRemoteKey)) && (sender as RadioButton).Checked)
            {
                txtPPK.Enabled = (sender == rbnPPK);
                btnPPKOpen.Enabled = (sender == rbnPPK);
                txtRemoteHost.Enabled = (sender == rbnRemoteKey);
                txtRemoteCommand.Enabled = (sender == rbnRemoteKey);
                if (rbnPPK.Checked)
                {
                    txtRemoteHost.Text = "";
                    txtRemoteCommand.Text = "";
                }
                else if (rbnRemoteKey.Checked)
                {
                    txtPPK.Text = "";
                }
            }
        }

        private void btnAddKey_Click(object sender, EventArgs e)
        {
            var nt = new KeyValuePair<string, KeyDetail>(txtAddKey.Text, new KeyDetail());
            (nt.Value as KeyDetail).IsRemote = false;
            lstKeys.SelectedIndex = lstKeys.Items.Add(nt);
            txtAddKey.Text = "";
        }

        private void txtAddKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAddKey_Click(sender, e);
                e.Handled = true;
            }
        }

        private bool FieldsUpdating = false;

        private void lstKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            FieldsUpdating = true;
            try
            {
                if ((lstKeys.SelectedIndex >= 0) && (lstKeys.SelectedIndex < lstKeys.Items.Count))
                {
                    var nt = (KeyValuePair<string, KeyDetail>)lstKeys.Items[lstKeys.SelectedIndex];
                    rbnPPK.Checked = !nt.Value.IsRemote;
                    rbnRemoteKey.Checked = nt.Value.IsRemote;
                    if (nt.Value.IsRemote)
                    {
                        txtRemoteHost.Text = nt.Value.RemoteHost;
                        txtRemoteCommand.Text = nt.Value.RemoteCommand;
                        txtPPK.Text = "";
                    }
                    else
                    {
                        txtPPK.Text = nt.Value.PPKFile;
                        txtRemoteHost.Text = "";
                        txtRemoteCommand.Text = "";
                    }
                }
                else
                {
                    rbnPPK.Checked = false;
                    rbnRemoteKey.Checked = false;
                    txtPPK.Text = "";
                    txtRemoteHost.Text = "";
                    txtRemoteCommand.Text = "";
                }
            }
            finally
            {
                FieldsUpdating = false;
            }
        }

        private void KeyDetailTextChanged(object sender, EventArgs e)
        {
            if ((!FieldsUpdating) && (lstKeys.SelectedIndex >= 0) && (lstKeys.SelectedIndex < lstKeys.Items.Count))
            {
                var nt = (KeyValuePair<string, KeyDetail>)lstKeys.Items[lstKeys.SelectedIndex];
                nt.Value.IsRemote = (rbnRemoteKey.Checked);
                if (rbnPPK.Checked)
                {
                    nt.Value.PPKFile = txtPPK.Text;
                }
                else
                {
                    nt.Value.PPKFile = "";
                }
                if (rbnRemoteKey.Checked)
                {
                    nt.Value.RemoteHost = txtRemoteHost.Text;
                    nt.Value.RemoteCommand = txtRemoteCommand.Text;
                }
                else
                {
                    nt.Value.RemoteHost = "";
                    nt.Value.RemoteCommand = "";
                }
            }
        }

        private void lstKeys_DrawItem(object sender, DrawItemEventArgs e)
        {
            var nt = (KeyValuePair<string, KeyDetail>)lstKeys.Items[e.Index];
            e.DrawBackground();
            e.Graphics.DrawString(nt.Key, Control.DefaultFont, Brushes.Black, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void lstKeys_KeyDown(object sender, KeyEventArgs e)
        {
            if ((lstKeys.SelectedIndex >= 0) && (lstKeys.SelectedIndex < lstKeys.Items.Count) &&
                (e.KeyCode == Keys.Delete))
                lstKeys.Items.RemoveAt(lstKeys.SelectedIndex);
        }

        private void btnPPKOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtPPK.Text = openFileDialog1.FileName;
        }

    }
}
