﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 图片的管理者对象
    /// </summary>
    public class PictureManager : ManagerBase<IModelToDbContextOfBase, PictureManager.Actions, Picture>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的图片的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public PictureManager(IModelToDbContextOfBase db)
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
