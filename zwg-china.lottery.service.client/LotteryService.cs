using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 彩票相关的数据服务
    /// </summary>
    public class LotteryService : ServiceBase, ILotteryService
    {
        #region 获取数据

        /// <summary>
        /// 获取彩票信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回彩票信息</returns>
        public NormalResult<List<LotteryTicketExport>> GetTickets(GetTicketsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetTickets(db);
            }
            catch (Exception ex)
            {
                return new NormalResult<List<LotteryTicketExport>>(null, ex.Message);
            }
        }

        /// <summary>
        /// 获取开奖记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回开奖记录</returns>
        public NormalResult<List<LotteryExport>> GetLotteries(GetLotteriesImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetLotteries(db);
            }
            catch (Exception ex)
            {
                return new NormalResult<List<LotteryExport>>(null, ex.Message);
            }
        }

        /// <summary>
        /// 获取投注记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回投注记录的分页列表</returns>
        public PageResult<BettingExport> GetBettings(GetBettingsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetBettings(db);
            }
            catch (Exception ex)
            {
                return new PageResult<BettingExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取追号记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回追号记录的分页列表</returns>
        public PageResult<ChasingExport> GetChasings(GetChasingsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetChasings(db);
            }
            catch (Exception ex)
            {
                return new PageResult<ChasingExport>(ex.Message);
            }
        }

        #endregion

        #region 操作

        /// <summary>
        /// 投注
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult Bet(BetImpoert import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                import.DoBet(db);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 撤单
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult RecallBetting(RecallBettingImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new BettingManager(db).Recall(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 撤单
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult RecallChasing(RecallChassingImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new ChasingManager(db).Recall(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        #endregion
    }
}
