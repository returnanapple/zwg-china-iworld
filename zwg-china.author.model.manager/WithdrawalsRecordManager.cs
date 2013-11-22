using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    public class WithdrawalsRecordManager : ManagerBase<IModelToDbContextOfAuthor, WithdrawalsRecordManager.Actions, WithdrawalsRecord>
    {
        #region 构造方法

        public WithdrawalsRecordManager(IModelToDbContextOfAuthor db)
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
            Remove
        }

        #endregion

        #endregion
    }
}
