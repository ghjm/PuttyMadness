using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PuttyMadness
{
    public partial class KeyHookForm : Form
    {
        public KeyHookForm()
        {
            InitializeComponent();
        }

        private bool Shift_State;
        private bool Control_State;
        private bool Alt_State;

        private void OnKeyEvent(bool keydown, KeyEventArgs ke)
        {
            // First, make sure focus is still on a selected Putty window
            var fg_hWnd = Win32.GetForegroundWindow();
            bool focus_ok = false;
            foreach (PuttyWindow pw in puttySelectorPanel1.listSelected.Items)
            {
                if (pw.hWnd == fg_hWnd)
                    focus_ok = true;
            }

            // Focus is bad, let the message go to the focused window and
            // we will turn keyboard capture off
            if (!focus_ok)
            {
                cbxCapture.Checked = false;
                return;
            }

            // Focus is good, we're going to process the message
            ke.SuppressKeyPress = true;

            // Check if this is a modifier key
            bool StateChange = false;
            var keystates = new byte[256];
            if (ke.KeyCode == Keys.ShiftKey || ke.KeyCode == Keys.LShiftKey || ke.KeyCode == Keys.RShiftKey)
            {
                StateChange = true;
                Shift_State = keydown;
            }
            if (ke.KeyCode == Keys.ControlKey || ke.KeyCode == Keys.LControlKey || ke.KeyCode == Keys.RControlKey)
            {
                StateChange = true;
                Control_State = keydown;
            }
            if (ke.KeyCode == Keys.Menu || ke.KeyCode == Keys.Alt)
            {
                StateChange = true;
                Alt_State = keydown;
            }

            // Send key states and keystroke to each Putty window
            var CurrentThread = Win32.GetCurrentThreadId();
            foreach (PuttyWindow pw in puttySelectorPanel1.listSelected.Items)
            {
                if (StateChange)
                {
                    var PuttyThread = Win32.GetWindowThreadProcessId(pw.hWnd, IntPtr.Zero);
                    Win32.AttachThreadInput((IntPtr)CurrentThread, (IntPtr)PuttyThread, true);
                    try
                    {
                        Win32.GetKeyboardState(keystates);
                        keystates[(byte)Keys.ShiftKey] = (byte)(Shift_State ? 1 : 0);
                        keystates[(byte)Keys.ControlKey] = (byte)(Control_State ? 1 : 0);
                        keystates[(byte)Keys.Menu] = (byte)(Alt_State ? 1 : 0);
                        Win32.SetKeyboardState(keystates);
                    }
                    finally
                    {
                        Win32.AttachThreadInput((IntPtr)CurrentThread, (IntPtr)PuttyThread, false);
                    }
                }
                if (keydown)
                    Win32.PostMessage(pw.hWnd, Win32.WM_KEYDOWN, (IntPtr)ke.KeyValue, (IntPtr)0);
            }

        }

        private void OnKeyDown(object sender, EventArgs e)
        {
            OnKeyEvent(true, (KeyEventArgs)e);
        }

        private void OnKeyUp(object sender, EventArgs e)
        {
            OnKeyEvent(false, (KeyEventArgs)e);
        }

        private void cbxCapture_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCapture.Checked)
            {
                KeyboardHook.SetHook();
                for (int i = puttySelectorPanel1.listSelected.Items.Count - 1; i >= 0; i--)
                {
                    var pw = (PuttyWindow)puttySelectorPanel1.listSelected.Items[i];
                    Win32.WaitForInputIdle((IntPtr)Win32.GetWindowProcessId(pw.hWnd), 100);
                    Win32.ForceForegroundWindow(pw.hWnd);
                    Thread.Sleep(1);
                }
            }
            else
            {
                KeyboardHook.RemoveHook();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.A))
            {
                puttySelectorPanel1.SelectAll();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.K))
            {
                cbxCapture.Checked = true;
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                KeyHookForm_FormClosed(this, null);
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        private void KeyHookForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            KeyboardHook.RemoveHook();
            Application.Exit();
        }

        private void KeyHookForm_Load(object sender, EventArgs e)
        {
            KeyboardHook.OnKeyDown += OnKeyDown;
            KeyboardHook.OnKeyUp += OnKeyUp;
        }

    }
}
