using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.aid;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用于获取提现记录的参数集
    /// </summary>
    [DataContract]
    public class GetWithdrawalsRecordsImport : GetPageListImportOfAuthor
    {
        #region 属性

        /// <summary>
        /// 关键字（用户名）
        /// </summary>
        [DataMember]
        public string KeywordForUsername { get; set; }

        /// <summary>
        /// 用户的存储指针
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }
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
        public WithdrawalsStatus? Status { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取提现记录
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回提现记录</returns>
        public PageResult<WithdrawalsRecordExport> GetWithdrawalsRecords(IModelToDbContextOfAuthor db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            Expression<Func<WithdrawalsRecord, bool>> predicate1 = x => x.Id > 0;
            Expression<Func<WithdrawalsRecord, bool>> predicate2 = x => x.Id > 0;
            Expression<Func<WithdrawalsRecord, bool>> predicate3 = x => x.Id > 0;
            Expression<Func<WithdrawalsRecord, bool>> predicate4 = x => x.Id > 0;
            Expression<Func<WithdrawalsRecord, bool>> predicate5 = x => x.Id > 0;

            if (this.KeywordForUsername != null)
            {
                this.KeywordForUsername = VerifyHelper.EliminateSpaces(this.KeywordForUsername);
                string[] keywords = this.KeywordForUsername.Split(new char[] { ' ' });
                predicate1 = x => keywords.All(kw => x.Owner.Username.Contains(kw));
            }
            if (this.UserId != null)
            {
                int userId = (int)this.UserId;
                predicate2 = x => x.Owner.Id == userId;
            }
            if (this.BeginTime != null)
            {
                DateTime beginTime = (DateTime)this.BeginTime;
                predicate3 = x => x.CreatedTime >= beginTime;
            }
            if (this.EndTime != null)
            {
                DateTime endtime = (DateTime)this.EndTime;
                predicate4 = x => x.CreatedTime <= endtime;
            }
            if (this.Status != null)
            {
                WithdrawalsStatus status = (WithdrawalsStatus)this.Status;
                predicate5 = x => x.Status == status;
            }

            int countOfAllMessages = db.WithdrawalsRecords
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Where(predicate4)
                .Where(predicate5)
                .Count();
            var tList = db.WithdrawalsRecords
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Where(predicate4)
                .Where(predicate5)
                .OrderByDescending(x => x.CreatedTime)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(x => new WithdrawalsRecordExport(x));

            return new PageResult<WithdrawalsRecordExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
