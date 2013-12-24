using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 开奖记录
    /// </summary>
    [DataContract]
    public class LotteryExport
    {
        #region 属性

        /// <summary>
        /// 期号
        /// </summary>
        [DataMember]
        public string Issue { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [DataMember]
        public LotterySources Sources { get; set; }

        /// <summary>
        /// 彩种的存储指针
        /// </summary>
        [DataMember]
        public int TicketId { get; set; }

        /// <summary>
        /// 彩种的名称
        /// </summary>
        [DataMember]
        public string Ticket { get; set; }

        /// <summary>
        /// 开奖号码
        /// </summary>
        [DataMember]
        public string Values { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的开奖记录
        /// </summary>
        public LotteryExport()
        {

        }

        /// <summary>
        /// 实例化一个新的开奖记录
        /// </summary>
        /// <param name="model">开奖记录的数据模型</param>
        public LotteryExport(Lottery model)
        {
            this.Issue = model.Issue;
            this.Sources = model.Sources;
            this.TicketId = model.Ticket.Id;
            this.Ticket = model.Ticket.Name;
            this.Values = string.Join(",", model.Seats.ConvertAll(x => x.Value));
            this.CreatedTime = model.CreatedTime;
        }

        #endregion
    }
}
