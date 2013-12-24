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
    public partial class RewardForConsumptionPlansPage_TableRow : UserControl
    {
        public RewardForConsumptionPlansPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容
        public RewardForConsumptionPlanExport State
        {
            get { return (RewardForConsumptionPlanExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(RewardForConsumptionPlanExport), typeof(RewardForConsumptionPlansPage_TableRow), new PropertyMetadata(null, (d, e) =>
            {
                RewardForConsumptionPlansPage_TableRow tool = (RewardForConsumptionPlansPage_TableRow)d;
                RewardForConsumptionPlanExport data = (RewardForConsumptionPlanExport)e.NewValue;
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
            RewardForConsumptionPlanExport data = this.DataContext as RewardForConsumptionPlanExport;
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            if (aInfo.Group.CanEditActivities)
            {
                RewardForConsumptionPlansPage_EditWindow fw = new RewardForConsumptionPlansPage_EditWindow();
                fw.State = data;
                fw.Closed += ShowEditRewardForRegisterPlanResult;
                fw.Show();
            }
            else
            {
                RewardForConsumptionPlansPage_FullWindow fw = new RewardForConsumptionPlansPage_FullWindow();
                fw.State = data;
                fw.Show();
            }
        }

        void ShowEditRewardForRegisterPlanResult(object sender, EventArgs e)
        {
            RewardForConsumptionPlansPage_EditWindow fw = (RewardForConsumptionPlansPage_EditWindow)sender;
            if (fw.DialogResult != true) { return; }
            if (fw.Error == null)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "编辑消费奖励成功";
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
            np.State = string.Format("你确定要删除消费奖励 {0} 吗？注意：该操作不可逆转。", this.State.Title);
            np.Closed += Remove_do;
            np.Show();
        }

        void Remove_do(object sender, EventArgs e)
        {
            NormalPrompt np = (NormalPrompt)sender;
            if (np.DialogResult != true) { return; }
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);

            RemoveRewardForConsumptionPlanImport import = new RemoveRewardForConsumptionPlanImport
            {
                Id = this.State.Id,
                Token = aInfo.Token
            };
            ActicityServiceClient client = new ActicityServiceClient();
            client.RemoveRewardForConsumptionPlanCompleted += ShowRemoveResult;
            client.RemoveRewardForConsumptionPlanAsync(import);
        }
        void ShowRemoveResult(object sender, RemoveRewardForConsumptionPlanCompletedEventArgs e)
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
