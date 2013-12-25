using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.client
{
    /// <summary>
    /// 用于获取投注信息的数据集
    /// </summary>
    [DataContract]
    public class GetBettingsImport : GetPageListImportBaseOfLottery
    {
        #region 属性

        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember]
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public BettingStatus? Status { get; set; }

        /// <summary>
        /// 彩票的存储指针
        /// </summary>
        [DataMember]
        public int? TicketId { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取投注信息
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回投注信息</returns>
        public PageResult<BettingExport> GetBettings(IModelToDbContextOfLottery db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForClient * (this.PageIndex - 1);

            Expression<Func<Betting, bool>> predicate1 = x => x.Owner.Id == this.Self.Id;
            Expression<Func<Betting, bool>> predicate2 = x => x.Id > 0;
            Expression<Func<Betting, bool>> predicate3 = x => x.Id > 0;
            Expression<Func<Betting, bool>> predicate4 = x => x.Id > 0;
            Expression<Func<Betting, bool>> predicate5 = x => x.Id > 0;

            if (this.BeginTime != null)
            {
                DateTime beginTime = (DateTime)this.BeginTime;
                predicate2 = x => x.CreatedTime >= beginTime;
            }
            if (this.EndTime != null)
            {
                DateTime endTime = (DateTime)this.EndTime;
                predicate3 = x => x.CreatedTime < endTime;
            }
            if (this.Status != null)
            {
                BettingStatus status = (BettingStatus)this.Status;
                predicate4 = x => x.Status == status;
            }
            if (this.TicketId != null)
            {
                int ticketId = (int)this.TicketId;
                predicate5 = x => x.HowToPlay.Tag.Ticket.Id == ticketId;
            }

            int countOfAllMessages = db.Bettings
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Where(predicate4)
                .Where(predicate5)
                .Count();
            var tList = db.Bettings
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Where(predicate4)
                .Where(predicate5)
                .OrderByDescending(x => x.CreatedTime)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForClient)
                .ToList()
                .ConvertAll(x => new BettingExport(x));

            return new PageResult<BettingExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForClient, tList);
        }

        #endregion
    }
}
