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
    public partial class SelectKeyForm : Form
    {
        public string SelectedKey = "";

        public SelectKeyForm()
        {
            InitializeComponent();
        }

        private void SelectKeyForm_Load(object sender, EventArgs e)
        {
            foreach (var key in GlobalData.Instance.KeyList.Keys)
                listBox1.Items.Add(key);
            foreach (var key in PageantInterface.GetPageantKeys())
                if (!listBox1.Items.Contains(key))
                    listBox1.Items.Add(key);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
                SelectedKey = listBox1.Items[listBox1.SelectedIndex].ToString();
            DialogResult = DialogResult.OK;
        }
    }
}
