using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace RetroGame.Utilities
{
    public static class IndexHelper
    {
        public static void SetIndex(string pageName)
        {
            if (!(Application.Current.MainWindow is MainWindow mw)) return;

            try
            {
                var page = (Page) Application.LoadComponent(new Uri("Views" + "/" + pageName + ".xaml",
                    UriKind.Relative));

                void Action()
                {
                    mw.Index.Navigate(page);
                }

                Application.Current.Dispatcher?.BeginInvoke((Action) Action, DispatcherPriority.Normal);
            }
            catch
            {
                //To-Do
            }
        }

        public static void SetIndex(object page)
        {
            if (!(Application.Current.MainWindow is MainWindow mw)) return;

            try
            {
                void Action()
                {
                    mw.Index.Navigate(page);
                }

                Application.Current.Dispatcher?.BeginInvoke((Action) Action, DispatcherPriority.Normal);
            }
            catch
            {
                //To-Do
            }
        }
    }
}