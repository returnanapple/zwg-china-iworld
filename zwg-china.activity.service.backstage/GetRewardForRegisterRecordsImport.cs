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

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于获取注册奖励的参与记录的数据集
    /// </summary>
    [DataContract]
    public class GetRewardForRegisterRecordsImport : GetPageListImportBaseOfActivity
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

        #endregion

        #region 方法

        /// <summary>
        /// 获取注册奖励的参与记录
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回注册奖励的参与记录</returns>
        public PageResult<RewardForRegisterRecordExport> GetRewardForRegisterRecords(IModelToDbContextOfActivity db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            Expression<Func<RewardForRegisterRecord, bool>> predicate1 = x => x.Id > 0;
            Expression<Func<RewardForRegisterRecord, bool>> predicate2 = x => x.Id > 0;
            Expression<Func<RewardForRegisterRecord, bool>> predicate3 = x => x.Id > 0;
            Expression<Func<RewardForRegisterRecord, bool>> predicate4 = x => x.Id > 0;

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

            int countOfAllMessages = db.RewardForRegisterRecords
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Where(predicate4)
                .Count();
            var tList = db.RewardForRegisterRecords
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Where(predicate4)
                .OrderByDescending(x => x.CreatedTime)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(x => new RewardForRegisterRecordExport(x));

            return new PageResult<RewardForRegisterRecordExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
