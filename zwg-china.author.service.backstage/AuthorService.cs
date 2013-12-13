using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用户模块的后台服务
    /// </summary>
    public class AuthorService : ServiceBase, IAuthorService
    {
        #region 数据

        /// <summary>
        /// 获取用户信息的分页列表
        /// </summary>
        /// <param name="import">参数集</param>
        /// <returns>返回用户信息的分页列表</returns>
        public PageResult<AuthorExport> GetUsers(GetUsersImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetUsers(db);
            }
            catch (Exception ex)
            {
                return new PageResult<AuthorExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取用户登录记录的分页列表
        /// </summary>
        /// <param name="import">参数集</param>
        /// <returns>返回用户登录记录的分页列表</returns>
        public PageResult<AuthorLandingRecordExport> GetLandingRecords(GetLandingRecordsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetLandingRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<AuthorLandingRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取基础的用户组信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回基础的用户组信息</returns>
        public NormalResult<List<BasicUserGroupExport>> GetBasicUserGroups(GetBasicUserGroupsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetBasicUserGroups(db);
            }
            catch (Exception ex)
            {
                return new NormalResult<List<BasicUserGroupExport>>(null, ex.Message);
            }
        }

        /// <summary>
        /// 获取用户组信息的分页列表
        /// </summary>
        /// <param name="import">参数集</param>
        /// <returns>返回用户组信息的分页列表</returns>
        public PageResult<UserGroupExport> GetGroups(GetUserGroupsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetUserGroups(db);
            }
            catch (Exception ex)
            {
                return new PageResult<UserGroupExport>(ex.Message);
            }
        }

        #endregion

        #region 操作

        /// <summary>
        /// 创建新的顶级用户
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult CreateUser(CreateUserImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                AuthorManager manager = new AuthorManager(db);
                manager.Create(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改用户资料
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditUser(EditUserImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                AuthorManager manager = new AuthorManager(db);
                manager.Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改额外的直属高点号配额
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult SetExtraQuotas(SetExtraQuotasImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                AuthorManager manager = new AuthorManager(db);
                manager.Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 强制移除用户
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult RemoveUser(RemoveUserImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                AuthorManager manager = new AuthorManager(db);
                manager.Remove(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 创建新的用户组
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult CreateUserGroup(CreateUserGroupImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                UserGroupManager manager = new UserGroupManager(db);
                manager.Create(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改用户组资料
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditUserGroup(EditUserGroupImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                UserGroupManager manager = new UserGroupManager(db);
                manager.Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 移除用户组
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult RemoveUserGroup(RemoveGroupImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                UserGroupManager manager = new UserGroupManager(db);
                manager.Remove(import);
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
