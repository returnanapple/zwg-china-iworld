using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;
using zwg_china.logic;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于创建开奖记录的数据集
    /// </summary>
    [DataContract]
    public class CreateLotteryImport : ImportBaseOfLottery, IPackageForCreateModel<IModelToDbContextOfLottery, Lottery>
    {
        #region 私有字段

        LotteryTicket ticket = null;

        #endregion

        #region 属性

        /// <summary>
        /// 期号
        /// </summary>
        [DataMember]
        public string Issue { get; set; }

        /// <summary>
        /// 彩种
        /// </summary>
        [DataMember]
        public int TicketId { get; set; }

        /// <summary>
        /// 开奖号码
        /// </summary>
        [DataMember]
        public string Values { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfLottery db)
        {
            if (db.Lotterys.Any(x => x.Issue == this.Issue && x.Ticket.Id == this.TicketId))
            {
                throw new Exception("请勿重复添加开奖记录");
            }
            ticket = db.LotteryTickets.Find(this.TicketId);
            int c1 = ticket.Seats.Split(",".ToArray()).Count();
            int c2 = this.Values.Split(",".ToArray()).Count();
            if (c1 != c2)
            {
                throw new Exception("输入的开奖号码位数跟预设不一致");
            }
        }

        /// <summary>
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public Lottery GetModel(IModelToDbContextOfLottery db)
        {
            Administrator self = AdministratorLoginInfoPond.GetAdministratorInfo(db as IModelToDbContextOfAdministrator, this.Token);

            List<LotterySeat> ss = new List<LotterySeat>();
            string[] sNames = ticket.Seats.Split(",".ToArray());
            string[] values = this.Values.Split(",".ToArray());
            for (int i = 0; i < sNames.Count(); i++)
            {
                ss.Add(new LotterySeat(sNames[i], values[i]));
            }

            return new Lottery(this.Issue, LotterySources.手动, self, ticket, ss);
        }

        #endregion
    }
}
