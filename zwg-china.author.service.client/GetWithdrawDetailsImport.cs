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
    /// 用于获取提现记录的数据集
    /// </summary>
    [DataContract]
    public class GetWithdrawDetailsImport : GetPageListImportOfAuthor
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
        public WithdrawalsStatus? Status { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取提现记录
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回提现记录</returns>
        public PageResult<WithdrawalsRecordExport> GetWithdrawDetails(IModelToDbContextOfAuthor db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForClient * (this.PageIndex - 1);

            Expression<Func<WithdrawalsRecord, bool>> predicate1 = x => x.Id == this.Self.Id;
            Expression<Func<WithdrawalsRecord, bool>> predicate2 = x => x.Id > 0;
            Expression<Func<WithdrawalsRecord, bool>> predicate3 = x => x.Id > 0;
            Expression<Func<WithdrawalsRecord, bool>> predicate4 = x => x.Id > 0;
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
                WithdrawalsStatus status = (WithdrawalsStatus)this.Status;
                predicate4 = x => x.Status == status;
            }

            int countOfAllMessages = db.WithdrawalsRecords
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Where(predicate4)
                .Count();
            var tList = db.WithdrawalsRecords
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Where(predicate4)
                .OrderByDescending(x => x.CreatedTime)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForClient)
                .ToList()
                .ConvertAll(x => new WithdrawalsRecordExport(x));

            return new PageResult<WithdrawalsRecordExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForClient, tList);
        }

        #endregion
    }
}
