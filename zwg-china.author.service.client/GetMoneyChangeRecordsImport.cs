using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.client
{
    /// <summary>
    /// 用于获取帐变记录的数据集
    /// </summary>
    [DataContract]
    public class GetMoneyChangeRecordsImport : GetPageListImportOfAuthor
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

        #region 构造方法

        /// <summary>
        /// 获取帐变记录
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回帐变记录</returns>
        public PageResult<MoneyChangeRecordExport> GetMoneyChangeRecords(IModelToDbContextOfAuthor db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForClient * (this.PageIndex - 1);

            Expression<Func<MoneyChangeRecord, bool>> predicate1 = x => x.Id == this.Self.Id;
            Expression<Func<MoneyChangeRecord, bool>> predicate2 = x => x.Id > 0;
            Expression<Func<MoneyChangeRecord, bool>> predicate3 = x => x.Id > 0;
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

            int countOfAllMessages = db.MoneyChangeRecords
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Count();
            var tList = db.MoneyChangeRecords
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .OrderByDescending(x => x.CreatedTime)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForClient)
                .ToList()
                .ConvertAll(x => new MoneyChangeRecordExport(x));

            return new PageResult<MoneyChangeRecordExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForClient, tList);
        }

        #endregion
    }
}
