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
        #region 私有字段

        double money = 0;
        double money_Frozen = 0;
        double consumption = 0;
        double integral = 0;
        int subordinate = 0;
        List<SubordinateData> subordinateOfHighRebate = new List<SubordinateData>();

        #endregion

        #region 属性

        /// <summary>
        /// 现金余额
        /// </summary>
        public double Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("现金余额不能小于0");
                }
                money = value;
            }
        }

        /// <summary>
        /// 被冻结的现金总额
        /// </summary>
        public double Money_Frozen
        {
            get { return money_Frozen; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("被冻结的现金总额不能小于0");
                }
                money_Frozen = value;
            }
        }

        /// <summary>
        /// 消费量
        /// </summary>
        public double Consumption
        {
            get { return consumption; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("消费量不能小于0");
                }
                consumption = value;
            }
        }

        /// <summary>
        /// 积分
        /// </summary>
        public double Integral
        {
            get { return integral; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("积分不能小于0");
                }
                integral = value;
            }
        }

        /// <summary>
        /// 直属下级数量
        /// </summary>
        public int Subordinate
        {
            get { return subordinate; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("直属下级数量不能小于0");
                }
                subordinate = value;
            }
        }

        /// <summary>
        /// 直属的高点用户数量
        /// </summary>
        public virtual List<SubordinateData> SubordinateOfHighRebate
        {
            get { return subordinateOfHighRebate; }
            set { subordinateOfHighRebate = value; }
        }

        #endregion

        #region 构造方法

        /// <summary>
        ///  实例化一个新的用户的统计信息
        /// </summary>
        public UserData()
        {
        }

        #endregion
    }
}
