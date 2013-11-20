using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 注册奖励的参与记录
    /// </summary>
    public class RewardForRegisterRecord : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 用户
        /// </summary>
        public virtual Author Owner { get; set; }

        /// <summary>
        /// 对应的计划（快照）
        /// </summary>
        public virtual RewardForRegisterSnapshot Plan { get; set; }

        /// <summary>
        /// 奖品类型
        /// </summary>
        public PrizesOfActivityType PrizeType { get; set; }

        /// <summary>
        /// 奖励数额
        /// </summary>
        public double Sum { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的注册奖励的参与记录
        /// </summary>
        public RewardForRegisterRecord()
        {

        }

        /// <summary>
        /// 实例化一个新的注册奖励的参与记录
        /// </summary>
        /// <param name="owner">用户</param>
        /// <param name="plan">对应的计划（快照）</param>
        public RewardForRegisterRecord(Author owner, RewardForRegisterSnapshot plan)
        {
            this.Owner = owner;
            this.Plan = plan;
            this.PrizeType = plan.PrizeType;
            this.Sum = plan.Sum;
        }

        #endregion
    }
}
