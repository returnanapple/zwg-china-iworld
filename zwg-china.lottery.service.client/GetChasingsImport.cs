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
            int startRow = settingOfBase.PageSizeForClient * (this.PageIndex - 1);

            Expression<Func<Chasing, bool>> predicate1 = x => x.Owner.Id == this.Self.Id;
            Expression<Func<Chasing, bool>> predicate2 = x => x.Id > 0;
            Expression<Func<Chasing, bool>> predicate3 = x => x.Id > 0;

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

            int countOfAllMessages = db.Chasings
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Count();
            var tList = db.Chasings
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .OrderByDescending(x => x.CreatedTime)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForClient)
                .ToList()
                .ConvertAll(x =>
                {
                    List<BettingWithChasing> bettings = db.BettingWithChasings.Where(b => b.Chasing.Id == x.Id).ToList();
                    return new ChasingExport(x, bettings);
                });

            return new PageResult<ChasingExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForClient, tList);
        }

        #endregion
    }
}
