using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace zwg_china.service
{
    /// <summary>
    /// 定义活动模块的数据服务
    /// </summary>
    [ServiceContract]
    public interface IActicityService_Backstage
    {
        #region 获取数据

        /// <summary>
        /// 获取注册奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回注册奖励的计划</returns>
        [OperationContract]
        PageResult<RewardForRegisterPlanExport> GetRewardForRegisterPlans(GetRewardForRegisterPlansImport import);

        /// <summary>
        /// 获取注册奖励的参与记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回注册奖励的参与记录</returns>
        [OperationContract]
        PageResult<RewardForRegisterRecordExport> GetRewardForRegisterRecords(GetRewardForRegisterRecordsImport import);

        /// <summary>
        /// 获取消费奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回消费奖励的计划</returns>
        [OperationContract]
        PageResult<RewardForConsumptionPlanExport> GetRewardForConsumptionPlans(GetRewardForConsumptionPlansImport_Backstage import);

        /// <summary>
        /// 获取消费奖励的参与记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回消费奖励的参与记录</returns>
        [OperationContract]
        PageResult<RewardForConsumptionRecordExport> GetRewardForConsumptionRecords(GetRewardForConsumptionRecordsImport_Backstage import);

        /// <summary>
        /// 获取充值奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回充值奖励的计划</returns>
        [OperationContract]
        PageResult<RewardForRechargePlanExport> GetRewardForRechargePlans(GetRewardForRechargePlansImport_Backstage import);

        /// <summary>
        /// 获取充值奖励的参与记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回充值奖励的参与记录</returns>
        [OperationContract]
        PageResult<RewardForRechargeRecordExport> GetRewardForRechargeRecords(GetRewardForRechargeRecordsImport import);

        /// <summary>
        /// 获取积分兑换的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回积分兑换的计划</returns>
        [OperationContract]
        PageResult<RedeemPlanExport> GetRedeemPlans(GetRedeemPlansImport_Backstage import);

        /// <summary>
        /// 获取积分兑换的参与记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回积分兑换的参与记录</returns>
        [OperationContract]
        PageResult<RedeemRecordExport> GetRedeemRecords(GetRedeemRecordsImport_Backstage import);

        #endregion

        #region 操作

        /// <summary>
        /// 创建注册奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateRewardForRegisterPlan(CreateRewardForRegisterPlanImport_Backstage import);

        /// <summary>
        /// 修改注册奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditRewardForRegisterPlan(EditRewardForRegisterPlanImport_Backstage import);

        /// <summary>
        /// 移除注册奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult RemoveRewardForRegisterPlan(RemoveRewardForRegisterPlanImport import);

        /// <summary>
        /// 创建消费奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateRewardForConsumptionPlan(CreateRewardForConsumptionPlanImport_Backstage import);

        /// <summary>
        /// 修改消费奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditRewardForConsumptionPlan(EditRewardForConsumptionPlanImport_Backstage import);

        /// <summary>
        /// 移除消费奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult RemoveRewardForConsumptionPlan(RemoveRewardForConsumptionPlanImport import);

        /// <summary>
        /// 创建充值奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateRewardForRechargePlan(CreateRewardForRechargePlanImport_Backstage import);

        /// <summary>
        /// 修改充值奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditRewardForRechargePlan(EditRewardForRechargePlanImport_Backstage import);

        /// <summary>
        /// 移除充值奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult RemoveRewardForRechargePlan(RemoveRewardForRechargePlanImport import);

        /// <summary>
        /// 创建积分兑换的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateRedeemPlan(CreateRedeemPlanImport_Backstage import);

        /// <summary>
        /// 修改积分兑换的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditRedeemPlan(EditRedeemPlanImport_Backstage import);

        /// <summary>
        /// 移除积分兑换的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult RemoveRedeemPlan(RemoveRedeemPlanImport import);

        #endregion
    }
}
