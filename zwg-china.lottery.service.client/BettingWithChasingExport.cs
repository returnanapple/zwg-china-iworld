using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.client
{
    /// <summary>
    /// 投注信息（追号）
    /// </summary>
    [DataContract]
    public class BettingWithChasingExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 期号
        /// </summary>
        [DataMember]
        public string Issue { get; set; }

        /// <summary>
        /// 倍数
        /// </summary>
        [DataMember]
        public double Multiple { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        [DataMember]
        public BettingStatus Status { get; set; }

        /// <summary>
        /// 投注金额
        /// </summary>
        [DataMember]
        public double Pay { get; set; }

        /// <summary>
        /// 中奖金额（未中奖时候为0）
        /// </summary>
        [DataMember]
        public double Bonus { get; set; }

        /// <summary>
        /// 开奖号码（如果还未开奖则为空）
        /// </summary>
        [DataMember]
        public string LotteryValue { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的投注信息（追号）
        /// </summary>
        public BettingWithChasingExport()
        {

        }

        /// <summary>
        /// 实例化一个新的投注信息（追号）
        /// </summary>
        /// <param name="model">投注信息（追号）的数据模型</param>
        public BettingWithChasingExport(BettingWithChasing model)
        {
            this.Id = model.Id;
            this.Issue = model.Issue;
            this.Multiple = model.Multiple;
            this.Status = model.Status;
            this.Pay = model.Pay;
            this.Bonus = model.Bonus;
            this.LotteryValue = model.LotteryValues;
        }

        #endregion
    }
}
