using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 定义活动模块的数据库连接对象
    /// </summary>
    public interface IModelToDbContextOfActivity
    {
        /// <summary>
        /// 注册奖励的计划的数据存储区
        /// </summary>
        DbSet<RewardForRechargePlan> RewardForRechargePlans { get; set; }

        /// <summary>
        /// 注册奖励的计划的快照的数据存储区
        /// </summary>
        DbSet<RewardForRegisterSnapshot> RewardForRegisterSnapshots { get; set; }

        /// <summary>
        /// 注册奖励的参与记录的数据存储区
        /// </summary>
        DbSet<RewardForRegisterRecord> RewardForRegisterRecords { get; set; }

        /// <summary>
        /// 消费奖励的计划的数据存储区
        /// </summary>
        DbSet<RewardForConsumptionPlan> RewardForConsumptionPlans { get; set; }

        /// <summary>
        /// 消费奖励的计划的快照的数据存储区
        /// </summary>
        DbSet<RewardForConsumptionSnapshot> RewardForConsumptionSnapshots { get; set; }

        /// <summary>
        /// 消费奖励的参与记录的数据存储区
        /// </summary>
        DbSet<RewardForConsumptionRecord> RewardForConsumptionRecords { get; set; }

        /// <summary>
        /// 充值奖励的计划的数据存储区
        /// </summary>
        DbSet<RewardForRechargePlan> RewardForRechargePlans { get; set; }

        /// <summary>
        /// 充值奖励的计划的快照的数据存储区
        /// </summary>
        DbSet<RewardForRechargeSnapshot> RewardForRechargeSnapshots { get; set; }

        /// <summary>
        /// 充值奖励的参与记录的数据存储区
        /// </summary>
        DbSet<RewardForRechargeRecord> RewardForRechargeRecords { get; set; }

        /// <summary>
        /// 积分兑换的计划的数据存储区
        /// </summary>
        DbSet<RedeemPlan> RedeemPlans { get; set; }

        /// <summary>
        /// 积分兑换的计划的快照的数据存储区
        /// </summary>
        DbSet<RedeemSnapshot> RedeemSnapshots { get; set; }

        /// <summary>
        /// 积分兑换的参与记录的数据存储区
        /// </summary>
        DbSet<RedeemRecord> RedeemRecords { get; set; }
    }
}
