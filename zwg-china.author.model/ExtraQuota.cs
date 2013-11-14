using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 额外的直属高点号配额
    /// </summary>
    public class ExtraQuota : ModelBase
    {
        #region 属性

        /// <summary>
        /// 返点
        /// </summary>
        public double Rebate { get; set; }

        /// <summary>
        /// 人数
        /// </summary>
        public int Sum { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的额外的直属高点号配额
        /// </summary>
        public ExtraQuota()
        {
        }

        /// <summary>
        /// 实例化一个新的额外的直属高点号配额
        /// </summary>
        /// <param name="rebate">返点</param>
        /// <param name="sum">人数</param>
        public ExtraQuota(double rebate, int sum)
        {
            this.Rebate = rebate;
            this.Sum = sum;
        }

        #endregion
    }
}
