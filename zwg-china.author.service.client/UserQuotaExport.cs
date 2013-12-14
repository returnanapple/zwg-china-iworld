using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.service.client
{
    /// <summary>
    /// 高点号配额的剩余量
    /// </summary>
    [DataContract]
    public class UserQuotaExport
    {
        #region 属性

        /// <summary>
        /// 返点
        /// </summary>
        [DataMember]
        public double Rebate { get; set; }

        /// <summary>
        /// 剩余量
        /// </summary>
        [DataMember]
        public int Surplus { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的高点号配额的剩余量
        /// </summary>
        public UserQuotaExport()
        {

        }

        /// <summary>
        /// 实例化一个新的高点号配额的剩余量
        /// </summary>
        /// <param name="rebate">返点</param>
        /// <param name="surplus">剩余量</param>
        public UserQuotaExport(double rebate, int surplus)
        {
            this.Rebate = rebate;
            this.Surplus = surplus;
        }

        #endregion
    }
}
