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
using zwg_china.client.framework.LotteryService;

namespace zwg_china.client
{
    public partial class MainTool : UserControl
    {
        public MainTool()
        {
            InitializeComponent();
        }

        #region 私有字段
        List<LotteryTicketExport> tickets;
        #endregion

        #region 依赖属性


        public string PageName
        {
            get { return (string)GetValue(PageNameProperty); }
            set { SetValue(PageNameProperty, value); }
        }
        public static readonly DependencyProperty PageNameProperty =
            DependencyProperty.Register("PageName", typeof(string), typeof(MainTool), new PropertyMetadata("", (d, e) =>
            {
            }));


        public ICommand Jump
        {
            get { return (ICommand)GetValue(JumpProperty); }
            set { SetValue(JumpProperty, value); }
        }
        public static readonly DependencyProperty JumpProperty =
            DependencyProperty.Register("Jump", typeof(ICommand), typeof(MainTool), new PropertyMetadata(0));
        #endregion

        #region Checked事件
        void SelectCenter(object sender, RoutedEventArgs e)
        {
            NewRadioButton nrb = (NewRadioButton)sender;
            switch (nrb.ImageNameOfBackground)
            {
                case "用户中心":
                    Jump.Execute("查看个人信息");
                    break;
                case "代理中心":
                    Jump.Execute("会员列表");
                    break;
                case "报表中心":
                    Jump.Execute("投注记录");
                    break;
                case "彩种选择":
                    Jump.Execute(tickets.First().Name);
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
