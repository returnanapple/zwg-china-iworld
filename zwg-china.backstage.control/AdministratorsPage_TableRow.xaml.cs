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

namespace zwg_china.backstage.control
{
    public partial class AdministratorsPage_TableRow : UserControl
    {
        public AdministratorsPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public BasicAdministratorExport State
        {
            get { return (BasicAdministratorExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(BasicAdministratorExport), typeof(AdministratorsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                AdministratorsPage_TableRow tool = (AdministratorsPage_TableRow)d;
                BasicAdministratorExport data = (BasicAdministratorExport)e.NewValue;

                tool.text_Username.Text = data.Username;
                tool.text_Group.Text = data.Group;
                tool.text_LastLoginTime.Text = data.LastLoginTime.ToLongDateString();
                tool.text_LastLoginIp.Text = data.LastLoginIp;
                tool.text_LastLoginAddress.Text = data.LastLoginAddress;

                AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
                if (!aInfo.Group.CanEditAdministrator
                    || aInfo.Id == data.Id)
                {
                    tool.button_EditAdministrator.Visibility = System.Windows.Visibility.Collapsed;
                    tool.button_Remove.Visibility = System.Windows.Visibility.Collapsed;
                }
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

        #region 编辑管理员

        private void EditAdministrator(object sender, RoutedEventArgs e)
        {
            BasicAdministratorExport data = this.DataContext as BasicAdministratorExport;
            AdministratorsPage_EditWindow fw = new AdministratorsPage_EditWindow();
            fw.State = data;
            fw.Closed += ShowEditUserGroupResult;
            fw.Show();
            fw.Show();
        }

        void ShowEditUserGroupResult(object sender, EventArgs e)
        {
            AdministratorsPage_EditWindow fw = (AdministratorsPage_EditWindow)sender;
            if (fw.DialogResult != true) { return; }
            if (fw.Error == null)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "编辑管理员成功";
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

        #region 移除

        private void Remove(object sender, RoutedEventArgs e)
        {
            NormalPrompt np = new NormalPrompt();
            np.State = string.Format("你确定要删除管理员 {0} 吗？注意：该操作不可逆转。", this.State.Username);
            np.Closed += Remove_do;
            np.Show();
        }

        void Remove_do(object sender, EventArgs e)
        {
            NormalPrompt np = (NormalPrompt)sender;
            if (np.DialogResult != true) { return; }
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);

            RemoveAdministratorImport import = new RemoveAdministratorImport
            {
                Id = this.State.Id,
                Token = aInfo.Token
            };
            AdministratorServiceClient client = new AdministratorServiceClient();
            client.RemoveAdministratorCompleted += ShowRemoveResult;
            client.RemoveAdministratorAsync(import);
        }

        void ShowRemoveResult(object sender, RemoveAdministratorCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "删除管理员成功";
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
