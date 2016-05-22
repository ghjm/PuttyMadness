using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PuttyMadness
{
    public class PuttyWindow
    {
        public IntPtr hWnd;
        public string Title;
        public int Left;
        public int Top;
        public int Width;
        public int Height;
        public override string ToString()
        {
            return Title;
        }
    }
    public static class PuttyWindows
    {
        public static List<PuttyWindow> GetPuttyWindows(bool RecognizedOnly)
        {
            var list = new List<PuttyWindow>();
            var hWnds = Win32.GetWindows();
            WindowPersist.Instance.OpenAndLock();
            foreach (IntPtr hWnd in hWnds)
            {
                string text = Win32.GetWindowText(hWnd);
                Process proc = Process.GetProcessById((int)Win32.GetWindowProcessId(hWnd));
                string RecognizedHost = WindowPersist.Instance.GetHostNameForWindow(hWnd);

                if (text.Length > 0)
                {
                    string pfn = Win32.ProcessModuleIfAvail(proc);
                    if (pfn.EndsWith("putty.exe") || proc.ProcessName == "putty")
                    {
                        var pw = new PuttyWindow();
                        pw.hWnd = hWnd;
                        pw.Title = text + ((RecognizedHost == "") ? "" : (" (" + RecognizedHost + ")"));
                        var rect = new Win32.RECT();
                        Win32.GetWindowRect(hWnd, ref rect);
                        pw.Left = rect.Left;
                        pw.Top = rect.Top;
                        pw.Width = rect.Right - rect.Left;
                        pw.Height = rect.Bottom - rect.Top;
                        if ((!RecognizedOnly) || (RecognizedHost != ""))
                            list.Add(pw);
                    }
                }
            }
            WindowPersist.Instance.CloseAndUnlock();
            return list;
        }

    }
}
