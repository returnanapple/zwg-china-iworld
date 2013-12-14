using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace zwg_china.service.client
{
    /// <summary>
    /// 定义活动模块的数据服务
    /// </summary>
    [ServiceContract]
    public interface IActicityService
    {
        #region 获取数据

        /// <summary>
        /// 获取积分兑换的计划的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回积分兑换的计划的分页列表</returns>
        [OperationContract]
        PageResult<RedeemPlanExport> GetRedeemPlans(GetRedeemPlansImport import);

        /// <summary>
        /// 获取积分兑换的参与记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回积分兑换的参与记录的分页列表</returns>
        [OperationContract]
        PageResult<RedeemRecordExport> GetRedeemRecords(GetRedeemRecordsImport import);

        #endregion

        #region 操作

        /// <summary>
        /// 创建新的积分兑换的参与记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateRedeemRecords(CreateRedeemRecordsImport import);

        #endregion
    }
}
