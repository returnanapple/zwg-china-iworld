using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 开奖时间
    /// </summary>
    [DataContract]
    public class LotteryTimeExport
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

        #region 构造方法

        /// <summary>
        /// 实例化一个新的开奖时间
        /// </summary>
        public LotteryTimeExport()
        {

        }

        /// <summary>
        /// 实例化一个新的开奖时间
        /// </summary>
        /// <param name="model">开奖时间的数据模型</param>
        public LotteryTimeExport(LotteryTime model)
        {
            this.Issue = model.Issue;
            this.TimeValue = model.TimeValue;
        }

        #endregion
    }
}
