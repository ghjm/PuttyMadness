using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PuttyMadness
{
    public static class KeyboardHook
    {
        public static void SetHook()
        {
            RemoveHook();
            _hookID = SetHook(_proc);
        }
        public static void RemoveHook()
        {
            if (_hookID != IntPtr.Zero)
                UnhookWindowsHookEx(_hookID);
            _hookID = IntPtr.Zero;
        }
        public static event EventHandler OnKeyDown;
        public static event EventHandler OnKeyUp;

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_KEYUP))
            {
                int vkCode = Marshal.ReadInt32(lParam);

                if ((Win32.GetAsyncKeyState(Keys.ShiftKey) & 0x8000) != 0)
                {
                    vkCode |= (int)Keys.Shift;
                }
                if ((Win32.GetAsyncKeyState(Keys.ControlKey) & 0x8000) != 0)
                {
                    vkCode |= (int)Keys.Control;
                }
                if ((Win32.GetAsyncKeyState(Keys.Menu) & 0x8000) != 0)
                {
                    vkCode |= (int)Keys.Alt;
                }
                
                var kea = new KeyEventArgs((Keys)vkCode);

                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    if (OnKeyDown != null)
                        OnKeyDown(null, kea);
                }
                else
                {
                    if (OnKeyUp != null)
                        OnKeyUp(null, kea);
                }
                if (kea.Handled && ((vkCode < 160) || (vkCode > 164)))
                    return (IntPtr)1;
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
