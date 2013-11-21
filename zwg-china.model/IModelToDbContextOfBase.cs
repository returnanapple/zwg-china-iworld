using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 定义基本的数据库连接对象
    /// </summary>
    public interface IModelToDbContextOfBase : IModelToDbContext
    {
        /// <summary>
        /// 网络 - 实际地址对照的数据存储区
        /// </summary>
        DbSet<IpToAddressComparison> IpToAddressComparisons { get; set; }

        /// <summary>
        /// 相关设定的明细的数据存储区
        /// </summary>
        DbSet<SettingDetail> SettingDetails { get; set; }

        /// <summary>
        /// 图片的数据存储区
        /// </summary>
        DbSet<Picture> Picture { get; set; }
    }
}
