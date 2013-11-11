using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 直属的高点号统计
    /// </summary>
    public class SubordinateData : ModelBase
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
        /// 实例化一个新的直属的高点号统计
        /// </summary>
        public SubordinateData()
        {
        }

        /// <summary>
        /// 实例化一个新的直属的高点号统计
        /// </summary>
        /// <param name="rebate">返点</param>
        /// <param name="sum">人数</param>
        public SubordinateData(double rebate, int sum)
        {
            this.Rebate = rebate;
            this.Sum = sum;
        }

        #endregion
    }
}
