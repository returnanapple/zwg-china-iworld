using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.aid;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 管理员的管理者对象
    /// </summary>
    public class AdministratorManager : ManagerBase<IModelToDbContextOfAdministrator, AdministratorManager.Actions, Administrator>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的管理员的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public AdministratorManager(IModelToDbContextOfAdministrator db)
            : base(db)
        {

        }

        #endregion

        #region 方法

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="package">数据集</param>
        public Administrator Login(IPackageForLogin package)
        {
            string username = VerifyHelper.EliminateSpaces(package.Username);
            string password = VerifyHelper.EliminateSpaces(package.Password);
            VerifyHelper.Check(username, VerifyHelper.Key.Nickname);
            VerifyHelper.Check(password, VerifyHelper.Key.Password);
            password = EncryptHelper.EncryptByMd5(password);
            Administrator user = db.Administrators.FirstOrDefault(x => x.Username == package.Username && x.Password == password);
            if (user == null)
            {
                throw new Exception("用户名或密码错误，请重新输入");
            }

            OnExecuting(Actions.Login, user);
            user.OnLogin(package.Ip, package.Address);
            OnExecuted(Actions.Login, user);
            db.SaveChanges();

            return user;
        }

        #endregion

        #region 内嵌元素

        #region 枚举

        /// <summary>
        /// 方法
        /// </summary>
        public enum Actions
        {
            /// <summary>
            /// 创建一个新的实体
            /// </summary>
            Create,
            /// <summary>
            /// 修改实体数据
            /// </summary>
            Update,
            /// <summary>
            /// 移除实体
            /// </summary>
            Remove,
            /// <summary>
            /// 登陆
            /// </summary>
            Login
        }

        #endregion

        #region 接口

        /// <summary>
        /// 定义用于登陆的数据集
        /// </summary>
        public interface IPackageForLogin
        {
            /// <summary>
            /// 用户名
            /// </summary>
            string Username { get; }

            /// <summary>
            /// 密码
            /// </summary>
            string Password { get; }

            /// <summary>
            /// 网络地址
            /// </summary>
            string Ip { get; }

            /// <summary>
            /// 实际地址
            /// </summary>
            string Address { get; }
        }

        #endregion

        #endregion
    }
}
