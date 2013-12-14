using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.service.client
{
    /// <summary>
    /// 用于投注（追号）的数据集
    /// </summary>
    [DataContract]
    public class BettingWithChasingImport
    {
        #region 属性

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

        #endregion
    }
}
