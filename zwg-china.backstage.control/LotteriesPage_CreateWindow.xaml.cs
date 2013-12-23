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
    public partial class LotteriesPage_CreateWindow : ChildWindow
    {
        LotteryServiceClient client = new LotteryServiceClient();

        public LotteriesPage_CreateWindow()
        {
            InitializeComponent();
            this.Loaded += InsertTickets;
            client.GetBasicLotteryTicketsCompleted += InsertTickets_do;
            client.CreateLotteryCompleted += ShowCreateResult;
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
            DependencyProperty.Register("Error", typeof(string), typeof(LotteriesPage_CreateWindow), new PropertyMetadata(null));

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
            input_tickets.SelectedItem = 0;
        }

        #endregion

        #region 创建开奖记录

        private void Create(object sender, RoutedEventArgs e)
        {
            int ticketId = ((BasicLotteryTicketExport)input_tickets.SelectedItem).Id;
            CreateLotteryImport import = new CreateLotteryImport
            {
                TicketId = ticketId,
                Issue = input_Issue.Text,
                Values = input_Values.Text,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.CreateLotteryAsync(import);
        }

        void ShowCreateResult(object sender, CreateLotteryCompletedEventArgs e)
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

