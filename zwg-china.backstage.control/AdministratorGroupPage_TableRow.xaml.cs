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
    public partial class AdministratorGroupPage_TableRow : UserControl
    {
        public AdministratorGroupPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public AdministratorGroupExport State
        {
            get { return (AdministratorGroupExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(AdministratorGroupExport), typeof(AdministratorGroupPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                AdministratorGroupPage_TableRow tool = (AdministratorGroupPage_TableRow)d;
                AdministratorGroupExport data = (AdministratorGroupExport)e.NewValue;

                tool.text_Name.Text = data.Name;
                tool.text_CountOfCanDo.Text = data.CountOfCanDo.ToString();
                tool.text_IsCustomerService.Text = data.IsCustomerService ? "是" : "否";

                AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
                if (!aInfo.Group.CanEditAdministrator
                    || data.Name == "系统管理员")
                {
                    tool.button_Edit.Visibility = System.Windows.Visibility.Collapsed;
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

        #region 修改

        private void Edit(object sender, RoutedEventArgs e)
        {
            AdministratorGroupPage_EditWindow fw = new AdministratorGroupPage_EditWindow();
            fw.State = this.State;
            fw.Closed += ShowEditResult;
            fw.Show();
            fw.Show();
        }

        void ShowEditResult(object sender, EventArgs e)
        {
            AdministratorGroupPage_EditWindow fw = (AdministratorGroupPage_EditWindow)sender;
            if (fw.DialogResult != true) { return; }
            if (fw.Error == null)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "编辑管理员组成功";
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
            np.State = string.Format("你确定要删除管理员组 {0} 吗？注意：该操作不可逆转。", this.State.Name);
            np.Closed += Remove_do;
            np.Show();
        }

        void Remove_do(object sender, EventArgs e)
        {
            NormalPrompt np = (NormalPrompt)sender;
            if (np.DialogResult != true) { return; }
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);

            RemoveAdministratorGroupImport import = new RemoveAdministratorGroupImport
            {
                Id = this.State.Id,
                Token = aInfo.Token
            };
            AdministratorServiceClient client = new AdministratorServiceClient();
            client.RemoveAdministratorGroupCompleted += ShowRemoveResult;
            client.RemoveAdministratorGroupAsync(import);
        }

        void ShowRemoveResult(object sender, RemoveAdministratorGroupCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "删除管理员组成功";
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
