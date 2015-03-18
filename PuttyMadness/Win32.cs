using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace PuttyMadness
{
    public static class Win32
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public const uint WM_KEYDOWN = 0x100;
        public const uint WM_KEYUP = 0x0101;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo,
           bool fAttach);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetKeyboardState(byte[] lpKeyState);
        [DllImport("user32.dll")]
        public static extern bool SetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        public const uint VK_SHIFT = 0x10;
        public const uint VK_CONTROL = 0x11;
        public const uint VK_MENU = 0x12;

        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentThreadId();
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);


        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

        public static int RegisterWindowMessage(string format, params object[] args)
        {
            string message = String.Format(format, args);
            return RegisterWindowMessage(message);
        }

        public const int HWND_BROADCAST = 0xffff;
        public const int SW_SHOWNORMAL = 1;
        public const int SW_SHOW = 5;

        [DllImportAttribute("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32")]
        public static extern bool SetForegroundWindow(IntPtr hwnd);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool BringWindowToTop(IntPtr hWnd);

        public static readonly uint LSFW_UNLOCK = 2;
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool LockSetForegroundWindow(uint uLockCode);

        public static readonly int ASFW_ANY = -1;
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool AllowSetForegroundWindow(int dwProcessId);

        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsIconic(IntPtr hWnd);

        public static void ForceForegroundWindow(IntPtr hWnd)
        {
            uint a;
            LockSetForegroundWindow(LSFW_UNLOCK);
            AllowSetForegroundWindow(ASFW_ANY);

            IntPtr hWndForeground = GetForegroundWindow();
            if (hWndForeground.ToInt32() != 0)
            {
                if (hWndForeground != hWnd)
                {
                    uint thread1 = GetWindowThreadProcessId(hWndForeground, out a);
                    uint thread2 = GetCurrentThreadId();


                    if (thread1 != thread2)
                    {
                        AttachThreadInput(thread1, thread2, true);
                        LockSetForegroundWindow(LSFW_UNLOCK);
                        AllowSetForegroundWindow(ASFW_ANY);
                        BringWindowToTop(hWnd);
                        if (IsIconic(hWnd))
                        {
                            ShowWindow(hWnd, SW_SHOWNORMAL);
                        }
                        else
                        {
                            ShowWindow(hWnd, SW_SHOW);
                        }
                        SetFocus(hWnd);
                        AttachThreadInput(thread1, thread2, false);
                    }
                    else
                    {
                        AttachThreadInput(thread1, thread2, true);
                        LockSetForegroundWindow(LSFW_UNLOCK);
                        AllowSetForegroundWindow(ASFW_ANY);
                        BringWindowToTop(hWnd);
                        SetForegroundWindow(hWnd);
                        SetFocus(hWnd);
                        AttachThreadInput(thread1, thread2, false);

                    }
                    if (IsIconic(hWnd))
                    {
                        AttachThreadInput(thread1, thread2, true);
                        LockSetForegroundWindow(LSFW_UNLOCK);
                        AllowSetForegroundWindow(ASFW_ANY);
                        BringWindowToTop(hWnd);
                        ShowWindow(hWnd, SW_SHOWNORMAL);
                        SetFocus(hWnd);
                        AttachThreadInput(thread1, thread2, false);
                    }
                    else
                    {
                        BringWindowToTop(hWnd);
                        ShowWindow(hWnd, SW_SHOW);
                    }
                }
                SetForegroundWindow(hWnd);
                SetFocus(hWnd);
            }
            else
            {
                uint thread1 = GetWindowThreadProcessId(hWndForeground, out a);
                uint thread2 = GetCurrentThreadId();
                try
                {
                    AttachThreadInput(thread1, thread2, true);
                }
                catch
                {
                }
                LockSetForegroundWindow(LSFW_UNLOCK);
                AllowSetForegroundWindow(ASFW_ANY);
                BringWindowToTop(hWnd);
                SetForegroundWindow(hWnd);

                ShowWindow(hWnd, SW_SHOW);
                SetFocus(hWnd);
                AttachThreadInput(thread1, thread2, false);
            }
        }

        public delegate bool EnumedWindow(IntPtr handleWindow, ArrayList handles);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(EnumedWindow lpEnumFunc, ArrayList lParam);
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        public const UInt32 WM_GETTEXT = 0xD;
        public const UInt32 WM_GETTEXTLENGTH = 0xE;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [Out] StringBuilder lParam);
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32.dll")]
        public static extern uint WaitForInputIdle(IntPtr hProcess, uint dwMilliseconds);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern UInt32 GetWindowThreadProcessId(IntPtr hWnd, out UInt32 lpdwProcessId);
        public static UInt32 GetWindowProcessId(IntPtr hWnd)
        {
            UInt32 processID = 0;
            UInt32 threadID = GetWindowThreadProcessId(hWnd, out processID);
            return processID;
        }

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In] IntPtr processHandle, [Out, MarshalAs(UnmanagedType.Bool)] out bool wow64Process);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);
        [Flags()]
        public enum SetWindowPosFlags : uint
        {
            AsynchronousWindowPosition = 0x4000,
            DeferErase = 0x2000,
            DrawFrame = 0x0020,
            FrameChanged = 0x0020,
            HideWindow = 0x0080,
            DoNotActivate = 0x0010,
            DoNotCopyBits = 0x0100,
            IgnoreMove = 0x0002,
            DoNotChangeOwnerZOrder = 0x0200,
            DoNotRedraw = 0x0008,
            DoNotReposition = 0x0200,
            DoNotSendChangingEvent = 0x0400,
            IgnoreResize = 0x0001,
            IgnoreZOrder = 0x0004,
            ShowWindow = 0x0040,
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindow(IntPtr hWnd);

        private static bool GetWindowHandle(IntPtr windowHandle, ArrayList windowHandles)
        {
            if (Win32.IsWindowVisible(windowHandle))
                windowHandles.Add(windowHandle);
            return true;
        }

        public static string GetWindowText(IntPtr hwnd)
        {
            // Allocate correct string length first
            int length = (int)Win32.SendMessage(hwnd, Win32.WM_GETTEXTLENGTH, IntPtr.Zero, null);
            StringBuilder sb = new StringBuilder(length + 1);
            Win32.SendMessage(hwnd, Win32.WM_GETTEXT, (IntPtr)sb.Capacity, sb);
            return sb.ToString();
        }

        public static bool IsProcess32bit(Process process)
        {
            if (!Environment.Is64BitOperatingSystem)
                return true;
            bool isWow64Process;
            try
            {
                if (!Win32.IsWow64Process(process.Handle, out isWow64Process))
                    return false;
            }
            catch
            {
                return false;
            }
            return isWow64Process;
        }

        public static string ProcessModuleIfAvail(Process process)
        {
            try
            {
                return process.MainModule.FileName;
            }
            catch
            {
                return "";
            }
        }

        public static ArrayList GetWindows()
        {
            var windowHandles = new ArrayList();
            Win32.EnumedWindow callBackPtr = GetWindowHandle;
            Win32.EnumWindows(callBackPtr, windowHandles);

            return windowHandles;
        }

        public const uint SE_GROUP_LOGON_ID = 0xC0000000; // from winnt.h
        public const int TokenGroups = 2; // from TOKEN_INFORMATION_CLASS

        enum TOKEN_INFORMATION_CLASS
        {
            TokenUser = 1,
            TokenGroups,
            TokenPrivileges,
            TokenOwner,
            TokenPrimaryGroup,
            TokenDefaultDacl,
            TokenSource,
            TokenType,
            TokenImpersonationLevel,
            TokenStatistics,
            TokenRestrictedSids,
            TokenSessionId,
            TokenGroupsAndPrivileges,
            TokenSessionReference,
            TokenSandBoxInert,
            TokenAuditPolicy,
            TokenOrigin
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SID_AND_ATTRIBUTES
        {
            public IntPtr Sid;
            public uint Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TOKEN_GROUPS
        {
            public int GroupCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public SID_AND_ATTRIBUTES[] Groups;
        };

        // Using IntPtr for pSID instead of Byte[]
        [DllImport("advapi32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool ConvertSidToStringSid(IntPtr pSID, out IntPtr ptrSid);

        [DllImport("kernel32.dll")]
        static extern IntPtr LocalFree(IntPtr hMem);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool GetTokenInformation(
            IntPtr TokenHandle,
            TOKEN_INFORMATION_CLASS TokenInformationClass,
            IntPtr TokenInformation,
            int TokenInformationLength,
            out int ReturnLength);

        public static string GetLogonId()
        {
            int TokenInfLength = 0;
            // first call gets lenght of TokenInformation
            bool Result = GetTokenInformation(WindowsIdentity.GetCurrent().Token, TOKEN_INFORMATION_CLASS.TokenGroups, IntPtr.Zero, TokenInfLength, out TokenInfLength);
            IntPtr TokenInformation = Marshal.AllocHGlobal(TokenInfLength);
            Result = GetTokenInformation(WindowsIdentity.GetCurrent().Token, TOKEN_INFORMATION_CLASS.TokenGroups, TokenInformation, TokenInfLength, out TokenInfLength);

            if (!Result)
            {
                Marshal.FreeHGlobal(TokenInformation);
                return string.Empty;
            }

            string retVal = string.Empty;
            TOKEN_GROUPS groups = (TOKEN_GROUPS)Marshal.PtrToStructure(TokenInformation, typeof(TOKEN_GROUPS));
            int sidAndAttrSize = Marshal.SizeOf(new SID_AND_ATTRIBUTES());
            for (int i = 0; i < groups.GroupCount; i++)
            {
                SID_AND_ATTRIBUTES sidAndAttributes = (SID_AND_ATTRIBUTES)Marshal.PtrToStructure(
                    new IntPtr(TokenInformation.ToInt64() + i * sidAndAttrSize + IntPtr.Size), typeof(SID_AND_ATTRIBUTES));
                if ((sidAndAttributes.Attributes & SE_GROUP_LOGON_ID) == SE_GROUP_LOGON_ID)
                {
                    IntPtr pstr = IntPtr.Zero;
                    ConvertSidToStringSid(sidAndAttributes.Sid, out pstr);
                    retVal = Marshal.PtrToStringAuto(pstr);
                    LocalFree(pstr);
                    break;
                }
            }

            Marshal.FreeHGlobal(TokenInformation);
            return retVal;
        }
    
    }
}
