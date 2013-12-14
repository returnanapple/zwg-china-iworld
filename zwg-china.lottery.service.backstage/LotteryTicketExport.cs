using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 彩票信息
    /// </summary>
    [DataContract]
    public class LotteryTicketExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 每日开奖期数
        /// </summary>
        [DataMember]
        public int Installments { get; set; }

        /// <summary>
        /// 当前期号
        /// </summary>
        [DataMember]
        public string Issue { get; set; }

        /// <summary>
        /// 当期开奖记录
        /// </summary>
        [DataMember]
        public string LotteryValues { get; set; }

        /// <summary>
        /// 下一期的期号
        /// </summary>
        [DataMember]
        public string NextIssue { get; set; }

        /// <summary>
        /// 下辖的玩法标签
        /// </summary>
        [DataMember]
        public List<PlayTagExport> Tags { get; set; }

        /// <summary>
        /// 开奖时间
        /// </summary>
        [DataMember]
        public List<LotteryTimeExport> Times { get; set; }

        /// <summary>
        /// 一个布尔值，表示该彩票是否对前台客户隐藏
        /// </summary>
        [DataMember]
        public bool Hide { get; set; }

        /// <summary>
        /// 排序系数
        /// </summary>
        [DataMember]
        public int Order { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的彩票信息
        /// </summary>
        public LotteryTicketExport()
        {

        }

        /// <summary>
        /// 实例化一个新的彩票信息
        /// </summary>
        /// <param name="model">彩票信息的数据模型</param>
        public LotteryTicketExport(LotteryTicket model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Installments = model.Installments;
            this.Issue = model.Issue;
            this.LotteryValues = model.LotteryValues;
            this.NextIssue = model.NextIssue;
            this.Tags = model.Tags.ConvertAll(x => new PlayTagExport(x));
            this.Times = model.Times.ConvertAll(x => new LotteryTimeExport(x));
            this.Hide = model.Hide;
            this.Order = model.Order;
        }

        #endregion
    }
}
