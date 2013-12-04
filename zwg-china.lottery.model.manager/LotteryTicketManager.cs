using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 彩票的管理者对象
    /// </summary>
    [RegisterToManagerService]
    public class LotteryTicketManager : ManagerBase<IModelToDbContextOfLottery, LotteryTicketManager.Actions, LotteryTicket>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的彩票的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public LotteryTicketManager(IModelToDbContextOfLottery db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        /// <summary>
        /// 更新开奖时间和期号
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(LotteryManager), LotteryManager.Actions.Create, ExecutionOrder.After)]
        public static void UpdateLotteryIssue(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfLottery db = (IModelToDbContextOfLottery)info.Db;
            Lottery model = (Lottery)info.Model;
            if (model.Sources == LotterySources.手动) { return; }

            LotteryTicket ticket = db.LotteryTickets.Find(model.Ticket.Id);
            ticket.Issue = model.Issue;
            ticket.NextIssue = model.GetNextIssue();
            ticket.LotteryValues = string.Join(",", model.Seats.ConvertAll(x => x.Value));
        }

        #endregion

        #region 内嵌元素

        #region 枚举

        /// <summary>
        /// 方法
        /// </summary>
        public enum Actions
        {
            /// <summary>
            /// 创建一个新的实体
            /// </summary>
            Create,
            /// <summary>
            /// 修改实体数据
            /// </summary>
            Update,
            /// <summary>
            /// 移除实体
            /// </summary>
            Remove
        }

        #endregion

        #endregion
    }
}
