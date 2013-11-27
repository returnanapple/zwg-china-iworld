using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 用户的登录记录的管理者对象
    /// </summary>
    [RegisterToManagerService]
    public class AuthorLandingRecordManager : ManagerBase<IModelToDbContextOfAuthor, AuthorLandingRecordManager.Actions, AuthorLandingRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户的登录记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public AuthorLandingRecordManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        /// <summary>
        /// 监控：生成登陆记录
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(AuthorManager), AuthorManager.Actions.Login, ExecutionOrder.After)]
        public static void Monitor_Create(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            Author model = (Author)info.Model;
            AuthorLandingRecordManager manager = new AuthorLandingRecordManager(db);

            AuthorLandingRecord landingRecord = new AuthorLandingRecord(model, model.LastLoginIp, model.LastLoginAddress);
            db.AuthorLandingRecords.Add(landingRecord);
        }

        #endregion

        #region 内嵌元素

        #region 枚举

        /// <summary>
        /// 动作
        /// </summary>
        public enum Actions
        {
            /// <summary>
            /// 创建新的用户的登录记录
            /// </summary>
            Create,
            /// <summary>
            /// 修改用户的登录记录
            /// </summary>
            Update,
            /// <summary>
            /// 移除用户的登录记录
            /// </summary>
            Remove
        }

        #endregion

        #endregion
    }
}
