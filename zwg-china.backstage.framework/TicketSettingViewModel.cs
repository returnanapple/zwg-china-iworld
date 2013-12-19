using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.LotteryService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 彩票模块设置页的视图模型
    /// </summary>
    public class TicketSettingViewModel : ManagerViewModelBase
    {
        #region 私有字段

        double unitPrice = 0;
        int payoutBase = 0;
        int lineForProhibitBetting = 0;
        int maximumPayout = 0;
        double conversionRates = 0;
        int maximumBetsNumber = 0;
        int closureSingleTime = 0;

        LotteryServiceClient client = new LotteryServiceClient();

        #endregion

        #region 属性

        /// <summary>
        /// 单注价格
        /// </summary>
        public double UnitPrice
        {
            get { return unitPrice; }
            set
            {
                if (unitPrice == value) { return; }
                unitPrice = value;
                OnPropertyChanged("UnitPrice");
            }
        }

        /// <summary>
        /// 返奖基数
        /// （2 : n）
        /// </summary>
        public int PayoutBase
        {
            get { return payoutBase; }
            set
            {
                if (payoutBase == value) { return; }
                payoutBase = value;
                OnPropertyChanged("PayoutBase");
            }
        }

        /// <summary>
        /// 禁止投注的基数线
        /// </summary>
        public int LineForProhibitBetting
        {
            get { return lineForProhibitBetting; }
            set
            {
                if (lineForProhibitBetting == value) { return; }
                lineForProhibitBetting = value;
                OnPropertyChanged("LineForProhibitBetting");
            }
        }

        /// <summary>
        /// 返奖金额上限
        /// </summary>
        public int MaximumPayout
        {
            get { return maximumPayout; }
            set
            {
                if (maximumPayout == value) { return; }
                maximumPayout = value;
                OnPropertyChanged("MaximumPayout");
            }
        }

        /// <summary>
        /// 奖金 - 返点换算率
        /// </summary>
        public double ConversionRates
        {
            get { return conversionRates; }
            set
            {
                if (conversionRates == value) { return; }
                conversionRates = value;
                OnPropertyChanged("ConversionRates");
            }
        }

        /// <summary>
        /// 最大投注倍数
        /// </summary>
        public int MaximumBetsNumber
        {
            get { return maximumBetsNumber; }
            set
            {
                if (maximumBetsNumber == value) { return; }
                maximumBetsNumber = value;
                OnPropertyChanged("MaximumBetsNumber");
            }
        }

        /// <summary>
        /// 封单时间（秒）
        /// </summary>
        public int ClosureSingleTime
        {
            get { return closureSingleTime; }
            set
            {
                if (closureSingleTime == value) { return; }
                closureSingleTime = value;
                OnPropertyChanged("ClosureSingleTime");
            }
        }

        /// <summary>
        /// 刷新命令
        /// </summary>
        public UniversalCommand RefreshCommand { get; set; }

        /// <summary>
        /// 修改命令
        /// </summary>
        public UniversalCommand EditCommand { get; set; }

        #endregion

        #region 构造方法

        public TicketSettingViewModel()
            : base("系统设置", "彩票模块设置")
        {
            this.RefreshCommand = new UniversalCommand(Refresh);
            this.EditCommand = new UniversalCommand(Edit);

            client.GetSettingOfLotteryCompleted += ShowSetting;
            client.SetSettingOfLotteryCompleted += ShowEditResult;
            Refresh();
        }

        #region 显示设置明细

        void ShowSetting(object sender, GetSettingOfLotteryCompletedEventArgs e)
        {
            this.UnitPrice = e.Result.Info.UnitPrice;
            this.PayoutBase = e.Result.Info.PayoutBase;
            this.LineForProhibitBetting = e.Result.Info.LineForProhibitBetting;
            this.MaximumPayout = e.Result.Info.MaximumPayout;
            this.ConversionRates = e.Result.Info.ConversionRates;
            this.MaximumBetsNumber = e.Result.Info.MaximumBetsNumber;
            this.ClosureSingleTime = e.Result.Info.ClosureSingleTime;
        }

        #endregion

        #endregion

        #region 私有方法

        void Refresh(object obj = null)
        {
            GetSettingOfLotteryImport import = new GetSettingOfLotteryImport
            {
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetSettingOfLotteryAsync(import);
        }

        void Edit(object obj = null)
        {
            IPop<string> cw = ViewModelService.GetPop(Pop.NormalPrompt) as IPop<string>;
            cw.State = "你确定要修改用户模块设置吗？";
            cw.Closed += Edit_do;
            cw.Show();
        }

        void Edit_do(object sender, EventArgs e)
        {
            IPop cw = (IPop)sender;
            if (cw.DialogResult != true) { return; }

            SetSettingOfLotteryImport import = new SetSettingOfLotteryImport
            {
                UnitPrice = this.UnitPrice,
                PayoutBase = this.PayoutBase,
                LineForProhibitBetting = this.LineForProhibitBetting,
                MaximumPayout = this.MaximumPayout,
                ConversionRates = this.ConversionRates,
                MaximumBetsNumber = this.MaximumBetsNumber,
                ClosureSingleTime = this.ClosureSingleTime,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.SetSettingOfLotteryAsync(import);
        }
        void ShowEditResult(object sender, SetSettingOfLotteryCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                ShowError("修改成功");
                Refresh();
            }
            else
            {
                ShowError(e.Result.Error);
            }
        }

        #endregion
    }
}
