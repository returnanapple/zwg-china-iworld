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
using zwg_china.backstage.framework;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage
{
    [View(page: Page.查看帐变记录)]
    public partial class MoneyChangeRecordsPage : UserControl
    {
        public MoneyChangeRecordsPage()
        {
            InitializeComponent();
            this.Loaded += HideMenu;
        }

        void HideMenu(object sender, RoutedEventArgs e)
        {
            AdministratorExport info = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            if (!info.Group.CanEditSettings)
            {
                button_sqs.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}
