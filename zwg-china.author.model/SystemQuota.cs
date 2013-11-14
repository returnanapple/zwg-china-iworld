using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 系统设定的高点号配额方案
    /// </summary>
    public class SystemQuota : ModelBase
    {
        #region 属性

        /// <summary>
        /// 返点
        /// </summary>
        public double Rebate { get; set; }

        /// <summary>
        /// 方案明细
        /// </summary>
        public virtual List<SystemQuotaDetail> Detail { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的系统设定的高点号配额方案
        /// </summary>
        public SystemQuota()
        {
        }

        /// <summary>
        /// 实例化一个新的系统设定的高点号配额方案
        /// </summary>
        /// <param name="rebate">返点</param>
        /// <param name="detail">方案明细</param>
        public SystemQuota(double rebate, List<SystemQuotaDetail> detail)
        {
            this.Rebate = rebate;
            this.Detail = detail;
        }

        #endregion
    }
}
