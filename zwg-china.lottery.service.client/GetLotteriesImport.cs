using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.client
{
    /// <summary>
    /// 用于获取开奖记录的数据集
    /// </summary>
    [DataContract]
    public class GetLotteriesImport : ImportBaseOfLottery
    {
        #region 属性

        /// <summary>
        /// 目测彩票的存储桌子很
        /// </summary>
        [DataMember]
        public int TicketId { get; set; }

        /// <summary>
        /// 所要获取的条数
        /// </summary>
        [DataMember]
        public int Count { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取开奖记录
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回开奖记录</returns>
        public NormalResult<List<LotteryExport>> GetLotteries(IModelToDbContextOfLottery db)
        {
            List<LotteryExport> tList = db.Lotterys
                .Where(x => x.Ticket.Id == this.TicketId)
                .OrderByDescending(x => x.CreatedTime)
                .Take(this.Count)
                .ToList()
                .ConvertAll(x => new LotteryExport(x));
            return new NormalResult<List<LotteryExport>>(tList);
        }

        #endregion
    }
}
