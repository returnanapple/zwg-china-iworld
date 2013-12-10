using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用于获取佣金记录的数据集
    /// </summary>
    [DataContract]
    public class GetCommissionRecordsImport : GetPageListImportOfAuthor
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
        /// 获取佣金记录
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回佣金记录</returns>
        public PageResult<CommissionRecordExport> GetCommissionRecords(IModelToDbContextOfAuthor db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            Expression<Func<CommissionRecord, bool>> predicate1 = x => x.Id == this.Self.Id;
            Expression<Func<CommissionRecord, bool>> predicate2 = x => x.Id > 0;
            Expression<Func<CommissionRecord, bool>> predicate3 = x => x.Id > 0;
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

            int countOfAllMessages = db.CommissionRecords
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Count();
            var tList = db.CommissionRecords
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(x => new CommissionRecordExport(x));

            return new PageResult<CommissionRecordExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
