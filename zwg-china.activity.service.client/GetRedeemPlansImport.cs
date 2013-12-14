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
    /// 用于获取积分兑换奖励的计划的数据集
    /// </summary>
    [DataContract]
    public class GetRedeemPlansImport : GetPageListImportBaseOfActivity
    {
        #region 方法

        /// <summary>
        /// 获取积分兑换奖励的计划
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回积分兑换奖励的计划</returns>
        public PageResult<RedeemPlanExport> GetRedeemPlans(IModelToDbContextOfActivity db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForClient * (this.PageIndex - 1);

            Expression<Func<RedeemPlan, bool>> predicate1 = x => x.EndTime > DateTime.Now;
            Expression<Func<RedeemPlan, bool>> predicate2 = x => x.Hide == false;

            int countOfAllMessages = db.RedeemPlans
                .Where(predicate1)
                .Where(predicate2)
                .Count();
            var tList = db.RedeemPlans
                .Where(predicate1)
                .Where(predicate2)
                .OrderByDescending(x => x.CreatedTime)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForClient)
                .ToList()
                .ConvertAll(x => new RedeemPlanExport(x));

            return new PageResult<RedeemPlanExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForClient, tList);
        }

        #endregion
    }
}
