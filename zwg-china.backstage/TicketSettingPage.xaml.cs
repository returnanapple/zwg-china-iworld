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
    [View(page: Page.彩票模块设置)]
    public partial class TicketSettingPage : UserControl
    {
        public TicketSettingPage()
        {
            InitializeComponent();
            this.Loaded += HideButton;
        }

        void HideButton(object sender, RoutedEventArgs e)
        {
            AdministratorExport info = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            if (info.Group.CanEditSettings) { return; }
            button_Edit.Visibility = System.Windows.Visibility.Collapsed;
            button_Remove.Visibility = System.Windows.Visibility.Collapsed;
            cover_Main.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
