using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 追号信息
    /// </summary>
    [DataContract]
    public class ChasingExport
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
        /// 起始期号
        /// </summary>
        [DataMember]
        public string StartIssue { get; set; }

        /// <summary>
        /// 持续期数
        /// </summary>
        [DataMember]
        public int Continuance { get; set; }

        /// <summary>
        /// 注数
        /// </summary>
        [DataMember]
        public int Notes { get; set; }

        /// <summary>
        /// 用于转换为赔率的点数
        /// </summary>
        [DataMember]
        public double Points { get; set; }

        /// <summary>
        /// 玩法
        /// </summary>
        [DataMember]
        public string HowToPlay { get; set; }

        /// <summary>
        /// 投注号码
        /// </summary>
        [DataMember]
        public string Values { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        [DataMember]
        public ChasingStatus Status { get; set; }

        /// <summary>
        /// 投注总金额
        /// </summary>
        [DataMember]
        public double Pay { get; set; }

        /// <summary>
        /// 中奖金额（未中奖时候为0）
        /// </summary>
        [DataMember]
        public double Bonus { get; set; }

        /// <summary>
        /// 投注信息
        /// </summary>
        [DataMember]
        public List<BettingWithChasingExport> Bettings { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的追号信息
        /// </summary>
        public ChasingExport()
        {

        }

        /// <summary>
        /// 实例化一个新的追号信息
        /// </summary>
        /// <param name="model">追号信息的数据模型</param>
        /// <param name="bettings">所从属的投注信息的数据模型</param>
        public ChasingExport(Chasing model, List<BettingWithChasing> bettings)
        {
            this.Id = model.Id;
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.StartIssue = model.StartIssue;
            this.Continuance = model.Continuance;
            this.Notes = model.Notes;
            this.Points = model.Points;
            this.HowToPlay = model.GetDescription();
            this.Values = model.GetBetStr();
            this.Status = model.Status;
            this.Pay = model.Pay;
            this.Bonus = model.Bonus;
            this.Bettings = bettings.ConvertAll(x => new BettingWithChasingExport(x));
        }

        #endregion
    }
}
