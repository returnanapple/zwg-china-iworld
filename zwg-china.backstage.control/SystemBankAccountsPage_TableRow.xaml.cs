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
using zwg_china.backstage.framework.SettingOfAuthorService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.control
{
    public partial class SystemBankAccountsPage_TableRow : UserControl
    {
        public SystemBankAccountsPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public SystemBankAccountExport State
        {
            get { return (SystemBankAccountExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(SystemBankAccountExport), typeof(SystemBankAccountsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                SystemBankAccountsPage_TableRow tool = (SystemBankAccountsPage_TableRow)d;
                SystemBankAccountExport data = (SystemBankAccountExport)e.NewValue;

                tool.text_Card.Text = data.Card;
                tool.text_HolderOfTheCard.Text = data.HolderOfTheCard;
                tool.text_BankOfTheCard.Text = data.BankOfTheCard.ToString();
                tool.text_Remark.Text = data.Remark;

                AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
                if (aInfo.Group.CanEditSettings) { return; }
                tool.button_Remove.Visibility = System.Windows.Visibility.Collapsed;
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

        #region 显示详细信息弹窗

        private void ShowFullWindow(object sender, RoutedEventArgs e)
        {
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            if (aInfo.Group.CanEditUsers)
            {
                SystemBankAccountsPage_EditWindow fw = new SystemBankAccountsPage_EditWindow();
                fw.State = this.State;
                fw.Closed += ShowEditUserResult;
                fw.Show();
            }
            else
            {
                SystemBankAccountsPage_FullWindow fw = new SystemBankAccountsPage_FullWindow();
                fw.State = this.State;
                fw.Show();
            }
        }

        void ShowEditUserResult(object sender, EventArgs e)
        {
            SystemBankAccountsPage_EditWindow fw = (SystemBankAccountsPage_EditWindow)sender;
            if (fw.DialogResult != true) { return; }
            if (fw.Error == null)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "编辑用户信息成功";
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

        #region 删除

        private void Remove(object sender, RoutedEventArgs e)
        {
            NormalPrompt np = new NormalPrompt();
            np.State = string.Format("你确定要删除卡号为 {0} 的银行账户吗？注意：该操作不可逆转。", this.State.Card);
            np.Closed += Remove_do;
            np.Show();
        }

        void Remove_do(object sender, EventArgs e)
        {
            NormalPrompt np = (NormalPrompt)sender;
            if (np.DialogResult != true) { return; }
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);

            RemoveSystemBankAccountImport import = new RemoveSystemBankAccountImport
            {
                Id = this.State.Id,
                Token = aInfo.Token
            };
            SettingOfAuthorServiceClient client = new SettingOfAuthorServiceClient();
            client.RemoveSystemBankAccountCompleted += ShowRemoveResult;
            client.RemoveSystemBankAccountAsync(import);
        }

        void ShowRemoveResult(object sender, RemoveSystemBankAccountCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "删除银行账户成功";
                ep.Closed += OnRefresh;
                ep.Show();
            }
            else
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = e.Result.Error;
                ep.Show();
            }
        }

        #endregion
    }
}
