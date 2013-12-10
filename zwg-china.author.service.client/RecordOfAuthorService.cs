using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;
using zwg_china.logic;

namespace zwg_china.service
{
    /// <summary>
    /// 用户相关的系统记录的数据服务
    /// </summary>
    public class RecordOfAuthorService : ServiceBase, IRecordOfAuthorService
    {
        #region 获取数据

        /// <summary>
        /// 获取充值记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回充值记录的分页列表</returns>
        public PageResult<RechargeRecordExport> GetRechargeDetails(GetRechargeDetailsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetRechargeDetails(db);
            }
            catch (Exception ex)
            {
                return new PageResult<RechargeRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取提现记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回提现记录的分页列表</returns>
        public PageResult<WithdrawalsRecordExport> GetWithdrawDetails(GetWithdrawDetailsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetWithdrawDetails(db);
            }
            catch (Exception ex)
            {
                return new PageResult<WithdrawalsRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取返点记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回返点记录的分页列表</returns>
        public PageResult<RebateRecordExport> GetRebateRecords(GetRebateRecordsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetRebateRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<RebateRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取佣金记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回佣金记录的分页列表</returns>
        public PageResult<CommissionRecordExport> GetCommissionRecords(GetCommissionRecordsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetCommissionRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<CommissionRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取分红记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回分红记录的分页列表</returns>
        public PageResult<DividendRecordExport> GetDividendRecords(GetDividendRecordsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetDividendRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<DividendRecordExport>(ex.Message);
            }
        }

        #endregion

        #region 操作

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult Recharge(RechargeImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new RechargeRecordManager(db).Create(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 提现
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult Withdraw(WithdrawImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new WithdrawalsRecordManager(db).Create(import);
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
