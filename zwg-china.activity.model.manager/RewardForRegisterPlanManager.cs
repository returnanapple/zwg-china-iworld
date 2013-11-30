using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 注册奖励的管理者对象
    /// </summary>
    public class RewardForRegisterPlanManager : ManagerBase<IModelToDbContextOfActivity, RewardForRegisterPlanManager.Actions, RewardForRegisterPlan>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的注册奖励的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public RewardForRegisterPlanManager(IModelToDbContextOfActivity db)
            : base(db)
        {

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
            Remove
        }

        #endregion

        #endregion
    }
}
