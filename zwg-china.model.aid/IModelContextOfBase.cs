using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    public interface IModelContextOfBase
    {
        /// <summary>
        /// 父祖节点信息的存储区
        /// </summary>
        DbSet<Relative> Relatives { get; set; }

        /// <summary>
        /// 相关设定的明细项目的存储区
        /// </summary>
        DbSet<SettingDetail> SettingDetails { get; set; }

        /// <summary>
        /// 网络地址 - 实际地址的对照的存储区
        /// </summary>
        DbSet<IpToAddressComparison> IpToAddressComparisons { get; set; }
    }
}
