using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 彩票相关的数据服务
    /// </summary>
    public class LotteryService : ServiceBase, ILotteryService
    {
        #region 获取数据

        /// <summary>
        /// 获取彩票信息的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回彩票信息的分页列表</returns>
        public PageResult<LotteryTicketExport> GetLotteryTickets(GetLotteryTicketsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetLotteryTickets(db);
            }
            catch (Exception ex)
            {
                return new PageResult<LotteryTicketExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取开奖记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回开奖记录的分页列表</returns>
        public PageResult<LotteryExport> GetLotteries(GetLotteriesImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetLotteries(db);
            }
            catch (Exception ex)
            {
                return new PageResult<LotteryExport>(ex.Message);
            }
        }

        /// <summary>
        /// 获取虚拟排行的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回虚拟排行的分页列表</returns>
        public PageResult<VirtualBonusExport> GetVirtualBonus(GetVirtualBonusImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetVirtualBonus(db);
            }
            catch (Exception ex)
            {
                return new PageResult<VirtualBonusExport>(ex.Message);
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

        #region 设置

        /// <summary>
        /// 获取彩票模块的系统设置
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回彩票模块的系统设置</returns>
        public NormalResult<SettingOfLotteryExport> GetSettingOfLottery(GetSettingOfLotteryImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetSettingOfLottery(db);
            }
            catch (Exception ex)
            {
                return new NormalResult<SettingOfLotteryExport>(null, ex.Message);
            }
        }

        /// <summary>
        /// 设置彩票模块的系统设置
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult SetSettingOfLottery(SetSettingOfLotteryImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                import.SetAndSave(db);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        #endregion

        #region 操作

        /// <summary>
        /// 修改彩票信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditLotteryTicket(EditLotteryTicketImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new LotteryTicketManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 创建新的虚拟排行
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult CreateVirtualBonus(CreateVirtualBonusImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new VirtualBonusManager(db).Create(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改虚拟排行
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditVirtualBonus(EditVirtualBonusImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new VirtualBonusManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 移除虚拟排行
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult RemoveVirtualBonus(RemoveVirtualBonusImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new VirtualBonusManager(db).Remove(import);
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
