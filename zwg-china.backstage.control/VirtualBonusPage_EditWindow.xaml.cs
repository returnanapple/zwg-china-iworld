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
    public partial class VirtualBonusPage_EditWindow : ChildWindow
    {
        LotteryServiceClient client = new LotteryServiceClient();

        public VirtualBonusPage_EditWindow()
        {
            InitializeComponent();
            this.Loaded += InsertTickets;
            client.GetBasicLotteryTicketsCompleted += InsertTickets_do;
            client.EditVirtualBonusCompleted += ShowEditResult;
        }

        #region 错误信息

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error
        {
            get { return (string)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }

        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(string), typeof(VirtualBonusPage_EditWindow), new PropertyMetadata(null));

        #endregion

        #region 附加内容

        public VirtualBonusExport State
        {
            get { return (VirtualBonusExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(VirtualBonusExport), typeof(VirtualBonusPage_EditWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                VirtualBonusPage_EditWindow tool = (VirtualBonusPage_EditWindow)d;
                VirtualBonusExport data = (VirtualBonusExport)e.NewValue;

                tool.input_Sum.Text = data.Sum.ToString("0.00");
            }));

        #endregion

        #region 填充彩票下拉选单

        void InsertTickets(object sender, RoutedEventArgs e)
        {
            GetBasicLotteryTicketsImport import = new GetBasicLotteryTicketsImport
            {
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetBasicLotteryTicketsAsync(import);
        }

        void InsertTickets_do(object sender, GetBasicLotteryTicketsCompletedEventArgs e)
        {
            if (!e.Result.Success) { return; }
            input_tickets.ItemsSource = e.Result.Info;
            input_tickets.SelectedItem = e.Result.Info.First(x => x.Id == this.State.Id);
        }

        #endregion

        #region 编辑虚拟排行

        private void Edit(object sender, RoutedEventArgs e)
        {
            int ticketId = ((BasicLotteryTicketExport)input_tickets.SelectedItem).Id;
            EditVirtualBonusImport import = new EditVirtualBonusImport
            {
                Id = this.State.Id,
                TicketId = ticketId,
                Sum = Convert.ToDouble(input_Sum.Text),
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.EditVirtualBonusAsync(import);
        }

        void ShowEditResult(object sender, EditVirtualBonusCompletedEventArgs e)
        {
            if (!e.Result.Success)
            {
                this.Error = e.Result.Error;
            }
            this.DialogResult = true;
        }

        #endregion

        #region 取消

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion
    }
}

