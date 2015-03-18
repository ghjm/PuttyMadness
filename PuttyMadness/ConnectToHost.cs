using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace PuttyMadness
{
    public class ConnectToHost
    {
        private static ConnectToHost _instance = null;
        public static ConnectToHost Instance
        {
            get {
                if (_instance == null)
                    _instance = new ConnectToHost();
                return _instance;
            }
        }

        List<string> DeleteQueue = new List<string>();
        System.Windows.Forms.Timer timer1 = null;

        public ConnectToHost()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Enabled = false;
            timer1.Tick += timer1_Tick;
        }

        public void Connect_To_Group(GroupDetail gd)
        {
            foreach (GroupMember gm in gd.Members)
            {
                ConnectToHost.Instance.Connect_To_Host(gm.Hostname, GlobalData.Instance.HostList[gm.Hostname], gm.Left, gm.Top, gm.Width, gm.Height);
            }
        }

        public void Connect_To_Host(string host)
        {
            HostDetail hd;
            if (GlobalData.Instance.HostList.ContainsKey(host))
                hd = GlobalData.Instance.HostList[host];
            else
                hd = new HostDetail();
            Connect_To_Host(host, hd);
        }

        public void Connect_To_Host(string host, HostDetail hd)
        {
            Connect_To_Host(host, hd, 0, 0, 0, 0);
        }

        public void Connect_To_Host(string host, HostDetail hd, int Left, int Top, int Width, int Height, bool Wait = false)
        {
            // Check if required key is loaded in Pageant
            if (hd.RequiredKey.Length > 0)
            {
                if (!PageantInterface.GetPageantKeys().Contains(hd.RequiredKey))
                {
                    if (GlobalData.Instance.KeyList.ContainsKey(hd.RequiredKey))
                    {
                        var key = GlobalData.Instance.KeyList[hd.RequiredKey];
                        if (key.IsRemote)
                        {
                            PageantInterface.LaunchPageantIfNeeded();
                            var khd = GlobalData.Instance.HostList[key.RemoteHost];
                            khd.JumpCmd = key.RemoteCommand;
                            Connect_To_Host(key.RemoteHost, khd, 0, 0, 0, 0, true);
                        }
                        else
                        {
                            PageantInterface.LaunchPageantIfNeeded();
                            var pag_proc = System.Diagnostics.Process.Start("pageant.exe", key.PPKFile);
                            pag_proc.WaitForExit();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please load key " + hd.RequiredKey + " into Pageant before clicking OK.");
                    }
                }
            }

            string realhost = (hd.OverrideIP.Length > 0) ? hd.OverrideIP : Regex.Replace(host, @"\s+\(.*\)\s*$", "");

            // Figure out the path to actually connect to
            string connhost = ((hd.Username.Length > 0) ? hd.Username + "@" : "") +
                ((hd.JumpHost.Length > 0) ? hd.JumpHost : realhost);

            // Figure out the jump command, if any
            string jumpcmd = (hd.JumpCmd.Length > 0) ? hd.JumpCmd : ((hd.JumpHost.Length > 0) ? "ssh -A root@$host" : "");

            // If there is a jump command, we'll need to create a temp file
            string TempFN = "";
            if (jumpcmd.Length > 0)
            {
                TempFN = Path.GetTempFileName();
                using (var sw = new StreamWriter(TempFN))
                {
                    sw.WriteLine(jumpcmd.Replace("$host", realhost));
                }
            }

            // Figure out the full command line for Putty
            string puttycmd = ((TempFN.Length > 0) ? @"-t -m """ + TempFN + @""" " : "") + connhost;

            // Connect to the host
            var proc = System.Diagnostics.Process.Start("putty.exe", puttycmd);
            proc.WaitForInputIdle();

            var putty_hWnd = proc.MainWindowHandle;
            if ((Width > 0) && (Height > 0))
            {
                Win32.SetWindowPos(putty_hWnd, (IntPtr)0, Left, Top, Width, Height, 0);
            }

            // Hide our window and bring the Putty window to the front
            foreach (Form f in Application.OpenForms)
                f.Hide();
            System.Threading.Thread.Sleep(250);
            Win32.SetForegroundWindow(putty_hWnd);

            // Save the hWnd and connection for using later maybe
            WindowPersist.Instance.OpenAndLock();
            WindowPersist.Instance.AddWindowHostName(putty_hWnd, host);
            WindowPersist.Instance.SaveAndUnlock();

            if (Wait)
            {
                proc.WaitForExit();
                File.Delete(TempFN);
            }
            else
            {
                // If we made a temp file, clean it up
                if (TempFN.Length > 0)
                {
                    DeleteQueue.Add(TempFN);
                    timer1.Interval = 5000;
                    timer1.Enabled = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var TempFN in DeleteQueue)
            {
                File.Delete(TempFN);
            }
            Application.Exit();
        }

    }
}
