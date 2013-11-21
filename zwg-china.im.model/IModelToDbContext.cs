using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 定义IM模块的数据存储区
    /// </summary>
    public interface IModelToDbContext
    {
        /// <summary>
        /// 聊天信息（IM）的数据存储区
        /// </summary>
        DbSet<ImMessage> ImMessages { get; set; }

        /// <summary>
        /// 快捷回复（IM）的数据存储区
        /// </summary>
        DbSet<ImQuickReply> ImQuickReplys { get; set; }
    }
}
