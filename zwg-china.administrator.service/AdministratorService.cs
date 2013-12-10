using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.aid;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 管理员相关的数据服务
    /// </summary>
    public class AdministratorService : ServiceBase, IAdministratorService
    {
        #region 获取数据

        /// <summary>
        /// 获取管理员信息的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回管理员信息的分页列表</returns>
        public PageResult<BasicAdministratorExport> GetAdministrators(GetAdministratorsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetAdministrators(db);
            }
            catch (Exception ex)
            {
                return new PageResult<BasicAdministratorExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取管理员组的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回管理员组的分页列表</returns>
        public PageResult<AdministratorGroupExport> GetAdministratorGroups(GetAdministratorGroupsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetAdministratorGroups(db);
            }
            catch (Exception ex)
            {
                return new PageResult<AdministratorGroupExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取管理员登陆记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回管理员登陆记录的分页列表</returns>
        public PageResult<AdministratorLandingRecordExport> GetAdministratorLandingRecords(GetAdministratorLandingRecordsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetAdministratorLandingRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<AdministratorLandingRecordExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取操作记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作记录的分页列表</returns>
        public PageResult<OperateRecordExport> GetOperatedRecords(GetOperatedRecordsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetOperatedRecords(db);
            }
            catch (Exception ex)
            {
                return new PageResult<OperateRecordExport>(ex.Message);
            }
        }

        #endregion

        #region 操作

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult<AdministratorExport> Login(LoginImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                Administrator administrator = new AdministratorManager(db).Login(import);
                string token = AdministratorLoginInfoPond.AddInfo(db, administrator.Id);
                AdministratorExport ae = new AdministratorExport(administrator, token);
                return new NormalResult<AdministratorExport>(ae);
            }
            catch (Exception ex)
            {
                return new NormalResult<AdministratorExport>(null, ex.Message);
            }
        }

        /// <summary>
        /// 创建新的管理员
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult CreateAdministrator(CreateAdministratorImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AdministratorManager(db).Create(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditPassword(EditPasswordImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AdministratorManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 改变管理员组
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult ChangeGroup(ChangeGroupImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AdministratorManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 移除管理员
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult RemoveAdministrator(RemoveAdministratorImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AdministratorManager(db).Remove(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 创建新的管理员组
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult CreateAdministratorGroup(CreateAdministratorGroupImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AdministratorGroupManager(db).Create(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改管理员组
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditAdministratorGroup(EditAdministratorGroupImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AdministratorGroupManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 移除管理员组
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult RemoveAdministratorGroup(RemoveAdministratorGroupImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AdministratorGroupManager(db).Remove(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        #endregion

        #region 心跳协议

        /// <summary>
        /// 保持心跳
        /// </summary>
        /// <param name="token">身份标识</param>
        /// <returns>返回操作结果</returns>
        public NormalResult KeepHeartbeat(string token)
        {
            try
            {
                AdministratorLoginInfoPond.KeepHeartbeat(db, token);
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
