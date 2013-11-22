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
            if (user.Status == UserStatus.禁止访问)
            {
                throw new Exception("黑名单，你懂的。");
            }

            OnExecuting(Actions.Login, user);
            user.OnLogin(package.Ip, package.Address);
            OnExecuted(Actions.Login, user);
            db.SaveChanges();

            return user;
        }

        #endregion

        #region 静态方法

        #region 服务

        /// <summary>
        /// 服务：修改用户的账户余额
        /// </summary>
        /// <param name="info">数据集</param>
        public static void Service_ChangeMoney(InfoOfCallOnManagerService<IModelToDbContextOfAuthor, AuthorManager.Actions, Author, ChangeMoneyArgs> info)
        {
            Author user = info.Db.Authors.FirstOrDefault(x => x.Id == info.Args.UserId);
            if (user == null)
            {
                throw new Exception("给定的存储指针指向的用户不存在");
            }

            user.Money += info.Args.Sum;
        }

        #endregion

        #region 监听

        /// <summary>
        /// 监听：（直属）下级用户数量改变
        /// </summary>
        /// <param name="info">数据集</param>
        public static void Monitor_AddSubordinate(InfoOfSendOnManagerService<IModelToDbContextOfAuthor, AuthorManager.Actions, Author> info)
        {
            if (info.Model.Layer <= 1) { return; }
            Author user = info.Db.Authors.FirstOrDefault(x => info.Model.Relatives.Any(r => r.NodeId == x.Id) && x.Layer == info.Model.Layer - 1);
            if (user == null)
            {
                string error = string.Format("致命错误，非顶级用户（用户名：{0}，层级：{1}）没有上级用户"
                    , info.Model.Username
                    , info.Model.Layer);
                throw new Exception(error);
            }

            user.Subordinate++;
        }

        /// <summary>
        /// 监听：（直属）下级用户（高点号）数量改变
        /// </summary>
        /// <param name="info">数据集</param>
        public static void Monitor_AddSubordinateOfHighRebate(InfoOfSendOnManagerService<IModelToDbContextOfAuthor, AuthorManager.Actions, Author> info)
        {
            if (info.Model.Layer <= 1) { return; }
            Author user = info.Db.Authors.FirstOrDefault(x => info.Model.Relatives.Any(r => r.NodeId == x.Id) && x.Layer == info.Model.Layer - 1);
            if (user == null)
            {
                string error = string.Format("致命错误，非顶级用户（用户名：{0}，层级：{1}）没有上级用户"
                    , info.Model.Username
                    , info.Model.Layer);
                throw new Exception(error);
            }

            SubordinateData sd = user.SubordinateOfHighRebate.FirstOrDefault(x => x.Rebate == info.Model.PlayInfo.Rebate_Normal);
            if (sd == null)
            {
                sd = new SubordinateData(info.Model.PlayInfo.Rebate_Normal, 1);
                user.SubordinateOfHighRebate.Add(sd);
            }
            else
            {
                sd.Sum++;
            }
        }

        public static void Monitor_FreezeMoney(InfoOfSendOnManagerService<IModelToDbContextOfAuthor, WithdrawalsRecordManager.Actions, WithdrawalsRecord> info)
        {

        }

        #endregion

        #endregion

        #region 内嵌元素

        #region 枚举

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

        #region 接口

        /// <summary>
        /// 定义用于登陆的数据集
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

        #endregion

        #region 类型

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

        #endregion
    }
}
