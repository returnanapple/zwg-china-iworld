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
using zwg_china.client.framework.AuthorService;
using zwg_china.client.framework.LotteryService;

namespace zwg_china.client
{
    public partial class TableRowOfLotteryTool_ChildWindow : ChildWindow
    {
        public TableRowOfLotteryTool_ChildWindow()
        {
            InitializeComponent();
            Style = (Style)Resources["NewChildWindowStyle"];
        }
        #region Click事件
        private void OK(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void Return(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        #endregion

        #region 依赖属性
        public BettingExport BetInfo
        {
            get { return (BettingExport)GetValue(BetInfoProperty); }
            set { SetValue(BetInfoProperty, value); }
        }
        public static readonly DependencyProperty BetInfoProperty =
            DependencyProperty.Register("BetInfo", typeof(BettingExport), typeof(TableRowOfLotteryTool_ChildWindow), new PropertyMetadata(null, (d, e) =>
            {
                TableRowOfLotteryTool_ChildWindow td = (TableRowOfLotteryTool_ChildWindow)d;
                BettingExport te = (BettingExport)e.NewValue;
                td.彩种.Text = te.Ticket;
                td.玩法标签.Text = te.PlayTag;
                td.玩法.Text = te.HowToPlay;
                td.期号.Text = te.Issue;
                td.返点.Text = te.Points.ToString();
                td.注数.Text = te.Notes.ToString();
                td.倍数.Text = te.Multiple.ToString();
                td.订单号.Text = te.Id.ToString();
                td.用户.Text = te.Owner.ToString();
                td.下注时间.Text = te.CreatedTime.ToString();
                SettingExport se = DataManager.GetValue<SettingExport>(DataKey.IWorld_Client_Setting);
                td.单注价格.Text = se.UnitPrice.ToString();
                td.总金额.Text = te.Pay.ToString();
                td.中奖金额.Text = te.Bonus.ToString();
                //td.盈亏.Text
                if (te.LotteryValue == null || te.LotteryValue == "")
                {
                    td.开奖号码.Text = "-,-,-,-,-";
                }
                else
                {
                    td.开奖号码.Text = te.LotteryValue;
                }
                td.状态.Text = te.Status.ToString();
            }));



        #endregion

        #region Closed事件
        void ReBet(object sender, EventArgs e)
        {
        }
        #endregion
    }
}

