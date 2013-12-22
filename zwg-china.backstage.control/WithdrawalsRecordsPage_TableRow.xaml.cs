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
using zwg_china.backstage.framework.RecordOfAuthorService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.control
{
    public partial class WithdrawalsRecordsPage_TableRow : UserControl
    {
        public WithdrawalsRecordsPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public WithdrawalsRecordExport State
        {
            get { return (WithdrawalsRecordExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(WithdrawalsRecordExport), typeof(WithdrawalsRecordsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                WithdrawalsRecordsPage_TableRow tool = (WithdrawalsRecordsPage_TableRow)d;
                WithdrawalsRecordExport data = (WithdrawalsRecordExport)e.NewValue;

                tool.text_Owner.Text = data.Owner;
                tool.text_Sum.Text = data.Sum.ToString("0.00");
                tool.text_CreatedTime.Text = data.CreatedTime.ToLongDateString();
                tool.text_Status.Text = data.Status.ToString();
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

        #region 显示详细信息

        private void ShowFullWindow(object sender, EventArgs e)
        {
            WithdrawalsRecordsPage_FullWindow fw = new WithdrawalsRecordsPage_FullWindow();
            fw.State = this.State;
            fw.Closed += DoWork;
            fw.Show();
        }

        void DoWork(object sender, EventArgs e)
        {
            WithdrawalsRecordsPage_FullWindow fw = (WithdrawalsRecordsPage_FullWindow)sender;
            if (fw.DialogResult != true) { return; }
            if (fw.Agree)
            {
                NormalPrompt np = new NormalPrompt();
                np.State = string.Format("你确定要 确认 额度为 {0} (用户：{1})的提现申请码？"
                    , this.State.Sum.ToString("0.00")
                    , this.State.Owner);
                np.Closed += Confirm_do;
                np.Show();
            }
            else
            {
                NormalPrompt np = new NormalPrompt();
                np.State = string.Format("你确定要 否决 额度为 {0} (用户：{1})的提现申请码？"
                    , this.State.Sum.ToString("0.00")
                    , this.State.Owner);
                np.Closed += Veto_do;
                np.Show();
            }
        }

        void Confirm_do(object sender, EventArgs e)
        {
            NormalPrompt cw = (NormalPrompt)sender;
            if (cw.DialogResult == true)
            {
                SetWithdrawslsStatusImport import = new SetWithdrawslsStatusImport
                {
                    WithdrawalsId = this.State.Id,
                    NewStatus = WithdrawalsStatus.提现成功,
                    Remark = "",
                    Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
                };
                RecordOfAuthorServiceClient client = new RecordOfAuthorServiceClient();
                client.SetWithdrawslsStatusCompleted += ShowDoWorkResult;
            }
            else
            {
                ShowFullWindow(null, null);
            }
        }

        void Veto_do(object sender, EventArgs e)
        {
            NormalPrompt cw = (NormalPrompt)sender;
            if (cw.DialogResult == true)
            {
                SetWithdrawslsStatusImport import = new SetWithdrawslsStatusImport
                {
                    WithdrawalsId = this.State.Id,
                    NewStatus = WithdrawalsStatus.失败,
                    Remark = "管理员否决",
                    Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
                };
                RecordOfAuthorServiceClient client = new RecordOfAuthorServiceClient();
                client.SetWithdrawslsStatusCompleted += ShowDoWorkResult;
            }
            else
            {
                ShowFullWindow(null, null);
            }
        }

        void ShowDoWorkResult(object sender, SetWithdrawslsStatusCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "操作成功";
                ep.Closed += OnRefresh;
                ep.Show();
            }
            else
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = e.Result.Error;
                ep.Closed += ShowFullWindow;
                ep.Show();
            }
        }

        #endregion
    }
}
