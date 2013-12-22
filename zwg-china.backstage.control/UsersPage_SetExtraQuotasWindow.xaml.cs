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
using zwg_china.backstage.framework.AuthorService;

namespace zwg_china.backstage.control
{
    public partial class UsersPage_SetExtraQuotasWindow : ChildWindow
    {
        public UsersPage_SetExtraQuotasWindow()
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
            DependencyProperty.Register("Error", typeof(string), typeof(UsersPage_SetExtraQuotasWindow), new PropertyMetadata(null));

        #endregion

        #region 附加内容

        public AuthorExport State
        {
            get { return (AuthorExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(AuthorExport), typeof(UsersPage_SetExtraQuotasWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                UsersPage_SetExtraQuotasWindow tool = (UsersPage_SetExtraQuotasWindow)d;
                AuthorExport data = (AuthorExport)e.NewValue;

                tool.text_UserQuotas_130.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0).Surplus.ToString();
                tool.text_UserQuotas_129.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.9).Surplus.ToString();
                tool.text_UserQuotas_128.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.8).Surplus.ToString();
                tool.text_UserQuotas_127.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.7).Surplus.ToString();
                tool.text_UserQuotas_126.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.6).Surplus.ToString();
                tool.text_UserQuotas_125.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.5).Surplus.ToString();
                tool.text_UserQuotas_124.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.4).Surplus.ToString();
                tool.text_UserQuotas_123.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.3).Surplus.ToString();
                tool.text_UserQuotas_122.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.2).Surplus.ToString();
                tool.text_UserQuotas_121.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.1).Surplus.ToString();

                tool.input_ExtraQuotas_130.Text = data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 13.0).Sum.ToString();
                tool.input_ExtraQuotas_129.Text = data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 12.9).Sum.ToString();
                tool.input_ExtraQuotas_128.Text = data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 12.8).Sum.ToString();
                tool.input_ExtraQuotas_127.Text = data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 12.7).Sum.ToString();
                tool.input_ExtraQuotas_126.Text = data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 12.6).Sum.ToString();
                tool.input_ExtraQuotas_125.Text = data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 12.5).Sum.ToString();
                tool.input_ExtraQuotas_124.Text = data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 12.4).Sum.ToString();
                tool.input_ExtraQuotas_123.Text = data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 12.3).Sum.ToString();
                tool.input_ExtraQuotas_122.Text = data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 12.2).Sum.ToString();
                tool.input_ExtraQuotas_121.Text = data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.ExtraQuotas.FirstOrDefault(x => x.Rebate == 12.1).Sum.ToString();
            }));

        #endregion

        #region 执行

        private void SetExtraQuotas(object sender, RoutedEventArgs e)
        {
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            List<SetExtraQuotasImport.ExtraQuotaImport> eqs = new List<SetExtraQuotasImport.ExtraQuotaImport>();

            eqs.Add(new SetExtraQuotasImport.ExtraQuotaImport { Rebate = 13.0, Sum = Convert.ToInt32(input_ExtraQuotas_130.Text) });
            eqs.Add(new SetExtraQuotasImport.ExtraQuotaImport { Rebate = 12.9, Sum = Convert.ToInt32(input_ExtraQuotas_129.Text) });
            eqs.Add(new SetExtraQuotasImport.ExtraQuotaImport { Rebate = 12.8, Sum = Convert.ToInt32(input_ExtraQuotas_128.Text) });
            eqs.Add(new SetExtraQuotasImport.ExtraQuotaImport { Rebate = 12.7, Sum = Convert.ToInt32(input_ExtraQuotas_127.Text) });
            eqs.Add(new SetExtraQuotasImport.ExtraQuotaImport { Rebate = 12.6, Sum = Convert.ToInt32(input_ExtraQuotas_126.Text) });
            eqs.Add(new SetExtraQuotasImport.ExtraQuotaImport { Rebate = 12.5, Sum = Convert.ToInt32(input_ExtraQuotas_125.Text) });
            eqs.Add(new SetExtraQuotasImport.ExtraQuotaImport { Rebate = 12.4, Sum = Convert.ToInt32(input_ExtraQuotas_124.Text) });
            eqs.Add(new SetExtraQuotasImport.ExtraQuotaImport { Rebate = 12.3, Sum = Convert.ToInt32(input_ExtraQuotas_123.Text) });
            eqs.Add(new SetExtraQuotasImport.ExtraQuotaImport { Rebate = 12.2, Sum = Convert.ToInt32(input_ExtraQuotas_122.Text) });
            eqs.Add(new SetExtraQuotasImport.ExtraQuotaImport { Rebate = 12.1, Sum = Convert.ToInt32(input_ExtraQuotas_121.Text) });

            SetExtraQuotasImport import = new SetExtraQuotasImport
            {
                Id = this.State.Id,
                ExtraQuotas = eqs,
                Token = aInfo.Token
            };
            AuthorServiceClient client = new AuthorServiceClient();
            client.SetExtraQuotasCompleted += ShowSetExtraQuotasResult;
            client.SetExtraQuotasAsync(import);
        }

        void ShowSetExtraQuotasResult(object sender, SetExtraQuotasCompletedEventArgs e)
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

