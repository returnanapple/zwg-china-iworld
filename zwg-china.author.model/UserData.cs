using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 用户的统计信息
    /// </summary>
    public class UserData : StatisticalDataModelBase
    {
        #region 属性

        /// <summary>
        /// 现金余额
        /// </summary>
        public double Money { get; set; }

        /// <summary>
        /// 被冻结的现金总额
        /// </summary>
        public double Money_Frozen { get; set; }

        /// <summary>
        /// 消费量
        /// </summary>
        public double Consumption { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public double Integral { get; set; }

        /// <summary>
        /// 直属下级数量
        /// </summary>
        public int Subordinate { get; set; }

        /// <summary>
        /// 直属的高点用户数量
        /// </summary>
        public virtual List<SubordinateData> SubordinateOfHighRebate { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        ///  实例化一个新的用户的统计信息
        /// </summary>
        public UserData()
        {
            this.Money = 0;
            this.Money_Frozen = 0;
            this.Consumption = 0;
            this.Integral = 0;
            this.Subordinate = 0;
            this.SubordinateOfHighRebate = new List<SubordinateData>();
        }

        #endregion
    }
}
