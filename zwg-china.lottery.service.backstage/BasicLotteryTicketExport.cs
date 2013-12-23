using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 基础的彩票信息
    /// </summary>
    [DataContract]
    public class BasicLotteryTicketExport
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

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的基础的彩票信息
        /// </summary>
        /// <param name="model">彩票信息的数据模型</param>
        public BasicLotteryTicketExport(LotteryTicket model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
        }
        
        #endregion
    }
}
