using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 用户组
    /// </summary>
    public class UserGroup : ModelBase
    {
        #region 公开属性

        #region 基本信息

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// 消费量下限
        /// </summary>
        public double LowerOfConsumption { get; set; }

        /// <summary>
        /// 消费量上限
        /// </summary>
        public double CapsOfConsumption { get; set; }

        #endregion

        #region 权限

        /// <summary>
        /// 每日允许提现次数（如为0则采用系统参数）
        /// </summary>
        public int TimesOfWithdrawal { get; set; }

        /// <summary>
        /// 单笔最低取款金额（如为0则采用系统参数）
        /// </summary>
        public double MinimumWithdrawalAmount { get; set; }

        /// <summary>
        /// 单笔最高取款金额（如为0则采用系统参数）
        /// </summary>
        public double MaximumWithdrawalAmount { get; set; }

        #endregion

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户组
        /// </summary>
        public UserGroup()
        {
        }

        /// <summary>
        /// 实例化一个新的用户组
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="grade">等级</param>
        /// <param name="lowerOfConsumption">消费量下限</param>
        /// <param name="capsOfConsumption">消费量上限</param>
        /// <param name="timesOfWithdrawal">每日允许提现次数</param>
        /// <param name="minimumWithdrawalAmount">单笔最低取款金额</param>
        /// <param name="maximumWithdrawalAmount">单笔最高取款金额</param>
        public UserGroup(string name, int grade, double lowerOfConsumption, double capsOfConsumption, int timesOfWithdrawal
            , double minimumWithdrawalAmount, double maximumWithdrawalAmount, double minimumRechargeAmount)
        {
            this.Name = name;
            this.Grade = grade;
            this.LowerOfConsumption = lowerOfConsumption;
            this.CapsOfConsumption = capsOfConsumption;
            this.TimesOfWithdrawal = timesOfWithdrawal;
            this.MinimumWithdrawalAmount = minimumWithdrawalAmount;
            this.MaximumWithdrawalAmount = maximumWithdrawalAmount;
        }

        #endregion
    }
}
