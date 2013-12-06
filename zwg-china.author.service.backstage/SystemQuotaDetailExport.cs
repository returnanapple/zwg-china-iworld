using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 系统设定的高点号配额方案的方案明细
    /// </summary>
    [DataContract]
    public class SystemQuotaDetailExport
    {
        #region 属性

        /// <summary>
        /// 返点
        /// </summary>
        [DataMember]
        public double Rebate { get; set; }

        /// <summary>
        /// 人数
        /// </summary>
        [DataMember]
        public int Sum { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的系统设定的高点号配额方案的方案明细
        /// </summary>
        public SystemQuotaDetailExport()
        {

        }

        /// <summary>
        /// 实例化一个新的系统设定的高点号配额方案的方案明细
        /// </summary>
        /// <param name="model">系统设定的高点号配额方案的方案明细的数据模型</param>
        public SystemQuotaDetailExport(SystemQuotaDetail model)
        {
            this.Sum = model.Sum;
            this.Rebate = model.Rebate;
        }

        #endregion
    }
}
