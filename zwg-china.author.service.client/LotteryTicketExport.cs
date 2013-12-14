using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.client
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
        /// 下一期开奖时间
        /// </summary>
        [DataMember]
        public DateTime NextLotteryTime { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的彩票信息
        /// </summary>
        /// <param name="model">彩票信息的数据模型</param>
        public LotteryTicketExport(LotteryTicket model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Issue = model.Issue;
            this.NextIssue = model.NextIssue;
            this.NextLotteryTime = model.NextLotteryTime;
        }

        #endregion
    }
}
