using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 用户相关的系统设置
    /// </summary>
    public class SettingOfAuthor : SettingBase
    {
        #region 属性

        /// <summary>
        /// 允许设置的最低返点
        /// </summary>
        public double LowerRebate
        {
            get { return GetDoubleValue("LowerRebate", 4.5); }
            set { SetValue("LowerRebate", value); }
        }

        /// <summary>
        /// 允许设置的最高返点
        /// </summary>
        public double CapsRebate
        {
            get { return GetDoubleValue("CapsRebate", 13.0); }
            set { SetValue("CapsRebate", value); }
        }

        /// <summary>
        /// “高点号”定义的下限
        /// </summary>
        public double LowerRebateOfHigh
        {
            get { return GetDoubleValue("LowerRebateOfHigh", 12.1); }
            set { SetValue("LowerRebateOfHigh", value); }
        }

        /// <summary>
        /// “高点号”定义的上限
        /// </summary>
        public double CapsRebateOfHigh
        {
            get { return GetDoubleValue("CapsRebateOfHigh", 13.0); }
            set { SetValue("CapsRebateOfHigh", value); }
        }

        /// <summary>
        /// 充值记录超时时间（小时）
        /// </summary>
        public int RechargeRecordTimeout
        {
            get { return GetIntValue("RechargeRecordTimeout", 24); }
            set { SetValue("RechargeRecordTimeout", value); }
        }

        /// <summary>
        /// 推广记录超时时间（小时）
        /// </summary>
        public int SpreadRecordTimeout
        {
            get { return GetIntValue("SpreadRecordTimeout", 24); }
            set { SetValue("SpreadRecordTimeout", value); }
        }

        /// <summary>
        /// 找回密码记录超时时间（小时）
        /// </summary>
        public int ForgotPasswordRecordTimeout
        {
            get { return GetIntValue("ForgotPasswordRecordTimeout", 24); }
            set { SetValue("ForgotPasswordRecordTimeout", value); }
        }

        /// <summary>
        /// 分红日
        /// </summary>
        public string DaysOfDividend
        {
            get { return GetStringValue("DaysOfDividend", "1,16"); }
            set { SetValue("DaysOfDividend", value); }
        }

        /// <summary>
        /// 每日允许提现次数
        /// </summary>
        public int TimesOfWithdrawal
        {
            get { return GetIntValue("TimesOfWithdrawal", 10); }
            set { SetValue("TimesOfWithdrawal", value); }
        }

        /// <summary>
        /// 单笔最低取款金额
        /// </summary>
        public double MinimumWithdrawalAmount
        {
            get { return GetDoubleValue("MinimumWithdrawalAmount", 10.0); }
            set { SetValue("MinimumWithdrawalAmount", value); }
        }

        /// <summary>
        /// 单笔最高取款金额
        /// </summary>
        public double MaximumWithdrawalAmount
        {
            get { return GetDoubleValue("MaximumWithdrawalAmount", 100000.0); }
            set { SetValue("MaximumWithdrawalAmount", value); }
        }

        /// <summary>
        /// 一级佣金
        /// </summary>
        public double Commission_A
        {
            get { return GetDoubleValue("Commission_A", 8); }
            set { SetValue("Commission_A", value); }
        }

        /// <summary>
        /// 二级佣金
        /// </summary>
        public double Commission_B
        {
            get { return GetDoubleValue("Commission_B", 12.0); }
            set { SetValue("Commission_B", value); }
        }

        /// <summary>
        /// 获得佣金的消费额下限
        /// </summary>
        public double LowerConsumptionForCommission
        {
            get { return GetDoubleValue("LowerConsumptionForCommission", 500); }
            set { SetValue("LowerConsumptionForCommission", value); }
        }

        /// <summary>
        /// 顶级用户分红（百分比）
        /// </summary>
        public double Dividend_A
        {
            get { return GetDoubleValue("Dividend_A", 10.0); }
            set { SetValue("Dividend_A", value); }
        }

        /// <summary>
        /// 次级用户分红（百分比）
        /// </summary>
        public double Dividend_B
        {
            get { return GetDoubleValue("Dividend_B", 7.0); }
            set { SetValue("Dividend_B", value); }
        }

        /// <summary>
        /// 获得分红的消费额下限
        /// </summary>
        public double LowerConsumptionForDividend
        {
            get { return GetDoubleValue("LowerConsumptionForDividend", 10000); }
            set { SetValue("LowerConsumptionForDividend", value); }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 获取一个用户相关的系统设置的副本
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public SettingOfAuthor(IModelToDbContextOfBase db)
            : base(db)
        {

        }

        #endregion
    }
}
