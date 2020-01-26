using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

namespace RetroGame
{
    public partial class App : Application
    {
        private Mutex _mutex;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private void App_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                Mutex("RetroGame");

                Window window = new MainWindow();
                window.Show();
            }
            catch
            {
                Current.Shutdown();
            }
        }

        private void Mutex(string name)
        {
            _mutex = new Mutex(true, name, out var createdNew);

            if (!createdNew)
            {
                var current = Process.GetCurrentProcess();
                foreach (var process in Process.GetProcessesByName(current.ProcessName))
                {
                    if (process.Id == current.Id) continue;

                    SetForegroundWindow(process.MainWindowHandle);

                    break;
                }

                Current.Shutdown();
            }
            else
            {
                Exit += CloseMutexHandler;
            }
        }

        protected virtual void CloseMutexHandler(object sender, EventArgs e)
        {
            _mutex?.Close();
        }
    }
}