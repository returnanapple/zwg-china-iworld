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
using zwg_china.backstage.framework.LotteryService;

namespace zwg_china.backstage.control
{
    public partial class ChasingsPage_BettingWithChasingExport_ShowRow : UserControl
    {
        public ChasingsPage_BettingWithChasingExport_ShowRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public BettingWithChasingExport State
        {
            get { return (BettingWithChasingExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(BettingWithChasingExport), typeof(ChasingsPage_BettingWithChasingExport_ShowRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                ChasingsPage_BettingWithChasingExport_ShowRow tool = (ChasingsPage_BettingWithChasingExport_ShowRow)d;
                BettingWithChasingExport data = (BettingWithChasingExport)e.NewValue;

                tool.text_Issue.Text = data.Issue;
                tool.text_Multiple.Text = data.Multiple.ToString("0.00");
                tool.text_Pay.Text = data.Pay.ToString("0.00");
                tool.text_Status.Text = data.Status.ToString();
                tool.text_Bonus.Text = data.Bonus.ToString("0.00");
                tool.text_LotteryValue.Text = data.LotteryValue;
            }));

        #endregion
    }
}
