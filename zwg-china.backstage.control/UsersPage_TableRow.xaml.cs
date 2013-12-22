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
using zwg_china.backstage.framework.AuthorService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.control
{
    public partial class UsersPage_TableRow : UserControl
    {
        public UsersPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public AuthorExport State
        {
            get { return (AuthorExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(AuthorExport), typeof(UsersPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                UsersPage_TableRow tool = (UsersPage_TableRow)d;
                AuthorExport data = (AuthorExport)e.NewValue;

                tool.text_Username.Text = data.Username;
                tool.text_Group.Text = data.Group.Name;
                tool.text_Money.Text = data.Money.ToString("0.00");
                tool.text_Consumption.Text = data.Consumption.ToString("0.00");
                tool.text_LastLoginTime.Text = data.LastLoginTime.ToLongDateString();

                AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
                if (aInfo.Group.CanEditUsers) { return; }
                tool.button_Remove.Visibility = System.Windows.Visibility.Collapsed;
                tool.button_ShowUserQuotasWindow.Visibility = System.Windows.Visibility.Collapsed;
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
        protected void OnRefresh(object sender,EventArgs e)
        {
            if (RefreshEventHandler == null) { return; }
            RefreshEventHandler(this, new EventArgs());
        }

        #endregion

        #region 显示详细信息弹窗

        private void ShowFullWindow(object sender, RoutedEventArgs e)
        {
            AuthorExport data = this.DataContext as AuthorExport;
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            if (aInfo.Group.CanEditUsers)
            {
                UsersPage_EditWindow fw = new UsersPage_EditWindow();
                fw.State = data;
                fw.Closed += ShowEditUserResult;
                fw.Show();
            }
            else
            {
                UsersPage_FullWindow fw = new UsersPage_FullWindow();
                fw.State = data;
                fw.Show();
            }
        }

        void ShowEditUserResult(object sender, EventArgs e)
        {
            UsersPage_EditWindow fw = (UsersPage_EditWindow)sender;
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

        #region 修改用户的额外配额

        private void ShowSetExtraQuotasWindow(object sender, RoutedEventArgs e)
        {
            AuthorExport data = this.DataContext as AuthorExport;
            UsersPage_SetExtraQuotasWindow fw = new UsersPage_SetExtraQuotasWindow();
            fw.State = data;
            fw.Closed += ShowSetExtraQuotasResult;
            fw.Show();
        }

        void ShowSetExtraQuotasResult(object sender, EventArgs e)
        {
            UsersPage_SetExtraQuotasWindow fw = (UsersPage_SetExtraQuotasWindow)sender;
            if (fw.DialogResult != true) { return; }
            if (fw.Error == null)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "修改用户的额外配额成功";
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

        #region 删除用户

        private void Remove(object sender, RoutedEventArgs e)
        {
            NormalPrompt np = new NormalPrompt();
            np.State = string.Format("你确定要删除用户 {0} 吗？注意：该操作不可逆转。", this.State.Username);
            np.Closed += Remove_do;
            np.Show();
        }

        void Remove_do(object sender, EventArgs e)
        {
            NormalPrompt np = (NormalPrompt)sender;
            if (np.DialogResult != true) { return; }
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);

            RemoveUserImport import = new RemoveUserImport
            {
                Id = this.State.Id,
                Token = aInfo.Token
            };
            AuthorServiceClient client = new AuthorServiceClient();
            client.RemoveUserCompleted += ShowRemoveResult;
            client.RemoveUserAsync(import);
        }

        void ShowRemoveResult(object sender, RemoveUserCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "删除用户成功";
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
