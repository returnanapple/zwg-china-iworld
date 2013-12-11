﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    public class RemoveVirtualBonusImport : ImportBaseOfLottery, IPackageForRemove<IModelToDbContextOfLottery>
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        public int Id { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfLottery db)
        {
        }

        #endregion
    }
}
