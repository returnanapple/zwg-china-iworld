using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.SettingOfAuthorService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 用户模块设置页的视图模型
    /// </summary>
    public class AuthorSettingViewModel : ManagerViewModelBase
    {
        #region 私有字段

        double lowerRebate = 0;
        double capsRebate = 0;
        double lowerRebateOfHigh = 0;
        double capsRebateOfHigh = 0;

        int rechargeRecordTimeout = 0;
        int spreadRecordTimeout = 0;
        int forgotPasswordRecordTimeout = 0;

        string dysOfDividend = "";

        int timesOfWithdrawal = 0;
        double minimumWithdrawalAmount = 0;
        double maximumWithdrawalAmount = 0;

        double commission_A = 0;
        double commission_B = 0;
        double lowerConsumptionForCommission = 0;
        double dividend_A = 0;
        double dividend_B = 0;
        double lowerConsumptionForDividend = 0;

        int clearUser_DaysOfInactive = 0;
        int clearUser_DaysOfUnSetIn = 0;
        double clearUser_LowerOfMoney = 0;
        int clearUser_DaysOfUnMoneyChange = 0;

        SettingOfAuthorServiceClient client = new SettingOfAuthorServiceClient();

        #endregion

        #region 属性

        /// <summary>
        /// 允许设置的最低返点
        /// </summary>
        public double LowerRebate
        {
            get { return lowerRebate; }
            set
            {
                if (lowerRebate == value) { return; }
                lowerRebate = value;
                OnPropertyChanged("LowerRebate");
            }
        }

        /// <summary>
        /// 允许设置的最高返点
        /// </summary>
        public double CapsRebate
        {
            get { return capsRebate; }
            set
            {
                if (capsRebate == value) { return; }
                capsRebate = value;
                OnPropertyChanged("CapsRebate");
            }
        }

        /// <summary>
        /// “高点号”定义的下限
        /// </summary>
        public double LowerRebateOfHigh
        {
            get { return lowerRebateOfHigh; }
            set
            {
                if (lowerRebateOfHigh == value) { return; }
                lowerRebateOfHigh = value;
                OnPropertyChanged("LowerRebateOfHigh");
            }
        }

        /// <summary>
        /// “高点号”定义的上限
        /// </summary>
        public double CapsRebateOfHigh
        {
            get { return capsRebateOfHigh; }
            set
            {
                if (capsRebateOfHigh == value) { return; }
                capsRebateOfHigh = value;
                OnPropertyChanged("CapsRebateOfHigh");
            }
        }

        /// <summary>
        /// 充值记录超时时间（小时）
        /// </summary>
        public int RechargeRecordTimeout
        {
            get { return rechargeRecordTimeout; }
            set
            {
                if (rechargeRecordTimeout == value) { return; }
                rechargeRecordTimeout = value;
                OnPropertyChanged("RechargeRecordTimeout");
            }
        }

        /// <summary>
        /// 推广记录超时时间（小时）
        /// </summary>
        public int SpreadRecordTimeout
        {
            get { return spreadRecordTimeout; }
            set
            {
                if (spreadRecordTimeout == value) { return; }
                spreadRecordTimeout = value;
                OnPropertyChanged("SpreadRecordTimeout");
            }
        }

        /// <summary>
        /// 找回密码记录超时时间（小时）
        /// </summary>
        public int ForgotPasswordRecordTimeout
        {
            get { return forgotPasswordRecordTimeout; }
            set
            {
                if (forgotPasswordRecordTimeout == value) { return; }
                forgotPasswordRecordTimeout = value;
                OnPropertyChanged("ForgotPasswordRecordTimeout");
            }
        }

        /// <summary>
        /// 分红日
        /// </summary>
        public string DaysOfDividend
        {
            get { return dysOfDividend; }
            set
            {
                if (dysOfDividend == value) { return; }
                dysOfDividend = value;
                OnPropertyChanged("DaysOfDividend");
            }
        }

        /// <summary>
        /// 每日允许提现次数
        /// </summary>
        public int TimesOfWithdrawal
        {
            get { return timesOfWithdrawal; }
            set
            {
                if (timesOfWithdrawal == value) { return; }
                timesOfWithdrawal = value;
                OnPropertyChanged("TimesOfWithdrawal");
            }
        }

        /// <summary>
        /// 单笔最低取款金额
        /// </summary>
        public double MinimumWithdrawalAmount
        {
            get { return minimumWithdrawalAmount; }
            set
            {
                if (minimumWithdrawalAmount == value) { return; }
                minimumWithdrawalAmount = value;
                OnPropertyChanged("MinimumWithdrawalAmount");
            }
        }

        /// <summary>
        /// 单笔最高取款金额
        /// </summary>
        public double MaximumWithdrawalAmount
        {
            get { return maximumWithdrawalAmount; }
            set
            {
                if (maximumWithdrawalAmount == value) { return; }
                maximumWithdrawalAmount = value;
                OnPropertyChanged("MaximumWithdrawalAmount");
            }
        }

        /// <summary>
        /// 一级佣金
        /// </summary>
        public double Commission_A
        {
            get { return commission_A; }
            set
            {
                if (commission_A == value) { return; }
                commission_A = value;
                OnPropertyChanged("Commission_A");
            }
        }

        /// <summary>
        /// 二级佣金
        /// </summary>
        public double Commission_B
        {
            get { return dividend_B; }
            set
            {
                if (dividend_B == value) { return; }
                dividend_B = value;
                OnPropertyChanged("Commission_B");
            }
        }

        /// <summary>
        /// 获得佣金的消费额下限
        /// </summary>
        public double LowerConsumptionForCommission
        {
            get { return lowerConsumptionForCommission; }
            set
            {
                if (lowerConsumptionForCommission == value) { return; }
                lowerConsumptionForCommission = value;
                OnPropertyChanged("LowerConsumptionForCommission");
            }
        }

        /// <summary>
        /// 顶级用户分红（百分比）
        /// </summary>
        public double Dividend_A
        {
            get { return dividend_A; }
            set
            {
                if (dividend_A == value) { return; }
                dividend_A = value;
                OnPropertyChanged("Dividend_A");
            }
        }

        /// <summary>
        /// 次级用户分红（百分比）
        /// </summary>
        public double Dividend_B
        {
            get { return dividend_B; }
            set
            {
                if (dividend_B == value) { return; }
                dividend_B = value;
                OnPropertyChanged("Dividend_B");
            }
        }

        /// <summary>
        /// 获得分红的消费额下限
        /// </summary>
        public double LowerConsumptionForDividend
        {
            get { return lowerConsumptionForDividend; }
            set
            {
                if (lowerConsumptionForDividend == value) { return; }
                lowerConsumptionForDividend = value;
                OnPropertyChanged("LowerConsumptionForDividend");
            }
        }

        #region 清理用户的条件

        /// <summary>
        /// 自动清理用户的条件：未激活时间（天）
        /// </summary>
        public int ClearUser_DaysOfInactive
        {
            get { return clearUser_DaysOfInactive; }
            set
            {
                if (clearUser_DaysOfInactive == value) { return; }
                clearUser_DaysOfInactive = value;
                OnPropertyChanged("ClearUser_DaysOfInactive");
            }
        }

        /// <summary>
        /// 自动清理用户的条件：未登陆时间（天）
        /// </summary>
        public int ClearUser_DaysOfUnSetIn
        {
            get { return clearUser_DaysOfUnSetIn; }
            set
            {
                if (clearUser_DaysOfUnSetIn == value) { return; }
                clearUser_DaysOfUnSetIn = value;
                OnPropertyChanged("ClearUser_DaysOfUnSetIn");
            }
        }

        /// <summary>
        /// 自动清理用户的条件：余额（小于）
        /// </summary>
        public double ClearUser_LowerOfMoney
        {
            get { return clearUser_LowerOfMoney; }
            set
            {
                if (clearUser_LowerOfMoney == value) { return; }
                clearUser_LowerOfMoney = value;
                OnPropertyChanged("ClearUser_LowerOfMoney");
            }
        }

        /// <summary>
        /// 自动清理用户的条件：未发送帐变的时间（天）
        /// </summary>
        public int ClearUser_DaysOfUnMoneyChange
        {
            get { return clearUser_DaysOfUnMoneyChange; }
            set
            {
                if (clearUser_DaysOfUnMoneyChange == value) { return; }
                clearUser_DaysOfUnMoneyChange = value;
                OnPropertyChanged("ClearUser_DaysOfUnMoneyChange");
            }
        }

        #endregion

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

        public AuthorSettingViewModel()
            : base("系统设置", "用户模块设置")
        {
            this.RefreshCommand = new UniversalCommand(Refresh);
            this.EditCommand = new UniversalCommand(Edit);

            client.GetSettingOfAuthorCompleted += ShowSetting;
            client.SetSettingOfAuthorCompleted += ShowEditResult;
            Refresh();
        }

        #region 显示设置明细

        void ShowSetting(object sender, GetSettingOfAuthorCompletedEventArgs e)
        {
            this.LowerRebate = e.Result.Info.LowerRebate;
            this.CapsRebate = e.Result.Info.CapsRebate;
            this.LowerRebateOfHigh = e.Result.Info.LowerRebateOfHigh;
            this.CapsRebateOfHigh = e.Result.Info.CapsRebateOfHigh;

            this.RechargeRecordTimeout = e.Result.Info.RechargeRecordTimeout;
            this.SpreadRecordTimeout = e.Result.Info.SpreadRecordTimeout;
            this.ForgotPasswordRecordTimeout = e.Result.Info.ForgotPasswordRecordTimeout;

            this.DaysOfDividend = e.Result.Info.DaysOfDividend;

            this.TimesOfWithdrawal = e.Result.Info.TimesOfWithdrawal;
            this.MinimumWithdrawalAmount = e.Result.Info.MinimumWithdrawalAmount;
            this.MaximumWithdrawalAmount = e.Result.Info.MaximumWithdrawalAmount;

            this.Commission_A = e.Result.Info.Commission_A;
            this.Commission_B = e.Result.Info.Commission_B;
            this.LowerConsumptionForCommission = e.Result.Info.LowerConsumptionForCommission;
            this.Dividend_A = e.Result.Info.Dividend_A;
            this.Dividend_B = e.Result.Info.Dividend_B;
            this.LowerConsumptionForDividend = e.Result.Info.LowerConsumptionForDividend;

            this.ClearUser_DaysOfInactive = e.Result.Info.ClearUser_DaysOfInactive;
            this.ClearUser_DaysOfUnSetIn = e.Result.Info.ClearUser_DaysOfUnSetIn;
            this.ClearUser_LowerOfMoney = e.Result.Info.ClearUser_LowerOfMoney;
            this.ClearUser_DaysOfUnMoneyChange = e.Result.Info.ClearUser_DaysOfUnMoneyChange;
        }

        #endregion

        #endregion

        #region 私有方法

        void Refresh(object obj = null)
        {
            GetSettingOfAuthorImport import = new GetSettingOfAuthorImport
            {
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetSettingOfAuthorAsync(import);
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

            SetSettingOfAuthorImport import = new SetSettingOfAuthorImport
            {
                LowerRebate = this.LowerRebate,
                CapsRebate = this.CapsRebate,
                LowerRebateOfHigh = this.LowerRebateOfHigh,
                CapsRebateOfHigh = this.CapsRebateOfHigh,

                RechargeRecordTimeout = this.RechargeRecordTimeout,
                SpreadRecordTimeout = this.SpreadRecordTimeout,
                ForgotPasswordRecordTimeout = this.ForgotPasswordRecordTimeout,

                DaysOfDividend = this.DaysOfDividend,

                TimesOfWithdrawal = this.TimesOfWithdrawal,
                MinimumWithdrawalAmount = this.MinimumWithdrawalAmount,
                MaximumWithdrawalAmount = this.MaximumWithdrawalAmount,

                Commission_A = this.Commission_A,
                Commission_B = this.Commission_B,
                LowerConsumptionForCommission = this.LowerConsumptionForCommission,
                Dividend_A = this.Dividend_A,
                Dividend_B = this.Dividend_B,
                LowerConsumptionForDividend = this.LowerConsumptionForDividend,

                ClearUser_DaysOfInactive = this.ClearUser_DaysOfInactive,
                ClearUser_DaysOfUnSetIn = this.ClearUser_DaysOfUnSetIn,
                ClearUser_LowerOfMoney = this.ClearUser_LowerOfMoney,
                ClearUser_DaysOfUnMoneyChange = this.ClearUser_DaysOfUnMoneyChange,

                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.SetSettingOfAuthorAsync(import);
        }
        void ShowEditResult(object sender, SetSettingOfAuthorCompletedEventArgs e)
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
