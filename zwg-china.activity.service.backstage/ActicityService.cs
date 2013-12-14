using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 活动模块的数据服务
    /// </summary>:
    public class ActicityService : ServiceBase, IActicityService
    {
        #region 获取数据

        /// <summary>
        /// 获取注册奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回注册奖励的计划</returns>
        public PageResult<RewardForRegisterPlanExport> GetRewardForRegisterPlans(GetRewardForRegisterPlansImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetRewardForRegisterPlans(db);
            }
            catch (Exception ex)
            {
                return new PageResult<RewardForRegisterPlanExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取注册奖励的参与记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回注册奖励的参与记录</returns>
        public PageResult<RewardForRegisterRecordExport> GetRewardForRegisterRecords(GetRewardForRegisterRecordsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetRewardForRegisterRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<RewardForRegisterRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取消费奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回消费奖励的计划</returns>
        public PageResult<RewardForConsumptionPlanExport> GetRewardForConsumptionPlans(GetRewardForConsumptionPlansImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetRewardForConsumptionPlans(db);
            }
            catch (Exception ex)
            {
                return new PageResult<RewardForConsumptionPlanExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取消费奖励的参与记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回消费奖励的参与记录</returns>
        public PageResult<RewardForConsumptionRecordExport> GetRewardForConsumptionRecords(GetRewardForConsumptionRecordsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetRewardForConsumptionRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<RewardForConsumptionRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取充值奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回充值奖励的计划</returns>
        public PageResult<RewardForRechargePlanExport> GetRewardForRechargePlans(GetRewardForRechargePlansImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetRewardForRechargePlans(db);
            }
            catch (Exception ex)
            {
                return new PageResult<RewardForRechargePlanExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取充值奖励的参与记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回充值奖励的参与记录</returns>
        public PageResult<RewardForRechargeRecordExport> GetRewardForRechargeRecords(GetRewardForRechargeRecordsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetRewardForRechargeRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<RewardForRechargeRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取积分兑换的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回积分兑换的计划</returns>
        public PageResult<RedeemPlanExport> GetRedeemPlans(GetRedeemPlansImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetRedeemPlans(db);
            }
            catch (Exception ex)
            {
                return new PageResult<RedeemPlanExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取积分兑换的参与记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回积分兑换的参与记录</returns>
        public PageResult<RedeemRecordExport> GetRedeemRecords(GetRedeemRecordsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetRedeemRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<RedeemRecordExport>(ex.Message);
            }
        }

        #endregion

        #region 操作

        /// <summary>
        /// 创建注册奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult CreateRewardForRegisterPlan(CreateRewardForRegisterPlanImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new RewardForRegisterPlanManager(db).Create(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改注册奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditRewardForRegisterPlan(EditRewardForRegisterPlanImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new RewardForRegisterPlanManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 移除注册奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult RemoveRewardForRegisterPlan(RemoveRewardForRegisterPlanImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new RewardForRegisterPlanManager(db).Remove(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 创建消费奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult CreateRewardForConsumptionPlan(CreateRewardForConsumptionPlanImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new RewardForConsumptionPlanManager(db).Create(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改消费奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditRewardForConsumptionPlan(EditRewardForConsumptionPlanImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new RewardForConsumptionPlanManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 移除消费奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult RemoveRewardForConsumptionPlan(RemoveRewardForConsumptionPlanImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new RewardForConsumptionPlanManager(db).Remove(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 创建充值奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult CreateRewardForRechargePlan(CreateRewardForRechargePlanImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new RewardForRechargePlanManager(db).Create(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改充值奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditRewardForRechargePlan(EditRewardForRechargePlanImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new RewardForRechargePlanManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 移除充值奖励的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult RemoveRewardForRechargePlan(RemoveRewardForRechargePlanImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new RewardForRechargePlanManager(db).Remove(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 创建积分兑换的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult CreateRedeemPlan(CreateRedeemPlanImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new RedeemPlanManager(db).Create(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改积分兑换的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditRedeemPlan(EditRedeemPlanImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new RedeemPlanManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 移除积分兑换的计划
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult RemoveRedeemPlan(RemoveRedeemPlanImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new RedeemPlanManager(db).Remove(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        #endregion
    }
}
