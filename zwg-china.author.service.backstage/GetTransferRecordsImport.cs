using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用于获取转账记录的参数集
    /// </summary>
    [DataContract]
    public class GetTransferRecordsImport : GetSettingImport
    {
        #region 属性

        /// <summary>
        /// 起始时间
        /// </summary>
        [DataMember]
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 终止时间
        /// </summary>
        [DataMember]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public TransferStatus? Status { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        [DataMember]
        public int PageIndex { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取转账记录
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回转账记录</returns>
        public PageResult<TransferRecordExport> GetTransferRecords(IModelToDbContextOfAuthor db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            Expression<Func<TransferRecord, bool>> predicate1 = x => x.Id > 0;
            Expression<Func<TransferRecord, bool>> predicate2 = x => x.Id > 0;
            Expression<Func<TransferRecord, bool>> predicate3 = x => x.Id > 0;

            if (this.BeginTime != null)
            {
                DateTime beginTime = (DateTime)this.BeginTime;
                predicate1 = x => x.CreatedTime >= beginTime;
            }
            if (this.EndTime != null)
            {
                DateTime endtime = (DateTime)this.EndTime;
                predicate2 = x => x.CreatedTime <= endtime;
            }
            if (this.Status != null)
            {
                TransferStatus status = (TransferStatus)this.Status;
                predicate3 = x => x.Status == status;
            }

            int countOfAllMessages = db.TransferRecords
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Count();
            var tList = db.TransferRecords
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(x => new TransferRecordExport(x));

            return new PageResult<TransferRecordExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
