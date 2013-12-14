using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 系统设定的高点号配额方案
    /// </summary>
    [DataContract]
    public class SystemQuotaExport
    {
        #region 属性

        /// <summary>
        /// 返点
        /// </summary>
        [DataMember]
        public double Rebate { get; set; }

        /// <summary>
        /// 方案明细
        /// </summary>
        [DataMember]
        public List<SystemQuotaDetailExport> Details { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的系统设定的高点号配额方案
        /// </summary>
        public SystemQuotaExport()
        {

        }

        /// <summary>
        /// 实例化一个新的系统设定的高点号配额方案
        /// </summary>
        /// <param name="model">系统设定的高点号配额方案的数据模型</param>
        public SystemQuotaExport(SystemQuota model)
        {
            this.Rebate = model.Rebate;
            this.Details = model.Details.ConvertAll(x => new SystemQuotaDetailExport(x));
        }

        #endregion
    }
}
