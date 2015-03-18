using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuttyMadness
{
    public partial class PuttySelectorPanel : UserControl
    {
        public PuttySelectorPanel()
        {
            InitializeComponent();
        }

        private void PuttySelectorPanel_Load(object sender, EventArgs e)
        {
            btnRescan_Click(sender, e);
        }

        [Description("Available Items Title"), Category("Appearance")]
        public string AvailableItemsTitle
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        [Description("Selected Items Title"), Category("Appearance")]
        public string SelectedItemsTitle
        {
            get { return label2.Text; }
            set { label2.Text = value; }
        }

        private bool _RecognizedWindowsOnly = false;
        [Description("Show Recognized Windows Only"), Category("Behavior")]
        public bool RecognizedWindowsOnly
        {
            get { return _RecognizedWindowsOnly; }
            set { _RecognizedWindowsOnly = value; }
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            listAvailable.Items.Clear();
            var pws = PuttyWindows.GetPuttyWindows(_RecognizedWindowsOnly);
            foreach (PuttyWindow pw in pws)
            {
                listAvailable.Items.Add(pw);
            }
        }

        private void MoveSelected(ListBox source, ListBox dest)
        {
            var to_move = new List<object>();
            foreach (object o in source.SelectedItems)
                to_move.Add(o);
            foreach (object o in to_move)
            {
                source.Items.Remove(o);
                dest.Items.Add(o);
            }
        }

        public void SelectAll()
        {
            MoveAll(listAvailable, listSelected);
        }

        public void RemoveAll()
        {
            MoveAll(listSelected, listAvailable);
        }

        private void MoveAll(ListBox source, ListBox dest)
        {
            foreach (object o in source.Items)
            {
                dest.Items.Add(o);
            }
            source.Items.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MoveSelected(listAvailable, listSelected);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            MoveSelected(listSelected, listAvailable);
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            RemoveAll();
        }
    }
}
