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
    public partial class UserGroupsPage_TableRow : UserControl
    {
        public UserGroupsPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public UserGroupExport State
        {
            get { return (UserGroupExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(UserGroupExport), typeof(UserGroupsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                UserGroupsPage_TableRow tool = (UserGroupsPage_TableRow)d;
                UserGroupExport data = (UserGroupExport)e.NewValue;

                tool.text_Name.Text = data.Name;
                tool.text_Grade.Text = data.Grade.ToString();
                tool.text_LowerOfConsumption.Text = data.LowerOfConsumption.ToString("0.00");
                tool.text_CapsOfConsumption.Text = data.CapsOfConsumption.ToString("0.00");

                AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
                if (aInfo.Group.CanEditUsers) { return; }
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
            UserGroupExport data = this.DataContext as UserGroupExport;
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            if (aInfo.Group.CanEditUsers)
            {
                UserGroupsPage_EditWindow fw = new UserGroupsPage_EditWindow();
                fw.State = data;
                fw.Closed += ShowEditUserGroupResult;
                fw.Show();
            }
            else
            {
                UserGroupsPage_FullWindow fw = new UserGroupsPage_FullWindow();
                fw.State = data;
                fw.Show();
            }
        }

        void ShowEditUserGroupResult(object sender, EventArgs e)
        {
            UserGroupsPage_EditWindow fw = (UserGroupsPage_EditWindow)sender;
            if (fw.DialogResult != true) { return; }
            if (fw.Error == null)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "编辑用户组成功";
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
            UserGroupExport data = this.DataContext as UserGroupExport;

            NormalPrompt np = new NormalPrompt();
            np.State = string.Format("你确定要删除 {0} 用户组吗？注意：该操作不可逆转。", data.Name);
            np.Closed += Remove_do;
            np.Show();
        }

        void Remove_do(object sender, EventArgs e)
        {
            NormalPrompt np = (NormalPrompt)sender;
            if (np.DialogResult != true) { return; }
            UserGroupExport data = this.DataContext as UserGroupExport;
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);

            RemoveGroupImport import = new RemoveGroupImport
            {
                Id = data.Id,
                Token = aInfo.Token
            };
            AuthorServiceClient client = new AuthorServiceClient();
            client.RemoveUserGroupCompleted += ShowRemoveResult;
            client.RemoveUserGroupAsync(import);
        }

        void ShowRemoveResult(object sender, RemoveUserGroupCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "删除用户组成功";
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
