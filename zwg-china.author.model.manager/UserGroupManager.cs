using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 用户组的管理者对象
    /// </summary>
    public class UserGroupManager : ManagerBase<IModelToDbContextOfAuthor, UserGroupManager.Actions, UserGroup>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户组的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public UserGroupManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

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
            /// 创建新的用户组
            /// </summary>
            Create,
            /// <summary>
            /// 修改用户组
            /// </summary>
            Update,
            /// <summary>
            /// 移除用户组
            /// </summary>
            Remove
        }

        #endregion

        #endregion
    }
}
