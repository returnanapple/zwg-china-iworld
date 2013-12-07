using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用于修改用户模块的相关设置的数据集
    /// </summary>
    [DataContract]
    public class SetSettingOfAuthorImport : SetSettingImportBase
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

        #region 方法

        /// <summary>
        /// 设置并保存
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void SetAndSave(IModelToDbContextOfAuthor db)
        {
            SettingOfAuthor settingOfAuthor = new SettingOfAuthor(db);
            settingOfAuthor.LowerRebate = this.LowerRebate;
            settingOfAuthor.CapsRebate = this.CapsRebate;
            settingOfAuthor.LowerRebateOfHigh = this.LowerRebateOfHigh;
            settingOfAuthor.CapsRebateOfHigh = this.CapsRebateOfHigh;
            settingOfAuthor.RechargeRecordTimeout = this.RechargeRecordTimeout;
            settingOfAuthor.SpreadRecordTimeout = this.SpreadRecordTimeout;
            settingOfAuthor.ForgotPasswordRecordTimeout = this.ForgotPasswordRecordTimeout;
            settingOfAuthor.DaysOfDividend = this.DaysOfDividend;
            settingOfAuthor.TimesOfWithdrawal = this.TimesOfWithdrawal;
            settingOfAuthor.MinimumWithdrawalAmount = this.MinimumWithdrawalAmount;
            settingOfAuthor.MaximumWithdrawalAmount = this.MaximumWithdrawalAmount;
            settingOfAuthor.Commission_A = this.Commission_A;
            settingOfAuthor.Commission_B = this.Commission_B;
            settingOfAuthor.LowerConsumptionForCommission = this.LowerConsumptionForCommission;
            settingOfAuthor.Dividend_A = this.Dividend_A;
            settingOfAuthor.Dividend_B = this.Dividend_B;
            settingOfAuthor.LowerConsumptionForDividend = this.LowerConsumptionForDividend;

            settingOfAuthor.ClearUser_DaysOfInactive = this.ClearUser_DaysOfInactive;
            settingOfAuthor.ClearUser_DaysOfUnSetIn = this.ClearUser_DaysOfUnSetIn;
            settingOfAuthor.ClearUser_LowerOfMoney = this.ClearUser_LowerOfMoney;
            settingOfAuthor.ClearUser_DaysOfUnMoneyChange = this.ClearUser_DaysOfUnMoneyChange;

            settingOfAuthor.Save(db);
        }

        #endregion
    }
}
