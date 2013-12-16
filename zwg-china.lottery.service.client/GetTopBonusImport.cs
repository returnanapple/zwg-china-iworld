using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.aid;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.client
{
    /// <summary>
    /// 用于获取中奖排行的数据集
    /// </summary>
    [DataContract]
    public class GetTopBonusImport : GetPageListImportBaseOfLottery
    {
        #region 属性

        /// <summary>
        /// 目标彩票的存储指针
        /// </summary>
        [DataMember]
        public int? TicketId { get; set; }

        /// <summary>
        /// 所要获取的条数
        /// </summary>
        [DataMember]
        public int Notes { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public NormalResult<List<TopBonus>> GetTopBonus(IModelToDbContextOfLottery db)
        {
            if (this.TicketId == null)
            {
                List<TopBonus> t = new List<TopBonus>();
                List<TopBonus> t1 = db.VirtualBonuss
                    .OrderByDescending(x => x.Sum)
                    .Take(this.Notes)
                    .ToList()
                    .ConvertAll(x => new TopBonus(x));
                List<TopBonus> t2 = db.Bettings
                    .OrderByDescending(x => x.Bonus)
                    .Take(this.Notes)
                    .ToList()
                    .ConvertAll(x => new TopBonus(x));
                List<TopBonus> t3 = db.BettingWithChasings
                    .OrderByDescending(x => x.Bonus)
                    .Take(this.Notes)
                    .ToList()
                    .ConvertAll(x => new TopBonus(x));
                t.AddRange(t1);
                t.AddRange(t2);
                t.AddRange(t3);
                t = t.OrderByDescending(x => x.Sum).Take(this.Notes).ToList();
                return new NormalResult<List<TopBonus>>(t);
            }
            else
            {
                int ticketId = (int)this.TicketId;
                List<TopBonus> t = new List<TopBonus>();
                List<TopBonus> t1 = db.VirtualBonuss
                    .Where(x => x.Ticket.Id == ticketId)
                    .OrderByDescending(x => x.Sum)
                    .Take(this.Notes)
                    .ToList()
                    .ConvertAll(x => new TopBonus(x));
                List<TopBonus> t2 = db.Bettings
                    .Where(x => x.HowToPlay.Tag.Ticket.Id == ticketId)
                    .OrderByDescending(x => x.Bonus)
                    .Take(this.Notes)
                    .ToList()
                    .ConvertAll(x => new TopBonus(x));
                List<TopBonus> t3 = db.BettingWithChasings
                    .Where(x => x.Chasing.HowToPlay.Tag.Ticket.Id == ticketId)
                    .OrderByDescending(x => x.Bonus)
                    .Take(this.Notes)
                    .ToList()
                    .ConvertAll(x => new TopBonus(x));
                t.AddRange(t1);
                t.AddRange(t2);
                t.AddRange(t3);
                t = t.OrderByDescending(x => x.Sum).Take(this.Notes).ToList();
                return new NormalResult<List<TopBonus>>(t);
            }
        }

        #endregion
    }
}
