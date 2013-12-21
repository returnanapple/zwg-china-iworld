using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.client
{
    /// <summary>
    /// 投注信息
    /// </summary>
    [DataContract]
    public class BettingExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 投注人的存储指针
        /// </summary>
        [DataMember]
        public int OwnerId { get; set; }

        /// <summary>
        /// 投注人的用户名
        /// </summary>
        [DataMember]
        public string Owner { get; set; }

        /// <summary>
        /// 期号
        /// </summary>
        [DataMember]
        public string Issue { get; set; }

        /// <summary>
        /// 注数
        /// </summary>
        [DataMember]
        public int Notes { get; set; }

        /// <summary>
        /// 倍数
        /// </summary>
        [DataMember]
        public double Multiple { get; set; }

        /// <summary>
        /// 用于转换为赔率的点数
        /// </summary>
        [DataMember]
        public double Points { get; set; }

        /// <summary>
        /// 彩票
        /// </summary>
        [DataMember]
        public string Ticket { get; set; }

        /// <summary>
        /// 玩法标签
        /// </summary>
        [DataMember]
        public string PlayTag { get; set; }

        /// <summary>
        /// 玩法的名称
        /// </summary>
        [DataMember]
        public string HowToPlay { get; set; }

        /// <summary>
        /// 投注信息
        /// </summary>
        [DataMember]
        public string values { get; set; }

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
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 开奖号码（如果还未开奖则为空）
        /// </summary>
        [DataMember]
        public string LotteryValue { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的投注信息
        /// </summary>
        public BettingExport()
        {

        }

        /// <summary>
        /// 实例化一个新的投注信息
        /// </summary>
        /// <param name="model">投注信息的数据模型</param>
        public BettingExport(Betting model)
        {
            this.Id = model.Id;
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.Issue = model.Issue;
            this.Notes = model.Notes;
            this.Multiple = model.Multiple;
            this.Points = model.Points;
            this.Ticket = model.HowToPlay.Tag.Ticket.Name;
            this.PlayTag = model.HowToPlay.Tag.Name;
            this.HowToPlay = model.HowToPlay.Name;
            this.values = model.GetBetStr();
            this.Status = model.Status;
            this.Pay = model.Pay;
            this.Bonus = model.Bonus;
            this.CreatedTime = model.CreatedTime;
            this.LotteryValue = model.LotteryValues;
        }

        #endregion
    }
}
