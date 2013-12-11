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
    /// 用于获取投注信息的数据集
    /// </summary>
    [DataContract]
    public class GetBettingsImport : GetPageListImportBaseOfLottery
    {
        #region 属性

        /// <summary>
        /// 关键字
        /// </summary>
        [DataMember]
        public string KeywordForUsername { get; set; }

        /// <summary>
        /// 用户的存储指针
        /// </summary>
        [DataMember]
        public int? OwnerId { get; set; }

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
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            Expression<Func<Betting, bool>> predicate1 = x => x.Id > 0;
            Expression<Func<Betting, bool>> predicate2 = x => x.Id > 0;
            Expression<Func<Betting, bool>> predicate3 = x => x.Id > 0;
            Expression<Func<Betting, bool>> predicate4 = x => x.Id > 0;
            Expression<Func<Betting, bool>> predicate5 = x => x.Id > 0;

            if (this.KeywordForUsername != null)
            {
                this.KeywordForUsername = VerifyHelper.EliminateSpaces(this.KeywordForUsername);
                string[] keywords = this.KeywordForUsername.Split(new char[] { ' ' });
                predicate1 = x => keywords.All(kw => x.Owner.Username.Contains(kw));
            }
            if (this.OwnerId != null)
            {
                int ownerId = (int)this.OwnerId;
                predicate2 = x => x.Owner.Id == ownerId;
            }
            if (this.BeginTime != null)
            {
                DateTime beginTime = (DateTime)this.BeginTime;
                predicate3 = x => x.CreatedTime >= beginTime;
            }
            if (this.EndTime != null)
            {
                DateTime endTime = (DateTime)this.EndTime;
                predicate4 = x => x.CreatedTime < endTime;
            }
            if (this.Status != null)
            {
                BettingStatus status = (BettingStatus)this.Status;
                predicate5 = x => x.Status == status;
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
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(x => new BettingExport(x));

            return new PageResult<BettingExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
