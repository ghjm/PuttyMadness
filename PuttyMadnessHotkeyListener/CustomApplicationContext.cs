using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace PuttyMadness
{

    public class CustomApplicationContext : ApplicationContext
    {
        public bool HotkeyEnabled = true;
        public Keys HotkeyKey = Keys.Control | Keys.Alt | Keys.P;
        public bool LaunchOnLogin = true;

        private NotifyIcon notifyIcon;
        private MainFrm mainFrm;

        public CustomApplicationContext()
        {
            InitializeContext();
        }

        private void InitializeContext()
        {
            notifyIcon = new NotifyIcon()
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location),
                Text = "Putty Madness Hotkey Listener",
                Visible = true
            };

            notifyIcon.DoubleClick += notifyIcon_DoubleClick;

            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripMenuItem("&Settings...", null, notifyIcon_DoubleClick));
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripMenuItem("E&xit", null, exitItem_Click));

            KeyboardHook.SetHook();
            KeyboardHook.OnKeyDown += OnKeyDown;

            LoadFromRegistry();

        }

        public void LoadFromRegistry()
        {
            var hkcu = Microsoft.Win32.Registry.CurrentUser;
            var rk = hkcu.OpenSubKey(@"Software\PuttyMadness");
            if (rk == null)
            {
                notifyIcon_DoubleClick(this, null);
            }
            else
            {
                var kc = new KeysConverter();
                string HotkeyStr = rk.GetValue("Hotkey", kc.ConvertToString(HotkeyKey)).ToString();
                HotkeyKey = (Keys)kc.ConvertFromString(HotkeyStr);
            }
            rk = hkcu.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            LaunchOnLogin = (rk.GetValue("PuttyMadness") != null);
        }

        public void SaveToRegistry()
        {
            var hkcu = Microsoft.Win32.Registry.CurrentUser;
            var rk = hkcu.CreateSubKey(@"Software\PuttyMadness");
            var kc = new KeysConverter();
            string HotkeyStr = kc.ConvertToString(HotkeyKey);
            rk.SetValue("Hotkey", HotkeyStr);
            rk = hkcu.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (LaunchOnLogin)
            {
                rk.SetValue("PuttyMadness", Application.ExecutablePath);
            }
            else
            {
                object existing = rk.GetValue("PuttyMadness");
                if (existing != null)
                    rk.DeleteValue("PuttyMadness");
            }
            LaunchOnLogin = (rk.GetValue("PuttyMadness") != null);
        }

        private void LaunchPuttyMadness()
        {
            string exedir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string pm = "PuttyMadness.exe";
            string pm_filename = Path.Combine(exedir, pm);
            Process proc = null;
            if (File.Exists(pm_filename))
            {
                proc = Process.Start(pm_filename);
            }
            else
            {
                // Maybe we're running under Visual Studio
                pm_filename = Path.Combine(
                    Directory.GetParent(
                        Directory.GetParent(
                            Directory.GetParent(exedir).FullName
                        ).FullName
                    ).FullName,
                    "PuttyMadness", "bin", "Debug", pm);
                if (File.Exists(pm_filename))
                {
                    proc = Process.Start(pm_filename);
                }
                else
                {
                    pm_filename = Path.Combine(
                        Directory.GetParent(
                            Directory.GetParent(
                                Directory.GetParent(exedir).FullName
                            ).FullName
                        ).FullName,
                        "PuttyMadness", "bin", "Release", pm);
                    if (File.Exists(pm_filename))
                    {
                        proc = Process.Start(pm_filename);
                    }
                }
            }
            if (proc != null)
            {
                Win32.WaitForInputIdle(proc.Handle, 500);
                var start = Environment.TickCount;
                while ((proc.MainWindowHandle == (IntPtr)0) && (Environment.TickCount - start < 500))
                {
                    System.Threading.Thread.Sleep(50);
                    proc.Refresh();
                }
                if (proc.MainWindowHandle != (IntPtr)0) 
                {
                    Win32.ForceForegroundWindow(proc.MainWindowHandle);
                }
            }
        }

        private void OnKeyDown(object sender, EventArgs e)
        {
            var ke = (KeyEventArgs)e;
            if (HotkeyEnabled && ke.KeyData == HotkeyKey)
            {
                LaunchPuttyMadness();
                ke.Handled = true;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (mainFrm == null)
            {
                mainFrm = new MainFrm(this);
                mainFrm.Closed += mainFrm_Closed;
                mainFrm.Show();
            }
            else
            {
                mainFrm.Activate();
            }
        }

        private void mainFrm_Closed(object sender, EventArgs e)
        {
            mainFrm = null;
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            ExitThread();
        }

        protected override void ExitThreadCore()
        {
            if (mainFrm != null) 
            { 
                mainFrm.Close(); 
            }
            KeyboardHook.RemoveHook();
            notifyIcon.Visible = false;
            base.ExitThreadCore();
        }

    }
}
