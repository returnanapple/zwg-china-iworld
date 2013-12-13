using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace zwg_china.service
{
    /// <summary>
    /// 定义用户模块的后台服务
    /// </summary>
    [ServiceContract]
    public interface IAuthorService
    {
        #region 数据

        /// <summary>
        /// 获取用户信息的分页列表
        /// </summary>
        /// <param name="import">参数集</param>
        /// <returns>返回用户信息的分页列表</returns>
        [OperationContract]
        PageResult<AuthorExport> GetUsers(GetUsersImport import);

        /// <summary>
        /// 获取用户登录记录的分页列表
        /// </summary>
        /// <param name="import">参数集</param>
        /// <returns>返回用户登录记录的分页列表</returns>
        [OperationContract]
        PageResult<AuthorLandingRecordExport> GetLandingRecords(GetLandingRecordsImport import);

        /// <summary>
        /// 获取基础的用户组信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回基础的用户组信息</returns>
        [OperationContract]
        NormalResult<List<BasicUserGroupExport>> GetBasicUserGroups(GetBasicUserGroupsImport import);

        /// <summary>
        /// 获取用户组信息的分页列表
        /// </summary>
        /// <param name="import">参数集</param>
        /// <returns>返回用户组信息的分页列表</returns>
        [OperationContract]
        PageResult<UserGroupExport> GetGroups(GetUserGroupsImport import);

        #endregion

        #region 操作

        /// <summary>
        /// 创建新的顶级用户
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateUser(CreateUserImport import);

        /// <summary>
        /// 修改用户资料
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditUser(EditUserImport import);

        /// <summary>
        /// 修改额外的直属高点号配额
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult SetExtraQuotas(SetExtraQuotasImport import);

        /// <summary>
        /// 强制移除用户
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult RemoveUser(RemoveUserImport import);

        /// <summary>
        /// 创建新的用户组
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateUserGroup(CreateUserGroupImport import);

        /// <summary>
        /// 修改用户组资料
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditUserGroup(EditUserGroupImport import);

        /// <summary>
        /// 移除用户组
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult RemoveUserGroup(RemoveGroupImport import);

        #endregion
    }
}
