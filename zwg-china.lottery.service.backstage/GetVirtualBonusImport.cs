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
    /// 用于获取虚拟排行信息的数据集
    /// </summary>
    [DataContract]
    public class GetVirtualBonusImport : GetPageListImportBaseOfLottery
    {
        #region 属性

        /// <summary>
        /// 关键字
        /// </summary>
        [DataMember]
        public string KeywordForTicketName { get; set; }

        /// <summary>
        /// 所从属的彩票的存储指针
        /// </summary>
        [DataMember]
        public int? TicketId { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取虚拟排行信息
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回虚拟排行信息</returns>
        public PageResult<VirtualBonusExport> GetBettings(IModelToDbContextOfLottery db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            Expression<Func<VirtualBonus, bool>> predicate1 = x => x.Id > 0;
            Expression<Func<VirtualBonus, bool>> predicate2 = x => x.Id > 0;

            if (this.KeywordForTicketName != null)
            {
                this.KeywordForTicketName = VerifyHelper.EliminateSpaces(this.KeywordForTicketName);
                string[] keywords = this.KeywordForTicketName.Split(new char[] { ' ' });
                predicate1 = x => keywords.All(kw => x.Ticket.Name.Contains(kw));
            }
            if (this.TicketId != null)
            {
                int ticketId = (int)this.TicketId;
                predicate2 = x => x.Ticket.Id == ticketId;
            }

            int countOfAllMessages = db.VirtualBonuss
                .Where(predicate1)
                .Where(predicate2)
                .Count();
            var tList = db.VirtualBonuss
                .Where(predicate1)
                .Where(predicate2)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(x => new VirtualBonusExport(x));

            return new PageResult<VirtualBonusExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
