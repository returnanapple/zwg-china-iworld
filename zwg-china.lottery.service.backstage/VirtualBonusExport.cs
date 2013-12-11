using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 虚拟排行信息
    /// </summary>
    [DataContract]
    public class VirtualBonusExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 对应的彩票的存储指针
        /// </summary>
        [DataMember]
        public int TicketId { get; set; }

        /// <summary>
        /// 对应的彩票的名称
        /// </summary>
        [DataMember]
        public string Ticket { get; set; }

        /// <summary>
        /// 期号
        /// </summary>
        [DataMember]
        public string Issue { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        public double Sum { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的虚拟排行信息
        /// </summary>
        public VirtualBonusExport()
        {

        }

        /// <summary>
        /// 实例化一个新的虚拟排行信息
        /// </summary>
        /// <param name="model">虚拟排行信息的数据模型</param>
        public VirtualBonusExport(VirtualBonus model)
        {
            this.Id = model.Id;
            this.TicketId = model.Ticket.Id;
            this.Ticket = model.Ticket.Name;
            this.Issue = model.Issue;
            this.Sum = model.Sum;
        }

        #endregion
    }
}
