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
using zwg_china.backstage.AdministratorService;

namespace zwg_china.backstage
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            AdministratorServiceClient client = new AdministratorServiceClient();
            client.LoginCompleted += client_LoginCompleted;
            client.LoginAsync(new LoginImport { Username = "admin", Password = "admin" });
        }

        void client_LoginCompleted(object sender, LoginCompletedEventArgs e)
        {
            sb.Text = e.Result.Info.Token;
        }
    }
}
