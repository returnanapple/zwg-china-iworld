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
    /// 用户信息服务
    /// </summary>
    public class AuthorService : ServiceBase, IAuthorService
    {
        #region 获取数据

        /// <summary>
        /// 获取下级用户的用户信息的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回下级用户的用户信息的分页列表</returns>
        public PageResult<BasicAuthorExport> GetUsers(GetUsersImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetUsers(db);
            }
            catch (Exception ex)
            {
                return new PageResult<BasicAuthorExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取自身的详细用户信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回自身的详细用户信息</returns>
        public NormalResult<AuthorExport> GetUserInfo(GetUserInfoImpoert import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetSelf(db);
            }
            catch (Exception ex)
            {
                return new NormalResult<AuthorExport>(null, ex.Message);
            }
        }

        /// <summary>
        /// 获取基本的自身数据信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回基本的自身数据信息</returns>
        public NormalResult<BasicSelfInfoExport> GetBasicSelfInfo(GetBasicSelfInfoImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetBasicSelfInfo();
            }
            catch (Exception ex)
            {
                return new NormalResult<BasicSelfInfoExport>(null, ex.Message);
            }
        }

        #endregion

        #region 操作

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果（如成功将返回档次登陆的身份标识）</returns>
        public NormalResult<string> Login(LoginImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                Author user = new AuthorManager(db).Login(import);
                string token = AuthorLoginInfoPond.AddInfo(db, user.Id);
                return new NormalResult<string>(token);
            }
            catch (Exception ex)
            {
                return new NormalResult<string>(null, ex.Message);
            }
        }

        /// <summary>
        /// 信息绑定
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult BindingUserInfo(BindingUserInfoImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AuthorManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 创建下级用户
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult CreateUser(CreateUserImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AuthorManager(db).Create(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 升点
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult UpgradePorn(UpgradePornImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AuthorManager(db).ChangeRebate(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改银行卡信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditBank(EditBankImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AuthorManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改登陆密码
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditPassword(EditPasswordImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AuthorManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改资金密码
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditFundsCode(EditFundsCodeImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AuthorManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 使用安全码修改登陆密码
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditPasswordWithSafeCode(EditPasswordWithSafeCodeImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AuthorManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 使用安全码修改资金密码
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditFundsCodeWithSafeCode(EditFundsCodeWithSafeCodeImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new AuthorManager(db).Update(import);
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
                AuthorLoginInfoPond.KeepHeartbeat(db, token);
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
