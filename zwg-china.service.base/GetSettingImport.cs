﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.logic;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 用于获取系统设置的参数集
    /// </summary>
    [DataContract]
    public abstract class GetSettingImport : ImportBase
    {
        /// <summary>
        /// 判定当前用户是否允许执行操作
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public override void CheckAllowExecuteOrNot(ModelToDbContext db)
        {
            Administrator administrator = AdministratorLoginInfoPond.GetAdministratorInfo(db, this.Token);
            if (!administrator.Group.CanViewSettings)
            {
                throw new Exception("没有查看系统设置的权限");
            }
        }
    }
}
