using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 报表的基类
    /// </summary>
    public abstract class ReportBase : StatisticalDataModelBase
    {
        #region 属性

        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的报表
        /// </summary>
        public ReportBase()
        {
            DateTime t = DateTime.Now.AddDays(-1);
            this.Time = new DateTime(t.Year, t.Month, t.Day);
        }

        /// <summary>
        /// 实例化一个新的报表
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="timesOfLogin">登陆次数</param>
        /// <param name="amountOfBets">投注额</param>
        /// <param name="rebate">返点</param>
        /// <param name="bonus">奖金</param>
        /// <param name="commission">佣金</param>
        /// <param name="reward">活动奖励</param>
        /// <param name="dividend">分红</param>
        /// <param name="recharge">充值</param>
        /// <param name="withdrawal">提现</param>
        public ReportBase(string date, int timesOfLogin, double amountOfBets, double rebate, double bonus, double commission
            , double reward, double dividend, double recharge, double withdrawal)
            : base(timesOfLogin, amountOfBets, rebate, bonus, commission, reward, dividend, recharge, withdrawal)
        {
            this.Date = date;
            DateTime t = DateTime.Now.AddDays(-1);
            this.Time = new DateTime(t.Year, t.Month, t.Day);
        }

        #endregion
    }
}
