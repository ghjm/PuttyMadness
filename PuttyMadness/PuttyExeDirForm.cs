using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PuttyMadness
{
    public partial class PuttyExeDirForm : Form
    {
        public PuttyExeDirForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.chiark.greenend.org.uk/~sgtatham/putty/download.html");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                lblPath.Text = Path.GetDirectoryName(openFileDialog1.FileName);
        }

    }
}
