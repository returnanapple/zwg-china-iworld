﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 网络地址 - 实际地址的对照的管理者对象
    /// </summary>
    public class IpToAddressComparisonManager : ManagerBase<IModelToDbContextOfBase, IpToAddressComparisonManager.Actions, IpToAddressComparison>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的网络地址 - 实际地址的对照的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public IpToAddressComparisonManager(IModelToDbContextOfBase db)
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
