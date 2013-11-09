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

        #region 现金账户

        /// <summary>
        /// 现金
        /// </summary>
        public double Cash { get; set; }

        /// <summary>
        /// 被冻结的现金
        /// </summary>
        public double Cash_Frozen { get; set; }

        /// <summary>
        /// 消费量（现金）
        /// </summary>
        public double Consumption_Money { get; set; }

        #endregion

        #region 积分账户

        /// <summary>
        /// 积分
        /// </summary>
        public double Integral { get; set; }

        /// <summary>
        /// 消费量（积分）
        /// </summary>
        public double Consumption_Integral { get; set; }

        #endregion

        #region 统计数据

        /// <summary>
        /// 直属下级数量
        /// </summary>
        public int Subordinate { get; set; }

        #endregion

        #endregion

        #region 构造方法

        /// <summary>
        ///  实例化一个新的用户的统计信息
        /// </summary>
        public UserData()
        {
            this.Cash = 0;
            this.Cash_Frozen = 0;
            this.Consumption_Money = 0;
            this.Integral = 0;
            this.Consumption_Integral = 0;
            this.Subordinate = 0;
        }

        #endregion
    }
}
