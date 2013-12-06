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
        /// 获取用户组信息的分页列表
        /// </summary>
        /// <param name="import">参数集</param>
        /// <returns>返回用户组信息的分页列表</returns>
        [OperationContract]
        PageResult<UserGroupExport> GetGroups(GetUserGroupsImport import);

        #endregion

        #region 操作



        #endregion
    }
}
