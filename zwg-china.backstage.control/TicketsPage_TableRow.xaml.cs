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
    public partial class TicketsPage_TableRow : UserControl
    {
        public TicketsPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public LotteryTicketExport State
        {
            get { return (LotteryTicketExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(LotteryTicketExport), typeof(TicketsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                TicketsPage_TableRow tool = (TicketsPage_TableRow)d;
                LotteryTicketExport data = (LotteryTicketExport)e.NewValue;

                tool.text_Name.Text = data.Name;
                tool.text_Issue.Text = data.Issue;
                tool.text_LotteryValues.Text = data.LotteryValues;
                tool.text_Hide.Text = data.Hide ? "是" : "否";
                tool.text_Order.Text = data.Order.ToString();
            }));

        #endregion

        #region 刷新列表

        /// <summary>
        /// 当需要刷新列表时候触发
        /// </summary>
        public event EventHandler RefreshEventHandler;

        /// <summary>
        /// 触发刷新列表动作
        /// </summary>
        protected void OnRefresh(object sender, EventArgs e)
        {
            if (RefreshEventHandler == null) { return; }
            RefreshEventHandler(this, new EventArgs());
        }

        #endregion

        #region 显示详细信息

        private void ShowFullWindow(object sender, RoutedEventArgs e)
        {
            TicketsPage_EditWindow fw = new TicketsPage_EditWindow();
            fw.State = this.State;
            fw.Closed += ShowEditResult;
            fw.Show();
        }

        void ShowEditResult(object sender, EventArgs e)
        {
            TicketsPage_EditWindow fw = (TicketsPage_EditWindow)sender;
            if (fw.DialogResult != true) { return; }
            if (fw.Error == null)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "设置彩票信息成功";
                ep.Closed += OnRefresh;
                ep.Show();
            }
            else
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = fw.Error;
                ep.Show();
            }
        }

        #endregion
    }
}
