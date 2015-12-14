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
    public partial class HostDetailForm : Form
    {
        public HostDetailForm()
        {
            InitializeComponent();
        }

        public bool Initializing = false;

        public void InitFromObject(string Hostname, HostDetail Hostinfo)
        {
            Initializing = true;
            try
            {
                textHostname.Text = Hostname;
                if (Hostinfo == null)
                {
                    ActiveControl = textUsername;
                }
                else
                {
                    textUsername.Text = Hostinfo.Username;
                    textRequiredKey.Text = Hostinfo.RequiredKey;
                    textJumpHost.Text = Hostinfo.JumpHost;
                    textJumpCmd.Text = Hostinfo.JumpCmd;
                    textOverrideIP.Text = Hostinfo.OverrideIP;
                    textOverridePort.Text = Hostinfo.OverridePort;
                    textNote.Text = Hostinfo.Note;
                }
            }
            finally
            {
                Initializing = false;
            }
        }

        public HostDetail SaveToObject()
        {
            var Hostinfo = new HostDetail();
            Hostinfo.Username = textUsername.Text;
            Hostinfo.RequiredKey = textRequiredKey.Text;
            Hostinfo.JumpHost = textJumpHost.Text;
            Hostinfo.JumpCmd = textJumpCmd.Text;
            Hostinfo.OverrideIP = textOverrideIP.Text;
            Hostinfo.OverridePort = textOverridePort.Text;
            Hostinfo.Note = textNote.Text;
            return Hostinfo;
        }

        public string Hostname()
        {
            return textHostname.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fsk = new SelectKeyForm();
            if ((fsk.ShowDialog() == DialogResult.OK) && (fsk.SelectedKey.Length > 0))
            {
                textRequiredKey.Text = fsk.SelectedKey;
            }
        }

        private void textChanged(object sender, EventArgs e)
        {
            if (!Initializing)
            {
                btnJustConnect.Text = @"Save && &Connect";
                btnJustConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnJustConnect_Click(object sender, EventArgs e)
        {
            ConnectToHost.Instance.Connect_To_Host(this.Hostname(), this.SaveToObject());
        }

    }
}
