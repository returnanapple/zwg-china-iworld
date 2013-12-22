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
using zwg_china.backstage.framework.RecordOfAuthorService;
using zwg_china.backstage.framework.AdministratorService;
using zwg_china.backstage.framework;

namespace zwg_china.backstage.control
{
    public partial class RechargeRecordsPage_CreateWindow : ChildWindow
    {
        public RechargeRecordsPage_CreateWindow()
        {
            InitializeComponent();
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
            DependencyProperty.Register("Error", typeof(string), typeof(RechargeRecordsPage_CreateWindow), new PropertyMetadata(null));

        #endregion

        #region 方法

        private void Create(object sender, RoutedEventArgs e)
        {
            CreateRechargeRecordImport import = new CreateRechargeRecordImport
            {
                Owner = input_Owner.Text,
                Sum = Math.Round(Convert.ToDouble(input_Sum.Text), 2),
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            RecordOfAuthorServiceClient client = new RecordOfAuthorServiceClient();
            client.CreateRechargeRecordCompleted += ShowCreateResult;
            client.CreateRechargeRecordAsync(import);
        }
        #region 创建结果

        void ShowCreateResult(object sender, CreateRechargeRecordCompletedEventArgs e)
        {
            if (!e.Result.Success)
            {
                this.Error = e.Result.Error;
            }
            this.DialogResult = true;
        }

        #endregion

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion
    }
}

