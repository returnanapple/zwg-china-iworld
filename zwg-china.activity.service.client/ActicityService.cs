using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 活动模块的数据服务
    /// </summary>
    public class ActicityService : ServiceBase, IActicityService
    {
        #region 获取数据

        /// <summary>
        /// 获取积分兑换的计划的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回积分兑换的计划的分页列表</returns>
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
        /// 获取积分兑换的参与记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回积分兑换的参与记录的分页列表</returns>
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
        /// 创建新的积分兑换的参与记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult CreateRedeemRecords(CreateRedeemRecordsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new RedeemRecordManager(db).Create(import);
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
