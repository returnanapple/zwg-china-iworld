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
using zwg_china.backstage.framework.LotteryService;

namespace zwg_china.backstage.control
{
    public partial class LotteriesPage_TableRow : UserControl
    {
        public LotteriesPage_TableRow()
        {
            InitializeComponent();

        #region 附加内容

        public LotteryExport State
        {
            get { return (LotteryExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(LotteryExport), typeof(LotteriesPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                LotteriesPage_TableRow tool = (LotteriesPage_TableRow)d;
                LotteryExport data = (LotteryExport)e.NewValue;

                tool.text_Ticket.Text = data.Ticket;
                tool.text_Issue.Text = data.Issue;
                tool.text_Values.Text = data.Values;
                tool.text_Sources.Text = data.Sources.ToString();
                tool.text_CreatedTime.Text = data.CreatedTime.ToLongDateString();
            }));

        #endregion
    }
}
