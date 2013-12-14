using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 定义用户模块的相关记录的服务
    /// </summary>
    [ServiceContract]
    public interface IRecordOfAuthorService
    {
        #region 获取数据

        /// <summary>
        /// 获取转账记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回转账记录的分页列表</returns>
        [OperationContract]
        PageResult<TransferRecordExport> GetTransferRecords(GetTransferRecordsImport import);

        /// <summary>
        /// 获取充值记录分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回充值记录分页列表</returns>
        [OperationContract]
        PageResult<RechargeRecordExport> GetRechargeRecords(GetRechargeRecordsImport import);

        /// <summary>
        /// 获取未处理的提现记录的数量
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回未处理的提现记录的数量</returns>
        [OperationContract]
        NormalResult<int> GetCountOfUntreatedWithdrawalsRecords(GetCountOfUntreatedWithdrawalsRecordsImport import);

        /// <summary>
        /// 获取提现记录分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回提现记录分页列表</returns>
        [OperationContract]
        PageResult<WithdrawalsRecordExport> GetWithdrawalsRecords(GetWithdrawalsRecordsImport import);

        /// <summary>
        /// 获取帐变记录分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回帐变记录分页列表</returns>
        [OperationContract]
        PageResult<MoneyChangeRecordExport> GetMoneyChangeRecords(GetMoneyChangeRecordsImport import);

        /// <summary>
        /// 获取返点记录分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回返点记录分页列表</returns>
        [OperationContract]
        PageResult<RebateRecordExport> GetRebateRecords(GetRebateRecordsImport import);

        /// <summary>
        /// 获取佣金记录分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回佣金记录分页列表</returns>
        [OperationContract]
        PageResult<CommissionRecordExport> GetCommissionRecords(GetCommissionRecordsImport import);

        /// <summary>
        /// 获取分红记录分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回分红记录分页列表</returns>
        [OperationContract]
        PageResult<DividendRecordExport> GetDividendRecords(GetDividendRecordsImport import);

        #endregion

        #region 操作

        /// <summary>
        /// 创建新的充值记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateRechargeRecord(CreateRechargeRecordImport import);

        /// <summary>
        /// 设置提现记录的新状态
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult SetWithdrawslsStatus(SetWithdrawslsStatusImport import);

        #endregion
    }
}
