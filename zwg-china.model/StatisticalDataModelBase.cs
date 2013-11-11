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
        #region 属性

        /// <summary>
        /// 登陆次数
        /// </summary>
        public int TimesOfLogin { get; set; }

        /// <summary>
        /// 投注额
        /// </summary>
        public double AmountOfBets { get; set; }

        /// <summary>
        /// 返点
        /// </summary>
        public double Rebate { get; set; }

        /// <summary>
        /// 奖金
        /// </summary>
        public double Bonus { get; set; }

        /// <summary>
        /// 佣金
        /// </summary>
        public double Commission { get; set; }

        /// <summary>
        /// 分红
        /// </summary>
        public double Dividend { get; set; }

        /// <summary>
        /// 盈亏
        /// </summary>
        public double Profit { get; set; }

        /// <summary>
        /// 充值
        /// </summary>
        public double Recharge { get; set; }

        /// <summary>
        /// 提现
        /// </summary>
        public double Withdrawal { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的统计数据相关的数据模型
        /// </summary>
        public StatisticalDataModelBase()
        {
            this.TimesOfLogin = 0;
            this.AmountOfBets = 0;
            this.Rebate = 0;
            this.Bonus = 0;
            this.Commission = 0;
            this.Dividend = 0;
            this.Profit = 0;
            this.Recharge = 0;
            this.Withdrawal = 0;
        }

        #endregion
    }
}
