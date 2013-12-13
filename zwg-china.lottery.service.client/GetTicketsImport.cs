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

namespace zwg_china.service
{
    /// <summary>
    /// 用于获取彩票信息的数据集
    /// </summary>
    [DataContract]
    public class GetTicketsImport : ImportBaseOfLottery
    {
        #region 方法

        /// <summary>
        /// 获取彩票信息
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回彩票信息</returns>
        public NormalResult<List<LotteryTicketExport>> GetTickets(IModelToDbContextOfLottery db)
        {
            List<LotteryTicketExport> tList = db.LotteryTickets.Where(x => x.Hide == false).ToList().ConvertAll(x => new LotteryTicketExport(x));
            return new NormalResult<List<LotteryTicketExport>>(tList);
        }

        #endregion
    }
}
