using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace zwg_china.service.client
{
    /// <summary>
    /// 定义用户相关的系统记录的数据服务
    /// </summary>
    [ServiceContract]
    public interface IRecordOfAuthorService
    {
        #region 获取数据

        /// <summary>
        /// 获取帐变记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回帐变记录的分页列表</returns>
        [OperationContract]
        PageResult<MoneyChangeRecordExport> GetMoneyChangeRecords(GetMoneyChangeRecordsImport import);

        /// <summary>
        /// 获取充值记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回充值记录的分页列表</returns>
        [OperationContract]
        PageResult<RechargeRecordExport> GetRechargeDetails(GetRechargeDetailsImport import);

        /// <summary>
        /// 获取提现记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回提现记录的分页列表</returns>
        [OperationContract]
        PageResult<WithdrawalsRecordExport> GetWithdrawDetails(GetWithdrawDetailsImport import);

        /// <summary>
        /// 获取返点记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回返点记录的分页列表</returns>
        [OperationContract]
        PageResult<RebateRecordExport> GetRebateRecords(GetRebateRecordsImport import);

        /// <summary>
        /// 获取佣金记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回佣金记录的分页列表</returns>
        [OperationContract]
        PageResult<CommissionRecordExport> GetCommissionRecords(GetCommissionRecordsImport import);

        /// <summary>
        /// 获取分红记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回分红记录的分页列表</returns>
        [OperationContract]
        PageResult<DividendRecordExport> GetDividendRecords(GetDividendRecordsImport import);

        #endregion

        #region 操作

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult Recharge(RechargeImport import);

        /// <summary>
        /// 提现
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult Withdraw(WithdrawImport import);

        #endregion
    }
}
