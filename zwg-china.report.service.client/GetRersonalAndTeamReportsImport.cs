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

namespace zwg_china.service.client
{
    /// <summary>
    /// 用于获取私人/团队报表的数据集
    /// </summary>
    [DataContract]
    public class GetRersonalAndTeamReportsImport : GetPageListImportBaseOfReport
    {
        #region 属性

        /// <summary>
        /// 月还是日
        /// </summary>
        [DataMember]
        public MonthOrDay MOD { get; set; }

        /// <summary>
        /// 团队还是个人 
        /// </summary>
        [DataMember]
        public TeamOrSelf TOS { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取私人/团队报表
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回私人/团队报表</returns>
        public PageResult<RersonalAndTeamReportExport> GetRersonalAndTeamReports(IModelToDbContextOfReport db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForClient * (this.PageIndex - 1);

            if (this.TOS == TeamOrSelf.Self)
            {
                if (this.MOD == MonthOrDay.Month)
                {
                    #region 单月个人报表

                    Expression<Func<RersonalReportForOneMonth, bool>> predicate1 = x => x.Owner.Id == this.Self.Id;

                    int countOfAllMessages = db.RersonalReportForOneMonths
                        .Where(predicate1)
                        .Count();
                    var tList = db.RersonalReportForOneMonths
                        .Where(predicate1)
                        .OrderByDescending(x => x.Id)
                        .Skip(startRow)
                        .Take(settingOfBase.PageSizeForClient)
                        .ToList()
                        .ConvertAll(x => new RersonalAndTeamReportExport(x));

                    return new PageResult<RersonalAndTeamReportExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForClient, tList);

                    #endregion
                }
                else
                {
                    #region 单日个人报表

                    Expression<Func<RersonalReportForOneDay, bool>> predicate1 = x => x.Owner.Id == this.Self.Id;

                    int countOfAllMessages = db.RersonalReportForOneDays
                        .Where(predicate1)
                        .Count();
                    var tList = db.RersonalReportForOneDays
                        .Where(predicate1)
                        .OrderByDescending(x => x.Id)
                        .Skip(startRow)
                        .Take(settingOfBase.PageSizeForClient)
                        .ToList()
                        .ConvertAll(x => new RersonalAndTeamReportExport(x));

                    return new PageResult<RersonalAndTeamReportExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForClient, tList);

                    #endregion
                }
            }
            else
            {
                if (this.MOD == MonthOrDay.Month)
                {
                    #region 单月团队人报表

                    Expression<Func<TeamReportForOneMonth, bool>> predicate1 = x => x.Owner.Id == this.Self.Id;

                    int countOfAllMessages = db.TeamReportForOneMonths
                        .Where(predicate1)
                        .Count();
                    var tList = db.TeamReportForOneMonths
                        .Where(predicate1)
                        .OrderByDescending(x => x.Id)
                        .Skip(startRow)
                        .Take(settingOfBase.PageSizeForClient)
                        .ToList()
                        .ConvertAll(x => new RersonalAndTeamReportExport(x));

                    return new PageResult<RersonalAndTeamReportExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForClient, tList);

                    #endregion
                }
                else
                {
                    #region 单月团队人报表

                    Expression<Func<TeamReportForOneDay, bool>> predicate1 = x => x.Owner.Id == this.Self.Id;

                    int countOfAllMessages = db.TeamReportForOneDays
                        .Where(predicate1)
                        .Count();
                    var tList = db.TeamReportForOneDays
                        .Where(predicate1)
                        .OrderByDescending(x => x.Id)
                        .Skip(startRow)
                        .Take(settingOfBase.PageSizeForClient)
                        .ToList()
                        .ConvertAll(x => new RersonalAndTeamReportExport(x));

                    return new PageResult<RersonalAndTeamReportExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForClient, tList);

                    #endregion
                }
            }
        }

        #endregion
    }
}
