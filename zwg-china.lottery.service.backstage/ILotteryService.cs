using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 定义彩票相关的数据服务
    /// </summary>
    [ServiceContract]
    public interface ILotteryService
    {
        #region 获取数据

        /// <summary>
        /// 获取彩票信息的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回彩票信息的分页列表</returns>
        [OperationContract]
        PageResult<LotteryTicketExport> GetLotteryTickets(GetLotteryTicketsImport import);

        /// <summary>
        /// 获取开奖记录的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回开奖记录的分页列表</returns>
        [OperationContract]
        PageResult<LotteryExport> GetLotteries(GetLotteriesImport import);

        /// <summary>
        /// 获取虚拟排行的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回虚拟排行的分页列表</returns>
        [OperationContract]
        PageResult<VirtualBonusExport> GetVirtualBonus(GetVirtualBonusImport import);

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

        /// <summary>
        /// 获取基础的彩票信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回基础的彩票信息</returns>
        [OperationContract]
        NormalResult<List<BasicLotteryTicketExport>> GetBasicLotteryTickets(GetBasicLotteryTicketsImport import);

        #endregion

        #region 获取设置

        /// <summary>
        /// 获取彩票模块的系统设置
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回彩票模块的系统设置</returns>
        [OperationContract]
        NormalResult<SettingOfLotteryExport> GetSettingOfLottery(GetSettingOfLotteryImport import);

        /// <summary>
        /// 设置彩票模块的系统设置
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult SetSettingOfLottery(SetSettingOfLotteryImport import);

        #endregion

        #region 操作

        /// <summary>
        /// 手动添加开奖记录
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateLottery(CreateLotteryImport import);

        /// <summary>
        /// 修改彩票信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditLotteryTicket(EditLotteryTicketImport import);

        /// <summary>
        /// 创建新的虚拟排行
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateVirtualBonus(CreateVirtualBonusImport import);

        /// <summary>
        /// 修改虚拟排行
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditVirtualBonus(EditVirtualBonusImport import);

        /// <summary>
        /// 移除虚拟排行
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult RemoveVirtualBonus(RemoveVirtualBonusImport import);

        #endregion
    }
}
