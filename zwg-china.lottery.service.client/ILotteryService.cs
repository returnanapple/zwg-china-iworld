using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace zwg_china.service
{
    /// <summary>
    /// 定义彩票相关的数据服务
    /// </summary>
    [ServiceContract]
    public interface ILotteryService
    {
        #region 获取数据

        /// <summary>
        /// 获取彩票信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回彩票信息</returns>
        [OperationContract]
        NormalResult<List<LotteryTicketExport>> GetTickets(GetTicketsImport import);

        /// <summary>
        /// 获取开奖记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回开奖记录</returns>
        [OperationContract]
        NormalResult<List<LotteryExport>> GetLotteries(GetLotteriesImport import);

        /// <summary>
        /// 获取投注记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回投注记录的分页列表</returns>
        [OperationContract]
        PageResult<BettingExport> GetBettings(GetBettingsImport import);

        /// <summary>
        /// 获取追号记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回追号记录的分页列表</returns>
        [OperationContract]
        PageResult<ChasingExport> GetChasings(GetChasingsImport import);

        #endregion

        #region 操作

        /// <summary>
        /// 投注
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult Bet(BetImpoert import);

        /// <summary>
        /// 撤单
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult RecallBetting(RecallBettingImport import);

        /// <summary>
        /// 撤单
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult RecallChasing(RecallChassingImport import);

        #endregion
    }
}
