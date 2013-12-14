using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.client
{
    /// <summary>
    /// 投注位的数据集
    /// </summary>
    [DataContract]
    public class BetSeatImport
    {
        #region 属性

        /// <summary>
        /// 位名
        /// </summary>
        [DataMember]
        public string SeatNmae { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [DataMember]
        public string Values { get; set; }

        #endregion
    }
}
