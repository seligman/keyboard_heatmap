using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowKeys
{
    public partial class LoggerForm : Form
    {
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        static int hHook = 0;
        public const int WH_KEYBOARD_LL = 13;
        HookProc? KeyboardHookProc;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardLLHookStruct
        {
            public Int32 vkCode;
            public UInt32 scanCode;
            public UInt32 flags;
            public UInt32 time;
            public IntPtr dwExtraInfo;
        }

        KeyForm _parent;

        public int KeyboardHook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return CallNextHookEx(hHook, nCode, wParam, lParam);
            }
            else
            {
                KeyboardLLHookStruct? kh = (KeyboardLLHookStruct?)Marshal.PtrToStructure(lParam, typeof(KeyboardLLHookStruct));
                if (kh != null)
                {
                    int vk = kh.vkCode;
                    if ((kh.flags & 1) == 1)
                    {
                        vk |= 32768;
                    }

                    if ((kh.flags & 128) == 0)
                    {
                        Counts.AddVK(vk);

                        string desc = "(unknown)";
                        if (Keys.ByKeyCode.TryGetValue(vk, out Key key))
                        {
                            if (key.Name != null)
                            {
                                desc = key.Name;
                            }
                            else if (key.Desc != null)
                            {
                                desc = key.Desc;
                            }
                        }
                        _log.Items.Insert(0, $"Key: {vk}, Flags: {kh.flags}, Desc: {desc}");
                        while (_log.Items.Count > 100)
                        {
                            _log.Items.RemoveAt(_log.Items.Count - 1);
                        }
                    }
                }
                return CallNextHookEx(hHook, nCode, wParam, lParam);
            }
        }

        public LoggerForm(KeyForm parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        void LoggerForm_Load(object sender, EventArgs e)
        {
            KeyboardHookProc = new HookProc(KeyboardHook);
            IntPtr hInstance = LoadLibrary("User32");

            hHook = SetWindowsHookEx(WH_KEYBOARD_LL,
                        KeyboardHookProc,
                        hInstance,
                        0);

            if (hHook == IntPtr.Zero)
            {
                MessageBox.Show("Unable to initialize hook!");
            }
        }

        private void LoggerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.RemoveLogger();
        }
    }
}
