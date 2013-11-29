using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 定义彩票模块的数据库连接对象
    /// </summary>
    public interface IModelToDbContextOfLottery : IModelToDbContextOfAuthor
    {
        /// <summary>
        /// 彩票的数据存储区
        /// </summary>
        DbSet<LotteryTicket> LotteryTickets { get; set; }

        /// <summary>
        /// 玩法标签的数据存储区
        /// </summary>
        DbSet<PlayTag> PlayTags { get; set; }

        /// <summary>
        /// 玩法的数据存储区
        /// </summary>
        DbSet<HowToPlay> HowToPlays { get; set; }

        /// <summary>
        /// 开奖记录的数据存储区
        /// </summary>
        DbSet<Lottery> Lotterys { get; set; }

        /// <summary>
        /// 投注的数据存储区
        /// </summary>
        DbSet<Betting> Bettings { get; set; }

        /// <summary>
        /// 追号的数据存储区
        /// </summary>
        DbSet<Chasing> Chasings { get; set; }

        /// <summary>
        /// 投注（追号）的数据存储区
        /// </summary>
        DbSet<BettingWithChasing> BettingWithChasings { get; set; }

        /// <summary>
        /// 虚拟排行的数据存储区
        /// </summary>
        DbSet<VirtualBonus> VirtualBonuss { get; set; }
    }
}
