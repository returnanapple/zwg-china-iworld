﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.logic;
using zwg_china.model;

namespace zwg_china.service.client
{
    /// <summary>
    /// 用户模块的用于获取分页列表的参数集的基类
    /// </summary>
    [DataContract]
    public abstract class GetPageListImportOfAuthor : GetPageListImportBase
    {
        /// <summary>
        /// 自身的存储指针
        /// </summary>
        public Author Self { get; set; }

        /// <summary>
        /// 判定当前用户是否允许执行操作
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回一个布尔值，表示当前用户是否允许执行操作</returns>
        public override void CheckAllowExecuteOrNot(ModelToDbContext db)
        {
            this.Self = AuthorLoginInfoPond.GetUserInfo(db, this.Token);
        }
    }
}
