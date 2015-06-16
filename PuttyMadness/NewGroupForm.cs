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
    public partial class NewGroupForm : Form
    {
        public void SaveWindowsToGroupDetail(GroupDetail gd)
        {
            gd.Members.Clear();
            foreach (PuttyWindow pw in puttySelectorPanel1.listSelected.Items)
            {
                var gm = new GroupMember();
                gm.Hostname = WindowPersist.Instance.GetHostNameForWindow(pw.hWnd);
                // Should prompt user for hostname here if == ""
                gm.Left = pw.Left;
                gm.Top = pw.Top;
                gm.Width = pw.Width;
                gm.Height = pw.Height;
                gd.Members.Add(gm);
            }
        }
        public NewGroupForm()
        {
            InitializeComponent();
        }
    }
}
