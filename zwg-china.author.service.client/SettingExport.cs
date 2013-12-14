using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model.manager;

namespace zwg_china.service.client
{
    /// <summary>
    /// 设置
    /// </summary>
    [DataContract]
    public class SettingExport
    {
        #region 属性

        #region 基本

        /// <summary>
        /// 前台页面大小（条）
        /// </summary>
        [DataMember]
        public int PageSizeForClient { get; set; }

        /// <summary>
        /// 后台页面大小（条）
        /// </summary>
        [DataMember]
        public int PageSizeForAdmin { get; set; }

        /// <summary>
        /// 心跳间隔（秒）
        /// </summary>
        [DataMember]
        public int HeartbeatInterval { get; set; }

        /// <summary>
        /// 允许取款时间 - 开始
        /// </summary>
        [DataMember]
        public string WorkingHour_Begin { get; set; }

        /// <summary>
        /// 允许取款时间 - 结束
        /// </summary>
        [DataMember]
        public string WorkingHour_End { get; set; }

        /// <summary>
        /// 取款虚拟排队
        /// </summary>
        [DataMember]
        public int VirtualQueuing { get; set; }

        /// <summary>
        /// 运行采集程序
        /// </summary>
        [DataMember]
        public bool CollectionRunning { get; set; }

        #endregion

        #region 用户相关

        /// <summary>
        /// 允许设置的最低返点
        /// </summary>
        [DataMember]
        public double LowerRebate { get; set; }

        /// <summary>
        /// 允许设置的最高返点
        /// </summary>
        [DataMember]
        public double CapsRebate { get; set; }

        /// <summary>
        /// “高点号”定义的下限
        /// </summary>
        [DataMember]
        public double LowerRebateOfHigh { get; set; }

        /// <summary>
        /// “高点号”定义的上限
        /// </summary>
        [DataMember]
        public double CapsRebateOfHigh { get; set; }

        /// <summary>
        /// 充值记录超时时间（小时）
        /// </summary>
        [DataMember]
        public int RechargeRecordTimeout { get; set; }

        /// <summary>
        /// 推广记录超时时间（小时）
        /// </summary>
        [DataMember]
        public int SpreadRecordTimeout { get; set; }

        /// <summary>
        /// 找回密码记录超时时间（小时）
        /// </summary>
        [DataMember]
        public int ForgotPasswordRecordTimeout { get; set; }

        /// <summary>
        /// 分红日
        /// </summary>
        [DataMember]
        public string DaysOfDividend { get; set; }

        /// <summary>
        /// 每日允许提现次数
        /// </summary>
        [DataMember]
        public int TimesOfWithdrawal { get; set; }

        /// <summary>
        /// 单笔最低取款金额
        /// </summary>
        [DataMember]
        public double MinimumWithdrawalAmount { get; set; }

        /// <summary>
        /// 单笔最高取款金额
        /// </summary>
        [DataMember]
        public double MaximumWithdrawalAmount { get; set; }

        /// <summary>
        /// 一级佣金
        /// </summary>
        [DataMember]
        public double Commission_A { get; set; }

        /// <summary>
        /// 二级佣金
        /// </summary>
        [DataMember]
        public double Commission_B { get; set; }

        /// <summary>
        /// 获得佣金的消费额下限
        /// </summary>
        [DataMember]
        public double LowerConsumptionForCommission { get; set; }

        /// <summary>
        /// 顶级用户分红（百分比）
        /// </summary>
        [DataMember]
        public double Dividend_A { get; set; }

        /// <summary>
        /// 次级用户分红（百分比）
        /// </summary>
        [DataMember]
        public double Dividend_B { get; set; }

        /// <summary>
        /// 获得分红的消费额下限
        /// </summary>
        [DataMember]
        public double LowerConsumptionForDividend { get; set; }

        #region 清理用户的条件

        /// <summary>
        /// 自动清理用户的条件：未激活时间（天）
        /// </summary>
        [DataMember]
        public int ClearUser_DaysOfInactive { get; set; }

        /// <summary>
        /// 自动清理用户的条件：未登陆时间（天）
        /// </summary>
        [DataMember]
        public int ClearUser_DaysOfUnSetIn { get; set; }

        /// <summary>
        /// 自动清理用户的条件：余额（小于）
        /// </summary>
        [DataMember]
        public double ClearUser_LowerOfMoney { get; set; }

        /// <summary>
        /// 自动清理用户的条件：未发送帐变的时间（天）
        /// </summary>
        [DataMember]
        public int ClearUser_DaysOfUnMoneyChange { get; set; }

        #endregion

        #endregion

        #region 彩票相关

        /// <summary>
        /// 单注价格
        /// </summary>
        [DataMember]
        public double UnitPrice { get; set; }

        /// <summary>
        /// 返奖基数
        /// （2 : n）
        /// </summary>
        [DataMember]
        public int PayoutBase { get; set; }

        /// <summary>
        /// 禁止投注的基数线
        /// </summary>
        [DataMember]
        public int LineForProhibitBetting { get; set; }

        /// <summary>
        /// 返奖金额上限
        /// </summary>
        [DataMember]
        public int MaximumPayout { get; set; }

        /// <summary>
        /// 奖金 - 返点换算率
        /// </summary>
        [DataMember]
        public double ConversionRates { get; set; }

        /// <summary>
        /// 最大投注倍数
        /// </summary>
        [DataMember]
        public int MaximumBetsNumber { get; set; }

        /// <summary>
        /// 封单时间（秒）
        /// </summary>
        [DataMember]
        public int ClosureSingleTime { get; set; }

        #endregion

        #endregion

        #region 构造方法

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="settingOfBase">基本设置</param>
        /// <param name="settingOfAuthor">用户设置</param>
        /// <param name="settingOfLottery">彩票设置</param>
        public SettingExport(SettingOfBase settingOfBase, SettingOfAuthor settingOfAuthor, SettingOfLottery settingOfLottery)
        {
            this.PageSizeForClient = settingOfBase.PageSizeForClient;
            this.PageSizeForAdmin = settingOfBase.PageSizeForAdmin;
            this.HeartbeatInterval = settingOfBase.HeartbeatInterval;
            this.WorkingHour_Begin = settingOfBase.WorkingHour_Begin;
            this.WorkingHour_End = settingOfBase.WorkingHour_End;
            this.VirtualQueuing = settingOfBase.VirtualQueuing;
            this.CollectionRunning = settingOfBase.CollectionRunning;

            this.LowerRebate = settingOfAuthor.LowerRebate;
            this.CapsRebate = settingOfAuthor.CapsRebate;
            this.LowerRebateOfHigh = settingOfAuthor.LowerRebateOfHigh;
            this.CapsRebateOfHigh = settingOfAuthor.CapsRebateOfHigh;
            this.RechargeRecordTimeout = settingOfAuthor.RechargeRecordTimeout;
            this.SpreadRecordTimeout = settingOfAuthor.SpreadRecordTimeout;
            this.ForgotPasswordRecordTimeout = settingOfAuthor.ForgotPasswordRecordTimeout;
            this.DaysOfDividend = settingOfAuthor.DaysOfDividend;
            this.TimesOfWithdrawal = settingOfAuthor.TimesOfWithdrawal;
            this.MinimumWithdrawalAmount = settingOfAuthor.MinimumWithdrawalAmount;
            this.MaximumWithdrawalAmount = settingOfAuthor.MaximumWithdrawalAmount;
            this.Commission_A = settingOfAuthor.Commission_A;
            this.Commission_B = settingOfAuthor.Commission_B;
            this.LowerConsumptionForCommission = settingOfAuthor.LowerConsumptionForCommission;
            this.Dividend_A = settingOfAuthor.Dividend_A;
            this.Dividend_B = settingOfAuthor.Dividend_B;
            this.LowerConsumptionForDividend = settingOfAuthor.LowerConsumptionForDividend;
            this.ClearUser_DaysOfInactive = settingOfAuthor.ClearUser_DaysOfInactive;
            this.ClearUser_DaysOfUnSetIn = settingOfAuthor.ClearUser_DaysOfUnSetIn;
            this.ClearUser_LowerOfMoney = settingOfAuthor.ClearUser_LowerOfMoney;
            this.ClearUser_DaysOfUnMoneyChange = settingOfAuthor.ClearUser_DaysOfUnMoneyChange;

            this.UnitPrice = settingOfLottery.UnitPrice;
            this.PayoutBase = settingOfLottery.PayoutBase;
            this.LineForProhibitBetting = settingOfLottery.LineForProhibitBetting;
            this.MaximumPayout = settingOfLottery.MaximumPayout;
            this.ConversionRates = settingOfLottery.ConversionRates;
            this.MaximumBetsNumber = settingOfLottery.MaximumBetsNumber;
            this.ClosureSingleTime = settingOfLottery.ClosureSingleTime;
        }

        #endregion
    }
}
