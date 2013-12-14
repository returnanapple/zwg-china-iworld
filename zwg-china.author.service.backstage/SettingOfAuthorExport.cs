using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用户相关的系统设置
    /// </summary>
    [DataContract]
    public class SettingOfAuthorExport
    {
        #region 属性

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

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户相关的系统设置
        /// </summary>
        public SettingOfAuthorExport()
        {

        }

        /// <summary>
        /// 实例化一个新的用户相关的系统设置
        /// </summary>
        /// <param name="model">用户相关的系统设置的数据模型</param>
        public SettingOfAuthorExport(SettingOfAuthor model)
        {
            this.LowerRebate = model.LowerRebate;
            this.CapsRebate = model.CapsRebate;
            this.LowerRebateOfHigh = model.LowerRebateOfHigh;
            this.CapsRebateOfHigh = model.CapsRebateOfHigh;
            this.RechargeRecordTimeout = model.RechargeRecordTimeout;
            this.SpreadRecordTimeout = model.SpreadRecordTimeout;
            this.ForgotPasswordRecordTimeout = model.ForgotPasswordRecordTimeout;
            this.DaysOfDividend = model.DaysOfDividend;
            this.TimesOfWithdrawal = model.TimesOfWithdrawal;
            this.MinimumWithdrawalAmount = model.MinimumWithdrawalAmount;
            this.MaximumWithdrawalAmount = model.MaximumWithdrawalAmount;
            this.Commission_A = model.Commission_A;
            this.Commission_B = model.Commission_B;
            this.LowerConsumptionForCommission = model.LowerConsumptionForCommission;
            this.Dividend_A = model.Dividend_A;
            this.Dividend_B = model.Dividend_B;
            this.LowerConsumptionForDividend = model.LowerConsumptionForDividend;
            this.ClearUser_DaysOfInactive = model.ClearUser_DaysOfInactive;
            this.ClearUser_DaysOfUnSetIn = model.ClearUser_DaysOfUnSetIn;
            this.ClearUser_LowerOfMoney = model.ClearUser_LowerOfMoney;
            this.ClearUser_DaysOfUnMoneyChange = model.ClearUser_DaysOfUnMoneyChange;
        }

        #endregion
    }
}
