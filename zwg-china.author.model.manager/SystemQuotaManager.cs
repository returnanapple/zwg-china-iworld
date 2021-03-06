﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 系统设定的高点号配额方案的管理者对象
    /// </summary>
    public class SystemQuotaManager : ManagerBase<IModelToDbContextOfAuthor, SystemQuotaManager.Actions, SystemQuota>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的系统设定的高点号配额方案的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public SystemQuotaManager(IModelToDbContextOfAuthor db)
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
            /// 创建新的系统设定的高点号配额方案
            /// </summary>
            Create,
            /// <summary>
            /// 修改系统设定的高点号配额方案
            /// </summary>
            Update,
            /// <summary>
            /// 移除系统设定的高点号配额方案
            /// </summary>
            Remove
        }

        #endregion

        #endregion
    }
}
