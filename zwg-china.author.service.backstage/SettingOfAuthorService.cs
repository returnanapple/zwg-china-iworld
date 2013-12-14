using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用户模块的相关设置的服务
    /// </summary>
    public class SettingOfAuthorService : ServiceBase, ISettingOfAuthorService
    {
        #region 获取数据

        /// <summary>
        /// 获取银行账户的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回</returns>
        public PageResult<SystemBankAccountExport> GetSystemBankAccounts(GetSystemBankAccountsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetSystemBankAccounts(db);
            }
            catch (Exception ex)
            {
                return new PageResult<SystemBankAccountExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取用户模块的系统设置
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回用户模块的系统设置</returns>
        public NormalResult<SettingOfAuthorExport> GetSettingOfAuthor(GetSettingOfAuthorImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetSettingOfAuthor(db);
            }
            catch (Exception ex)
            {
                return new NormalResult<SettingOfAuthorExport>(null, ex.Message);
            }
        }

        /// <summary>
        /// 获取系统设定的高点号配额方案
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回系统设定的高点号配额方案</returns>
        public NormalResult<List<SystemQuotaExport>> GetSystemQuotas(GetSystemQuotaImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetSystemQuota(db);
            }
            catch (Exception ex)
            {
                return new NormalResult<List<SystemQuotaExport>>(null, ex.Message);
            }
        }

        #endregion

        #region 操作

        /// <summary>
        /// 创建新的银行账户
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult CreateSystemBankAccount(CreateSystemBankAccountImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                SystemBankAccountManager manager = new SystemBankAccountManager(db);
                manager.Create(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 编辑银行账户
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditSystemBankAccount(EditSystemBankAccountImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                SystemBankAccountManager manager = new SystemBankAccountManager(db);
                manager.Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 删除银行账户
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult RemoveSystemBankAccount(RemoveSystemBankAccountImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                SystemBankAccountManager manager = new SystemBankAccountManager(db);
                manager.Remove(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 设置用户模块的系统设置
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult SetSettingOfAuthor(SetSettingOfAuthorImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                import.SetAndSave(db);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 设置系统设定的高点号配额方案
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult SetStstemQuota(SetStstemQuotaImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                import.SetAndSave(db);
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
