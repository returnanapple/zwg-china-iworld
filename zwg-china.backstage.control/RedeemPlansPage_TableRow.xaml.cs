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
using zwg_china.backstage.framework.ActicityService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.control
{
    public partial class RedeemPlansPage_TableRow : UserControl
    {
        public RedeemPlansPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public RedeemPlanExport State
        {
            get { return (RedeemPlanExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(RedeemPlanExport), typeof(RedeemPlansPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                RedeemPlansPage_TableRow tool = (RedeemPlansPage_TableRow)d;
                RedeemPlanExport data = (RedeemPlanExport)e.NewValue;
                tool.text_Title.Text = data.Title;
                tool.text_Status.Text = data.Status.ToString();

                AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
                if (aInfo.Group.CanEditActivities) { return; }
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
            if (aInfo.Group.CanEditActivities)
            {
                RedeemPlansPage_EditWindow fw = new RedeemPlansPage_EditWindow();
                fw.State = this.State;
                fw.Closed += ShowEditResult;
                fw.Show();
            }
            else
            {
                RedeemPlansPage_FullWindow fw = new RedeemPlansPage_FullWindow();
                fw.State = this.State;
                fw.Show();
            }
        }

        void ShowEditResult(object sender, EventArgs e)
        {
            RedeemPlansPage_EditWindow fw = (RedeemPlansPage_EditWindow)sender;
            if (fw.DialogResult != true) { return; }
            if (fw.Error == null)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "编辑活动成功";
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
            np.State = string.Format("你确定要删除积分兑换 {0} 吗？注意：该操作不可逆转。", this.State.Title);
            np.Closed += Remove_do;
            np.Show();
        }

        void Remove_do(object sender, EventArgs e)
        {
            NormalPrompt np = (NormalPrompt)sender;
            if (np.DialogResult != true) { return; }
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);

            RemoveRedeemPlanImport import = new RemoveRedeemPlanImport
            {
                Id = this.State.Id,
                Token = aInfo.Token
            };
            ActicityServiceClient client = new ActicityServiceClient();
            client.RemoveRedeemPlanCompleted += ShowRemoveResult;
            client.RemoveRedeemPlanAsync(import);
        }

        void ShowRemoveResult(object sender, RemoveRedeemPlanCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "删除活动成功";
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
