using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 返点记录的管理者对象
    /// </summary>
    public class RebateRecordManager : ManagerBase<IModelToDbContextOfAuthor, RebateRecordManager.Actions, RebateRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的返点记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public RebateRecordManager(IModelToDbContextOfAuthor db)
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
            /// 创建新的返点记录
            /// </summary>
            Create,
            /// <summary>
            /// 修改返点记录
            /// </summary>
            Update,
            /// <summary>
            /// 移除返点记录
            /// </summary>
            Remove
        }

        #endregion

        #endregion
    }
}
