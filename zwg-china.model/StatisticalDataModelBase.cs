using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 统计数据相关的数据模型的基类
    /// </summary>
    public abstract class StatisticalDataModelBase : ModelBase
    {
        #region 私有字段

        int timesOfLogin = 0;
        double amountOfBets = 0;
        double rebate = 0;
        double bonus = 0;
        double commission = 0;
        double reward = 0;
        double dividend = 0;
        double recharge = 0;
        double withdrawal = 0;

        #endregion

        #region 属性

        /// <summary>
        /// 登陆次数
        /// </summary>
        public int TimesOfLogin
        {
            get { return timesOfLogin; }
            set
            {
                if (value < 0) { throw new Exception("登陆次数不能小于0"); }
                timesOfLogin = value;
            }
        }

        /// <summary>
        /// 投注额
        /// </summary>
        public double AmountOfBets
        {
            get { return amountOfBets; }
            set
            {
                if (value < 0) { throw new Exception("投注额不能小于0"); }
                amountOfBets = value;
            }
        }

        /// <summary>
        /// 返点
        /// </summary>
        public double Rebate
        {
            get { return rebate; }
            set
            {
                if (value < 0) { throw new Exception("返点不能小于0"); }
                rebate = value;
            }
        }

        /// <summary>
        /// 奖金
        /// </summary>
        public double Bonus
        {
            get { return bonus; }
            set
            {
                if (value < 0) { throw new Exception("奖金不能小于0"); }
                bonus = value;
            }
        }

        /// <summary>
        /// 佣金
        /// </summary>
        public double Commission
        {
            get { return commission; }
            set
            {
                if (value < 0) { throw new Exception("佣金不能小于0"); }
                commission = value;
            }
        }

        /// <summary>
        /// 活动奖励
        /// </summary>
        public double Reward
        {
            get { return reward; }
            set
            {
                if (value < 0) { throw new Exception("活动奖励不能小于0"); }
                reward = value;
            }
        }

        /// <summary>
        /// 分红
        /// </summary>
        public double Dividend
        {
            get { return dividend; }
            set
            {
                if (value < 0) { throw new Exception("分红不能小于0"); }
                dividend = value;
            }
        }

        /// <summary>
        /// 盈亏
        /// </summary>
        public double Profit { get; set; }

        /// <summary>
        /// 充值
        /// </summary>
        public double Recharge
        {
            get { return recharge; }
            set
            {
                if (value < 0) { throw new Exception("充值不能小于0"); }
                recharge = value;
            }
        }

        /// <summary>
        /// 提现
        /// </summary>
        public double Withdrawal
        {
            get { return withdrawal; }
            set
            {
                if (value < 0) { throw new Exception("提现不能小于0"); }
                withdrawal = value;
            }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的统计数据相关的数据模型
        /// </summary>
        public StatisticalDataModelBase()
        {
            this.Profit = 0;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 刷新盈亏
        /// </summary>
        public virtual void RefreshProfit()
        {
            this.Profit = this.Bonus + this.Rebate + this.Commission + this.Rebate - this.AmountOfBets;
        }

        #endregion
    }
}
