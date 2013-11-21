using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 单月个人统计
    /// </summary>
    public class RersonalReportForOneMonth : RersonalAndTeamReportBase
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的单月个人统计
        /// </summary>
        public RersonalReportForOneMonth()
        {

        }

        /// <summary>
        /// 实例化一个新的单月个人统计
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
        public RersonalReportForOneMonth(Author owner, string date, double money, int timesOfLogin, double amountOfBets
            , double rebate, double bonus, double commission, double reward, double dividend, double recharge, double withdrawal)
            : base(owner, date, money, timesOfLogin, amountOfBets, rebate, bonus, commission, reward, dividend, recharge, withdrawal)
        {

        }

        #endregion
    }
}
