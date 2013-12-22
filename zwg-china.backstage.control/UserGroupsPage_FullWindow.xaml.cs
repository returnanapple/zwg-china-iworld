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
using zwg_china.backstage.framework.AuthorService;

namespace zwg_china.backstage.control
{
    public partial class UserGroupsPage_FullWindow : ChildWindow
    {
        public UserGroupsPage_FullWindow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public UserGroupExport State
        {
            get { return (UserGroupExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(UserGroupExport), typeof(UserGroupsPage_FullWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                UserGroupsPage_FullWindow tool = (UserGroupsPage_FullWindow)d;
                UserGroupExport data = (UserGroupExport)e.NewValue;

                tool.text_Name.Text = data.Name;
                tool.text_Grade.Text = data.Grade.ToString();
                tool.text_LowerOfConsumption.Text = data.LowerOfConsumption.ToString("0.00");
                tool.text_CapsOfConsumption.Text = data.CapsOfConsumption.ToString("0.00");
                tool.text_TimesOfWithdrawal.Text = data.TimesOfWithdrawal == 0 ? "默认" : data.TimesOfWithdrawal.ToString();
                tool.text_MinimumWithdrawalAmount.Text = data.MinimumWithdrawalAmount == 0 ? "默认" : data.MinimumWithdrawalAmount.ToString("0.00");
                tool.text_MaximumWithdrawalAmount.Text = data.MaximumWithdrawalAmount == 0 ? "默认" : data.MaximumWithdrawalAmount.ToString("0.00");
            }));

        #endregion

        #region 确认

        private void Enter(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion
    }
}

