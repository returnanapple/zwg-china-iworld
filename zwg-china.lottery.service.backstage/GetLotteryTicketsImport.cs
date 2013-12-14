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

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于获取彩票信息的数据集
    /// </summary>
    [DataContract]
    public class GetLotteryTicketsImport : GetPageListImportBaseOfLottery
    {
        #region 属性

        /// <summary>
        /// 关键字
        /// </summary>
        [DataMember]
        public string KeywordOfName { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取彩票信息
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回彩票信息</returns>
        public PageResult<LotteryTicketExport> GetLotteryTickets(IModelToDbContextOfLottery db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            Expression<Func<LotteryTicket, bool>> predicate1 = x => x.Id > 0;

            if (this.KeywordOfName != null)
            {
                this.KeywordOfName = VerifyHelper.EliminateSpaces(this.KeywordOfName);
                string[] keywords = this.KeywordOfName.Split(new char[] { ' ' });
                predicate1 = x => keywords.All(kw => x.Name.Contains(kw));
            }

            int countOfAllMessages = db.LotteryTickets
                .Where(predicate1)
                .Count();
            var tList = db.LotteryTickets
                .Where(predicate1)
                .OrderBy(x => x.Order)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(x => new LotteryTicketExport(x));

            return new PageResult<LotteryTicketExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
