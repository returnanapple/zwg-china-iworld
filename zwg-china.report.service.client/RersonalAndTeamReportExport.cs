using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.client
{
    /// <summary>
    /// 私人/团队报表
    /// </summary>
    [DataContract]
    public class RersonalAndTeamReportExport
    {
        #region 属性

        /// <summary>
        /// 用户的存储指针
        /// </summary>
        [DataMember]
        public int OwnerId { get; set; }

        /// <summary>
        /// 用户的用户名
        /// </summary>
        [DataMember]
        public string Owner { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [DataMember]
        public string Date { get; set; }

        /// <summary>
        /// 登陆次数
        /// </summary>
        [DataMember]
        public int TimesOfLogin { get; set; }

        /// <summary>
        /// 投注额
        /// </summary>
        [DataMember]
        public double AmountOfBets { get; set; }

        /// <summary>
        /// 返点
        /// </summary>
        [DataMember]
        public double Rebate { get; set; }

        /// <summary>
        /// 奖金
        /// </summary>
        [DataMember]
        public double Bonus { get; set; }

        /// <summary>
        /// 佣金
        /// </summary>
        [DataMember]
        public double Commission { get; set; }

        /// <summary>
        /// 活动奖励
        /// </summary>
        [DataMember]
        public double Reward { get; set; }

        /// <summary>
        /// 分红
        /// </summary>
        [DataMember]
        public double Dividend { get; set; }

        /// <summary>
        /// 盈亏
        /// </summary>
        [DataMember]
        public double Profit { get; set; }

        /// <summary>
        /// 充值
        /// </summary>
        [DataMember]
        public double Recharge { get; set; }

        /// <summary>
        /// 提现
        /// </summary>
        [DataMember]
        public double Withdrawal { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个私人/团队报表
        /// </summary>
        /// <param name="model">私人/团队报表的数据模型</param>
        public RersonalAndTeamReportExport(RersonalReportForOneDay model)
        {
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.Date = model.Date;
            this.TimesOfLogin = model.TimesOfLogin;
            this.AmountOfBets = model.AmountOfBets;
            this.Rebate = model.Rebate;
            this.Bonus = model.Bonus;
            this.Commission = model.Commission;
            this.Reward = model.Reward;
            this.Dividend = model.Dividend;
            this.Recharge = model.Recharge;
            this.Withdrawal = model.Withdrawal;
            this.Profit = model.Profit;
        }

        /// <summary>
        /// 实例化一个私人/团队报表
        /// </summary>
        /// <param name="model">私人/团队报表的数据模型</param>
        public RersonalAndTeamReportExport(RersonalReportForOneMonth model)
        {
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.Date = model.Date;
            this.TimesOfLogin = model.TimesOfLogin;
            this.AmountOfBets = model.AmountOfBets;
            this.Rebate = model.Rebate;
            this.Bonus = model.Bonus;
            this.Commission = model.Commission;
            this.Reward = model.Reward;
            this.Dividend = model.Dividend;
            this.Recharge = model.Recharge;
            this.Withdrawal = model.Withdrawal;
            this.Profit = model.Profit;
        }

        /// <summary>
        /// 实例化一个私人/团队报表
        /// </summary>
        /// <param name="model">私人/团队报表的数据模型</param>
        public RersonalAndTeamReportExport(TeamReportForOneDay model)
        {
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.Date = model.Date;
            this.TimesOfLogin = model.TimesOfLogin;
            this.AmountOfBets = model.AmountOfBets;
            this.Rebate = model.Rebate;
            this.Bonus = model.Bonus;
            this.Commission = model.Commission;
            this.Reward = model.Reward;
            this.Dividend = model.Dividend;
            this.Recharge = model.Recharge;
            this.Withdrawal = model.Withdrawal;
            this.Profit = model.Profit;
        }

        /// <summary>
        /// 实例化一个私人/团队报表
        /// </summary>
        /// <param name="model">私人/团队报表的数据模型</param>
        public RersonalAndTeamReportExport(TeamReportForOneMonth model)
        {
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.Date = model.Date;
            this.TimesOfLogin = model.TimesOfLogin;
            this.AmountOfBets = model.AmountOfBets;
            this.Rebate = model.Rebate;
            this.Bonus = model.Bonus;
            this.Commission = model.Commission;
            this.Reward = model.Reward;
            this.Dividend = model.Dividend;
            this.Recharge = model.Recharge;
            this.Withdrawal = model.Withdrawal;
            this.Profit = model.Profit;
        }

        #endregion
    }
}
