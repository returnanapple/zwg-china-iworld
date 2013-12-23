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
    public partial class VirtualBonusPage_CreateWindow : ChildWindow
    {
        LotteryServiceClient client = new LotteryServiceClient();

        public VirtualBonusPage_CreateWindow()
        {
            InitializeComponent();
            this.Loaded += InsertTickets;
            client.GetBasicLotteryTicketsCompleted += InsertTickets_do;
            client.CreateVirtualBonusCompleted += ShowCreateVirtualBonusResult;
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
            DependencyProperty.Register("Error", typeof(string), typeof(VirtualBonusPage_CreateWindow), new PropertyMetadata(null));

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
            input_tickets.SelectedIndex = 0;
        }

        #endregion

        #region 添加虚拟排行

        private void Create(object sender, RoutedEventArgs e)
        {
            int ticketId = ((BasicLotteryTicketExport)input_tickets.SelectedItem).Id;
            CreateVirtualBonusImport import = new CreateVirtualBonusImport
            {
                TicketId = ticketId,
                Sum = Convert.ToDouble(input_Sum.Text),
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.CreateVirtualBonusAsync(import);
        }

        void ShowCreateVirtualBonusResult(object sender, CreateVirtualBonusCompletedEventArgs e)
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

