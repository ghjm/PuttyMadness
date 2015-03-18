using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuttyMadness
{
    public partial class MainFrm : Form
    {
        private bool Loaded = false;
        private CustomApplicationContext context;

        public MainFrm(CustomApplicationContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            var ke = new KeysConverter();
            textBox1.Text = ke.ConvertToString(context.HotkeyKey);
            checkBox1.Checked = context.LaunchOnLogin;
            Loaded = true;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            context.HotkeyEnabled = false;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            context.HotkeyEnabled = true;
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            context.HotkeyEnabled = true;
        }

        private void MainFrm_Deactivate(object sender, EventArgs e)
        {
            context.HotkeyEnabled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            var ke = new KeysConverter();
            textBox1.Text = ke.ConvertToString(e.KeyData);
            context.HotkeyKey = e.KeyData;
            context.SaveToRegistry();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Loaded)
            {
                context.LaunchOnLogin = checkBox1.Checked;
                context.SaveToRegistry();
            }
        }
    }
}
