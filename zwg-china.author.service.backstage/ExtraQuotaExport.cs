using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 额外的直属高点号配额
    /// </summary>
    [DataContract]
    public class ExtraQuotaExport
    {
        #region 属性

        /// <summary>
        /// 返点
        /// </summary>
        [DataMember]
        public double Rebate { get; set; }

        /// <summary>
        /// 数额
        /// </summary>
        [DataMember]
        public int Sum { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的额外的直属高点号配额
        /// </summary>
        /// <param name="model">额外的直属高点号配额的数据模型</param>
        public ExtraQuotaExport(ExtraQuota model)
        {
            this.Rebate = model.Rebate;
            this.Sum = model.Sum;
        }

        #endregion
    }
}
