using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 定义交互消息模块的数据库连接对象
    /// </summary>
    public interface IModelToDbContextOfMessage
    {
        /// <summary>
        /// 公告的数据存储区
        /// </summary>
        DbSet<Bulletin> Bulletins { get; set; }

        /// <summary>
        /// 通知的数据存储区
        /// </summary>
        DbSet<Notice> Notices { get; set; }
    }
}
