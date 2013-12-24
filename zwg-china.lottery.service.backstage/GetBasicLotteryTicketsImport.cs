using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.logic;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于获取基础的彩票信息的数据集
    /// </summary>
    [DataContract]
    public class GetBasicLotteryTicketsImport : ImportBaseOfLottery
    {
        #region 方法

        /// <summary>
        /// 获取基础的彩票信息
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回基础的彩票信息</returns>
        public NormalResult<List<BasicLotteryTicketExport>> GetBasicLotteryTickets(IModelToDbContextOfLottery db)
        {
            List<BasicLotteryTicketExport> tList = db.LotteryTickets.Where(x => x.Hide == false).OrderBy(x => x.Order).ToList()
                .ConvertAll(x => new BasicLotteryTicketExport(x));
            return new NormalResult<List<BasicLotteryTicketExport>>(tList);
        }

        #endregion
    }
}
