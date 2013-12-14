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
    /// 用于获取追号信息的数据集
    /// </summary>
    [DataContract]
    public class GetChasingsImport : GetPageListImportBaseOfLottery
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

        #endregion

        #region 方法

        /// <summary>
        /// 获取追号信息
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回追号信息</returns>
        public PageResult<ChasingExport> GetChasings(IModelToDbContextOfLottery db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            Expression<Func<Chasing, bool>> predicate1 = x => x.Id > 0;
            Expression<Func<Chasing, bool>> predicate2 = x => x.Id > 0;
            Expression<Func<Chasing, bool>> predicate3 = x => x.Id > 0;
            Expression<Func<Chasing, bool>> predicate4 = x => x.Id > 0;

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

            int countOfAllMessages = db.Chasings
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Where(predicate4)
                .Count();
            var tList = db.Chasings
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Where(predicate4)
                .OrderByDescending(x => x.CreatedTime)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(x =>
                {
                    List<BettingWithChasing> bettings = db.BettingWithChasings.Where(b => b.Chasing.Id == x.Id).ToList();
                    return new ChasingExport(x, bettings);
                });

            return new PageResult<ChasingExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
