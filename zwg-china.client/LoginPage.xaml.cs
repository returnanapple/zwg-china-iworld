using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using zwg_china.client.framework;

namespace zwg_china.client
{
    [View(Page.登陆,IsDefault=true)]
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        #region 关闭和最小化
        private void Exit(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
        private void Minimize(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        #endregion

        private void LoadedAction(object sender, RoutedEventArgs e)
        {
            if (App.Current.IsRunningOutOfBrowser)
            {
                App.Current.MainWindow.Width = 960;
                App.Current.MainWindow.Height = 730;
            }
            
        }

    }
}
