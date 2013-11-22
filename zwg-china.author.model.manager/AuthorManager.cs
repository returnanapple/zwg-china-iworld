using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using zwg_china.aid;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 用户的管理者对象
    /// </summary>
    public class AuthorManager : ManagerBase<IModelToDbContextOfAuthor, AuthorManager.Actions, Author>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public AuthorManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

        }

        #endregion

        #region 方法

        /// <summary>
        /// 用户登人
        /// </summary>
        /// <param name="package">用于登陆的数据集</param>
        /// <returns>返回用户的实例</returns>
        public Author Login(PackageForLogin package)
        {
            string password = EncryptHelper.EncryptByMd5(package.Password);
            Author user = db.Authors.FirstOrDefault(x => x.Username == package.Username && x.Password == password);
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

        /// <summary>
        /// 移除用户
        /// </summary>
        /// <param name="id">所要移除的用户的存储指针</param>
        public override void Remove(int id)
        {
            Author user = db.Authors.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("存储指针指向的用户不存在，请检查输入");
            }

            OnExecuting(Actions.Remove, user);
            user.Status = UserStatus.删除;
            OnExecuted(Actions.Remove, user);
            db.SaveChanges();
        }

        #endregion

        #region 静态方法

        public static void ChangeMoney()
        {

        }

        #endregion

        #region 内嵌枚举

        /// <summary>
        /// 动作
        /// </summary>
        public enum Actions
        {
            /// <summary>
            /// 创建新用户
            /// </summary>
            Create,
            /// <summary>
            /// 修改用户信息
            /// </summary>
            Update,
            /// <summary>
            /// 移除用户
            /// </summary>
            Remove,
            /// <summary>
            /// 用户登录
            /// </summary>
            Login
        }

        #endregion

        #region 内嵌类型

        /// <summary>
        /// 定于用于登陆的数据集
        /// </summary>
        public interface PackageForLogin
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

        /// <summary>
        /// 用于向改变目标用户的余额的方法传递数据的数据集
        /// </summary>
        public class ChangeMoneyArgs
        {
            /// <summary>
            /// 目标用户的存储指针
            /// </summary>
            public int UserId { get; set; }

            /// <summary>
            /// 所要改变的数额
            /// </summary>
            public double Sum { get; set; }
        }

        #endregion
    }
}
