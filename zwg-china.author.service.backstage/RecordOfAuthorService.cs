using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用户模块的相关记录的服务
    /// </summary>
    public class RecordOfAuthorService : ServiceBase, IRecordOfAuthorService
    {
        #region 获取数据

        /// <summary>
        /// 获取转账记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回转账记录的分页列表</returns>
        public PageResult<TransferRecordExport> GetTransferRecords(GetTransferRecordsImport import)
        {
            try
            {
                return import.GetTransferRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<TransferRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取充值记录分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回充值记录分页列表</returns>
        public PageResult<RechargeRecordExport> GetRechargeRecords(GetRechargeRecordsImport import)
        {
            try
            {
                return import.GetRechargeRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<RechargeRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取提现记录分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回提现记录分页列表</returns>
        public PageResult<WithdrawalsRecordExport> GetWithdrawalsRecords(GetWithdrawalsRecordsImport import)
        {
            try
            {
                return import.GetWithdrawalsRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<WithdrawalsRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取帐变记录分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回帐变记录分页列表</returns>
        public PageResult<MoneyChangeRecordExport> GetMoneyChangeRecords(GetMoneyChangeRecordsImport import)
        {
            try
            {
                return import.GetMoneyChangeRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<MoneyChangeRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取返点记录分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回返点记录分页列表</returns>
        public PageResult<RebateRecordExport> GetRebateRecords(GetRebateRecordsImport import)
        {
            try
            {
                return import.GetRebateRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<RebateRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取佣金记录分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回佣金记录分页列表</returns>
        public PageResult<CommissionRecordExport> GetCommissionRecords(GetCommissionRecordsImport import)
        {
            try
            {
                return import.GetCommissionRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<CommissionRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取分红记录分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回分红记录分页列表</returns>
        public PageResult<DividendRecordExport> GetDividendRecords(GetDividendRecordsImport import)
        {
            try
            {
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
        /// 创建新的充值记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult CreateRechargeRecord(CreateRechargeRecordImport import)
        {
            try
            {
                RechargeRecordManager manager = new RechargeRecordManager(db);
                manager.Create(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 设置提现记录的新状态
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult SetWithdrawslsStatus(SetWithdrawslsStatusImport import)
        {
            try
            {
                WithdrawalsRecordManager manager = new WithdrawalsRecordManager(db);
                manager.ChangeStatus(import);
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
