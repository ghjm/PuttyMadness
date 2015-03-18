using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace PuttyMadness
{
    public class WindowPersist
    {
        private static WindowPersist _instance = null;
        public static WindowPersist Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WindowPersist();
                return _instance;
            }
        }

        private Dictionary<IntPtr, string> HostList = new Dictionary<IntPtr, string>();
        FileStream TempFile;

        private string GetFilename()
        {
            return Path.Combine(Path.GetTempPath(), @"PuttyMadnessWindowList.tmp");
        }

        private bool TryOpen(int timeout)
        {
			bool result = false;
			DateTime dateTimestart = DateTime.Now;
			Tuple<AutoResetEvent, FileSystemWatcher> tuple = null;
 
			while (true)
			{
				try
				{
                    TempFile = File.Open(GetFilename(), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
					result = true;
					break;
				}
				catch (IOException)
				{
					if (tuple == null) 
					{
						var autoResetEvent = new AutoResetEvent(true);
						var fileSystemWatcher = new FileSystemWatcher(Path.GetDirectoryName(GetFilename()))
							{
								EnableRaisingEvents = true
							};
						fileSystemWatcher.Changed +=
							(o, e) =>
							{
								if (Path.GetFullPath(e.FullPath) == Path.GetFullPath(GetFilename()))
								{
									autoResetEvent.Set();
								}
							};
						tuple = new Tuple<AutoResetEvent, FileSystemWatcher>(autoResetEvent, fileSystemWatcher);
					}
					int time = Timeout.Infinite;
					if (timeout != Timeout.Infinite)
					{
                        time = (int)(DateTime.Now - dateTimestart).TotalMilliseconds;
                        if (time >= timeout)
						{
							result = false;
							break;
						}
					}
                    tuple.Item1.WaitOne(time);
				}
			}
			if (tuple != null && tuple.Item1 != null)
			{
				tuple.Item1.Dispose();
				tuple.Item2.Dispose(); 
			}
			return result;
        }

        public void OpenAndLock()
        {
            if (TempFile != null)
                throw new ApplicationException("Tried to open already open temp file");
            HostList.Clear();
            if (!TryOpen(5000))
                throw new ApplicationException("Could not open temp file");
            var sr = new StreamReader(TempFile);
            string LogonId = sr.ReadLine();
            // If this file is from a prior logon session, none of the hWnds mean anything
            if (LogonId != Win32.GetLogonId())
                return;
            while (!sr.EndOfStream)
            {
                var list = sr.ReadLine().Split(':');
                if (list.Length == 2)
                {
                    IntPtr hWnd = (IntPtr)Convert.ToInt32(list[0]);
                    if (Win32.IsWindow(hWnd))
                    {
                        Process proc = Process.GetProcessById((int)Win32.GetWindowProcessId(hWnd));
                        string pfn = Win32.ProcessModuleIfAvail(proc);
                        if (pfn.EndsWith("putty.exe"))
                        {
                            HostList.Add(hWnd, list[1]);
                        }
                    }
                }
            }
            // file stays open and therefore locked
        }

        public void CloseAndUnlock()
        {
            if (TempFile == null)
                throw new ApplicationException("Tried to close already closed temp file");
            TempFile.Close();
            TempFile = null;
        }

        public void SaveAndUnlock()
        {
            if (TempFile == null)
                throw new ApplicationException("Tried to close already closed temp file");
            TempFile.Seek(0, SeekOrigin.Begin);
            TempFile.SetLength(0);
            var sw = new StreamWriter(TempFile);
            sw.WriteLine(Win32.GetLogonId());
            foreach (IntPtr hWnd in HostList.Keys)
            {
                sw.WriteLine("{0}:{1}", hWnd.ToString(), HostList[hWnd]);
            }
            sw.Flush();
            CloseAndUnlock();
        }

        public string GetHostNameForWindow(IntPtr hWnd)
        {
            if (HostList.ContainsKey(hWnd))
                return HostList[hWnd];
            else
                return "";
        }

        public void AddWindowHostName(IntPtr hWnd, string HostName)
        {
            if (HostList.ContainsKey(hWnd))
                HostList[hWnd] = HostName;
            else
                HostList.Add(hWnd, HostName);
        }
    }
}
