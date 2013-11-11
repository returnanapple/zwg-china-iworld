using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 定义针对基础数据的数据库连接对象
    /// </summary>
    public interface IContextOfBase
    {
        /// <summary>
        /// 亲族节点的数据存储区
        /// </summary>
        DbSet<Relative> Relatives { get; set; }
    }
}
