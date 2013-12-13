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
    /// 用于获取积分兑换的参与记录的数据集
    /// </summary>
    [DataContract]
    public class GetRedeemRecordsImport : GetPageListImportBaseOfActivity
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

        #endregion

        #region 方法

        /// <summary>
        /// 获取积分兑换的参与记录
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回积分兑换的参与记录</returns>
        public PageResult<RedeemRecordExport> GetRedeemRecords(IModelToDbContextOfActivity db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            Expression<Func<RedeemRecord, bool>> predicate1 = x => x.Owner.Id == this.Self.Id;
            Expression<Func<RedeemRecord, bool>> predicate2 = x => x.Id > 0;
            Expression<Func<RedeemRecord, bool>> predicate3 = x => x.Id > 0;

            if (this.BeginTime != null)
            {
                DateTime beginTime = (DateTime)this.BeginTime;
                predicate2 = x => x.CreatedTime >= beginTime;
            }
            if (this.EndTime != null)
            {
                DateTime endtime = (DateTime)this.EndTime;
                predicate3 = x => x.CreatedTime <= endtime;
            }

            int countOfAllMessages = db.RedeemRecords
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Count();
            var tList = db.RedeemRecords
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(x => new RedeemRecordExport(x));

            return new PageResult<RedeemRecordExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
