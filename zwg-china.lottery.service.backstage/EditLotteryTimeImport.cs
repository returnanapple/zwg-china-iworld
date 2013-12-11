using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.service
{
    /// <summary>
    /// 用于修改开奖时间的数据集
    /// </summary>
    [DataContract]
    public class EditLotteryTimeImport
    {
        #region 属性

        /// <summary>
        /// 期号
        /// </summary>
        [DataMember]
        public int Issue { get; set; }

        /// <summary>
        /// 时间的值（“小时：分：秒”格式）
        /// </summary>
        [DataMember]
        public string TimeValue { get; set; }

        #endregion
    }
}
