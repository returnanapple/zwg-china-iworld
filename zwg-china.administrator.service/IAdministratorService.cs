using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 定义管理员相关的数据服务
    /// </summary>
    [ServiceContract]
    public interface IAdministratorService
    {
        #region 获取数据

        /// <summary>
        /// 获取管理员信息的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回管理员信息的分页列表</returns>
        [OperationContract]
        PageResult<BasicAdministratorExport> GetAdministrators(GetAdministratorsImport import);

        /// <summary>
        /// 获取管理员组的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回管理员组的分页列表</returns>
        [OperationContract]
        PageResult<AdministratorGroupExport> GetAdministratorGroups(GetAdministratorGroupsImport import);

        /// <summary>
        /// 获取基础的管理员用户组信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns><返回基础的管理员用户组信息/returns>
        [OperationContract]
        NormalResult<List<BasicAdministratorGroupExport>> GetBasicAdministratorGroups(GetBasicAdministratorGroupsImport import);

        /// <summary>
        /// 获取管理员登陆记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回管理员登陆记录的分页列表</returns>
        [OperationContract]
        PageResult<AdministratorLandingRecordExport> GetAdministratorLandingRecords(GetAdministratorLandingRecordsImport import);

        /// <summary>
        /// 获取操作记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作记录的分页列表</returns>
        [OperationContract]
        PageResult<OperateRecordExport> GetOperatedRecords(GetOperatedRecordsImport import);

        #endregion

        #region 操作

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult<AdministratorExport> Login(LoginImport import);

        /// <summary>
        /// 创建新的管理员
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateAdministrator(CreateAdministratorImport import);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditPassword(EditPasswordImport import);

        /// <summary>
        /// 改变管理员组
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult ChangeGroup(ChangeGroupImport import);

        /// <summary>
        /// 移除管理员
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult RemoveAdministrator(RemoveAdministratorImport import);

        /// <summary>
        /// 创建新的管理员组
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateAdministratorGroup(CreateAdministratorGroupImport import);

        /// <summary>
        /// 修改管理员组
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditAdministratorGroup(EditAdministratorGroupImport import);

        /// <summary>
        /// 移除管理员组
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult RemoveAdministratorGroup(RemoveAdministratorGroupImport import);

        #endregion

        #region 心跳协议

        /// <summary>
        /// 保持心跳
        /// </summary>
        /// <param name="token">身份标识</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult KeepHeartbeat(string token);

        #endregion
    }
}
