using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using Microsoft.Win32;

namespace PuttyMadness
{
    public interface IDetail {
        void ToRegistry(RegistryKey rhk);
        void FromRegistry(RegistryKey rhk);
    }

    public class HostDetail: IDetail
    {
        public string Username = "";
        public string RequiredKey = "";
        public string JumpHost = "";
        public string JumpCmd = "";
        public string OverrideIP = "";
        public void ToRegistry(RegistryKey rhk)
        {
            rhk.SetValue("Username", Username);
            if (RequiredKey.Length > 0)
                rhk.SetValue("RequiredKey", RequiredKey);
            else
                rhk.DeleteValue("RequiredKey", false);
            if (JumpHost.Length > 0)
                rhk.SetValue("JumpHost", JumpHost);
            else
                rhk.DeleteValue("JumpHost", false);
            if (JumpCmd.Length > 0)
                rhk.SetValue("JumpCmd", JumpCmd);
            else
                rhk.DeleteValue("JumpCmd", false);
            if (OverrideIP.Length > 0)
                rhk.SetValue("OverrideIP", OverrideIP);
            else
                rhk.DeleteValue("OverrideIP", false);
        }
        public void FromRegistry(RegistryKey rhk)
        {
            Username = rhk.GetValue("Username", "").ToString();
            RequiredKey = rhk.GetValue("RequiredKey", "").ToString();
            JumpHost = rhk.GetValue("JumpHost", "").ToString();
            JumpCmd = rhk.GetValue("JumpCmd", "").ToString();
            OverrideIP = rhk.GetValue("OverrideIP", "").ToString();
        }
    }
    public class KeyDetail: IDetail
    {
        public bool IsRemote = false;
        public string PPKFile = "";
        public string RemoteHost = "";
        public string RemoteCommand = "";
        public void ToRegistry(RegistryKey rhk)
        {
            rhk.SetValue("IsRemote", IsRemote);
            if (IsRemote)
            {
                rhk.SetValue("RemoteHost", RemoteHost);
                rhk.SetValue("RemoteCommand", RemoteCommand);
                rhk.DeleteValue("PPKFile", false);
            }
            else
            {
                rhk.SetValue("PPKFile", PPKFile);
                rhk.DeleteValue("RemoteHost", false);
                rhk.DeleteValue("RemoteCommand", false);
            }
        }
        public void FromRegistry(RegistryKey rhk)
        {
            IsRemote = Convert.ToBoolean(rhk.GetValue("IsRemote", false));
            if (IsRemote)
            {
                RemoteHost = rhk.GetValue("RemoteHost", "").ToString();
                RemoteCommand = rhk.GetValue("RemoteCommand", "").ToString();
                PPKFile = "";
            }
            else
            {
                PPKFile = rhk.GetValue("PPKFile", "").ToString();
                RemoteHost = "";
                RemoteCommand = "";
            }
        }
    }
    public class GroupMember: IDetail
    {
        public string Hostname = "";
        public int Left, Top, Width, Height;
        public void ToRegistry(RegistryKey rhk)
        {
            rhk.SetValue("Hostname", Hostname);
            rhk.SetValue("Left", Left);
            rhk.SetValue("Top", Top);
            rhk.SetValue("Width", Width);
            rhk.SetValue("Height", Height);
        }
        public void FromRegistry(RegistryKey rhk)
        {
            Hostname = rhk.GetValue("Hostname", "").ToString();
            Left = Convert.ToInt32(rhk.GetValue("Left", 0));
            Top = Convert.ToInt32(rhk.GetValue("Top", 0));
            Width = Convert.ToInt32(rhk.GetValue("Width", 0));
            Height = Convert.ToInt32(rhk.GetValue("Height", 0));
        }
    }
    public class GroupDetail: IDetail
    {
        public List<GroupMember> Members = new List<GroupMember>();
        public void ToRegistry(RegistryKey rhk)
        {
            // Remove old entries
            foreach (var key in rhk.GetSubKeyNames())
            {
                rhk.DeleteSubKey(key);
            }
            // Add current entries
            for (int i = 0; i < Members.Count; i++)
            {
                var rsk = rhk.CreateSubKey(i.ToString());
                Members[i].ToRegistry(rsk);
            }
        }
        public void FromRegistry(RegistryKey rhk)
        {
            Members.Clear();
            foreach (var key in rhk.GetSubKeyNames())
            {
                var mem = new GroupMember();
                var rsk = rhk.OpenSubKey(key);
                if (rsk != null)
                    mem.FromRegistry(rsk);
                Members.Add(mem);
            }
        }
    }
    public class GlobalData
    {
        static GlobalData _instance = null;
        public static GlobalData Instance { 
            get 
            {
                if (_instance == null)
                {
                    _instance = new GlobalData();
                }
                return _instance;
            }
        }

        public Dictionary<string, HostDetail> HostList = new Dictionary<string, HostDetail>();
        public Dictionary<string, KeyDetail> KeyList = new Dictionary<string, KeyDetail>();
        public Dictionary<string, GroupDetail> GroupList = new Dictionary<string, GroupDetail>();

        public AutoCompleteStringCollection ToACSC()
        {
            var ACSC = new AutoCompleteStringCollection();
            foreach (string host in HostList.Keys)
            {
                ACSC.Add(host);
            }
            foreach (string group in GroupList.Keys)
            {
                ACSC.Add(group + " (group)");
            }
            return ACSC;
        }
        public void ToRegistryPart<T>(RegistryKey rk, Dictionary<string, T> DetailData) 
            where T : IDetail 
        {
            // Remove old entries
            foreach (var key in rk.GetSubKeyNames())
            {
                if (!DetailData.ContainsKey(key))
                {
                    rk.DeleteSubKeyTree(key);
                }
            }
            // Add/update current entries
            foreach (string key in DetailData.Keys)
            {
                var rhk = rk.CreateSubKey(key);
                DetailData[key].ToRegistry(rhk);
            }
        }
        public void FromRegistryPart<T>(RegistryKey rk, Dictionary<string, T> DetailData)
            where T : IDetail, new()
        {
            DetailData.Clear();
            if (rk != null)
            {
                foreach (string key in rk.GetSubKeyNames())
                {
                    var detail = new T();
                    var rhk = rk.OpenSubKey(key);
                    if (rhk != null)
                        detail.FromRegistry(rhk);
                    DetailData.Add(key, detail);
                }
            }
        }
        public void ToRegistry()
        {
            var hkcu = Microsoft.Win32.Registry.CurrentUser;
            var rk = hkcu.CreateSubKey(@"Software\PuttyMadness");
            rk = hkcu.CreateSubKey(@"Software\PuttyMadness\Hosts");
            ToRegistryPart(rk, HostList);
            rk = hkcu.CreateSubKey(@"Software\PuttyMadness\Keys");
            ToRegistryPart(rk, KeyList);
            rk = hkcu.CreateSubKey(@"Software\PuttyMadness\Groups");
            ToRegistryPart(rk, GroupList);
        }
        public void FromRegistry()
        {
            var hkcu = Microsoft.Win32.Registry.CurrentUser;
            var rk = hkcu.OpenSubKey(@"Software\PuttyMadness\Hosts");
            FromRegistryPart(rk, HostList);
            rk = hkcu.OpenSubKey(@"Software\PuttyMadness\Keys");
            FromRegistryPart(rk, KeyList);
            rk = hkcu.OpenSubKey(@"Software\PuttyMadness\Groups");
            FromRegistryPart(rk, GroupList);
        }
    }
    public static class PageantInterface
    {
        public static string[] GetPageantKeys()
        {
            var keylist = new List<string>();
            try
            {
                var pp = new Renci.SshNet.Pageant.PageantProtocol() as IAgentProtocol;
                var identities = pp.GetIdentities();
                foreach (var identity in identities)
                {
                    keylist.Add(identity.Comment);
                }
            }
            catch { }
            return keylist.ToArray();
        }
        public static void LaunchPageantIfNeeded()
        {
            foreach (var proc in System.Diagnostics.Process.GetProcesses())
            {
                if (proc.ProcessName.Contains("pageant"))
                    return;
            }
            string pageant_path = PuttySearch.GetFullPath("pageant.exe");
            if (pageant_path == null)
                return;
            var pag_proc = System.Diagnostics.Process.Start(pageant_path);
            pag_proc.WaitForInputIdle();
        }
    }
}
