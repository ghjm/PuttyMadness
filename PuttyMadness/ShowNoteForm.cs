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
    public partial class ShowNoteForm : Form
    {
        public ShowNoteForm()
        {
            InitializeComponent();
        }
        public void ShowMessage(string Message, Win32.RECT Rect)
        {
            label1.Text = Message;

            int centerX = (Rect.Left + Rect.Right) / 2;
            int centerY = (Rect.Top + Rect.Bottom) / 2;
            this.Left = centerX - (this.Width / 2);
            this.Top = centerY - (this.Height / 2);

            this.TopMost = true;
            this.Show();

        }
        public void FadeAndClose()
        {
            int show_duration = 2500; // milliseconds
            int fade_duration = 1000;
            int steps = 20;
            var timer = new Timer();
            int cur_step = 0;

            timer.Tick += (sender, e) =>
            {
                timer.Interval = fade_duration / steps;
                this.Opacity = 1 - ((double)cur_step / steps);
                if (cur_step++ > steps)
                {
                    timer.Stop();
                    timer.Dispose();
                    this.Close();
                }
            };

            timer.Interval = show_duration;
            timer.Enabled = true;

        }
    }
}
