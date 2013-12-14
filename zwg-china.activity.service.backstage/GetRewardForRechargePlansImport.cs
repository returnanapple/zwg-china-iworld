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
    /// 用于获取充值奖励的计划的数据集
    /// </summary>
    [DataContract]
    public class GetRewardForRechargePlansImport : GetPageListImportBaseOfActivity
    {
        #region 属性

        /// <summary>
        /// 关键字（用户名）
        /// </summary>
        [DataMember]
        public string KeywordForTitle { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取充值奖励的计划
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回充值奖励的计划</returns>
        public PageResult<RewardForRechargePlanExport> GetRewardForRechargePlans(IModelToDbContextOfActivity db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            Expression<Func<RewardForRechargePlan, bool>> predicate1 = x => x.EndTime > DateTime.Now;
            Expression<Func<RewardForRechargePlan, bool>> predicate2 = x => x.Id > 0;

            if (this.KeywordForTitle != null)
            {
                this.KeywordForTitle = VerifyHelper.EliminateSpaces(this.KeywordForTitle);
                string[] keywords = this.KeywordForTitle.Split(new char[] { ' ' });
                predicate2 = x => keywords.All(kw => x.Title.Contains(kw));
            }

            int countOfAllMessages = db.RewardForRechargePlans
                .Where(predicate1)
                .Where(predicate2)
                .Count();
            var tList = db.RewardForRechargePlans
                .Where(predicate1)
                .Where(predicate2)
                .OrderByDescending(x => x.CreatedTime)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(x => new RewardForRechargePlanExport(x));

            return new PageResult<RewardForRechargePlanExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
