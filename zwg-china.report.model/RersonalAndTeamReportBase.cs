using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 个人/团队统计的基类
    /// </summary>
    public abstract class RersonalAndTeamReportBase : ReportBase
    {
        #region 私有字段

        double money = 0;

        #endregion

        #region 属性

        /// <summary>
        /// 用户
        /// </summary>
        public virtual Author Owner { get; set; }

        /// <summary>
        /// 资金余额
        /// </summary>
        public double Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("资金余额不能小于0");
                }
                money = value;
            }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的个人/团队统计
        /// </summary>
        public RersonalAndTeamReportBase()
        {

        }

        /// <summary>
        /// 实例化一个新的个人/团队统计
        /// </summary>
        /// <param name="owner">用户</param>
        /// <param name="date">日期</param>
        /// <param name="money">资金余额</param>
        /// <param name="timesOfLogin">登陆次数</param>
        /// <param name="amountOfBets">投注额</param>
        /// <param name="rebate">返点</param>
        /// <param name="bonus">奖金</param>
        /// <param name="commission">佣金</param>
        /// <param name="reward">活动奖励</param>
        /// <param name="dividend">分红</param>
        /// <param name="recharge">充值</param>
        /// <param name="withdrawal">提现</param>
        public RersonalAndTeamReportBase(Author owner, string date, double money, int timesOfLogin, double amountOfBets
            , double rebate, double bonus, double commission, double reward, double dividend, double recharge, double withdrawal)
            : base(date, timesOfLogin, amountOfBets, rebate, bonus, commission, reward, dividend, recharge, withdrawal)
        {
            this.Owner = owner;
            this.Money = money;
        }

        #endregion
    }
}
