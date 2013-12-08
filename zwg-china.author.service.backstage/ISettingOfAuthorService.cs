using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace zwg_china.service
{
    /// <summary>
    /// 定义用户模块的相关设置的服务
    /// </summary>
    [ServiceContract]
    public interface ISettingOfAuthorService
    {
        #region 获取数据

        /// <summary>
        /// 获取银行账户的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回</returns>
        [OperationContract]
        PageResult<SystemBankAccountExport> GetSystemBankAccounts(GetSystemBankAccountsImport import);

        /// <summary>
        /// 获取用户模块的系统设置
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回用户模块的系统设置</returns>
        [OperationContract]
        NormalResult<SettingOfAuthorExport> GetSettingOfAuthor(GetSettingOfAuthorImport import);

        /// <summary>
        /// 获取系统设定的高点号配额方案
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回系统设定的高点号配额方案</returns>
        [OperationContract]
        NormalResult<List<SystemQuotaExport>> GetSystemQuotas(GetSystemQuotaImport import);

        #endregion

        #region 操作

        /// <summary>
        /// 创建新的银行账户
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateSystemBankAccount(CreateSystemBankAccountImport import);

        /// <summary>
        /// 编辑银行账户
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditSystemBankAccount(EditSystemBankAccountImport import);

        /// <summary>
        /// 删除银行账户
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult RemoveSystemBankAccount(RemoveSystemBankAccountImport import);

        /// <summary>
        /// 设置用户模块的系统设置
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult SetSettingOfAuthor(SetSettingOfAuthorImport import);

        /// <summary>
        /// 设置系统设定的高点号配额方案
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult SetStstemQuota(SetStstemQuotaImport import);

        #endregion
    }
}
