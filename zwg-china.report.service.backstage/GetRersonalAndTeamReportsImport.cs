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
    /// 用于获取私人/团队报表的数据集
    /// </summary>
    [DataContract]
    public class GetRersonalAndTeamReportsImport : GetPageListImportBaseOfReport
    {
        #region 属性

        /// <summary>
        /// 关键字
        /// </summary>
        [DataMember]
        public string KeywordOfUsername { get; set; }

        /// <summary>
        /// 用户的存储指针
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

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
        /// 获取私人/团队报表
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回私人/团队报表</returns>
        public PageResult<RersonalAndTeamReportExport> GetRersonalAndTeamReports(IModelToDbContextOfReport db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            if (this.TOS == TeamOrSelf.Self)
            {
                if (this.MOD == MonthOrDay.Month)
                {
                    #region 单月个人报表

                    Expression<Func<RersonalReportForOneMonth, bool>> predicate1 = x => x.Id > 0;
                    Expression<Func<RersonalReportForOneMonth, bool>> predicate2 = x => x.Id > 0;
                    Expression<Func<RersonalReportForOneMonth, bool>> predicate3 = x => x.Id > 0;
                    Expression<Func<RersonalReportForOneMonth, bool>> predicate4 = x => x.Id > 0;

                    if (this.KeywordOfUsername != null)
                    {
                        this.KeywordOfUsername = VerifyHelper.EliminateSpaces(this.KeywordOfUsername);
                        string[] keywords = this.KeywordOfUsername.Split(new char[] { ' ' });
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
                        predicate3 = x => x.Time >= beginTime;
                    }
                    if (this.EndTime != null)
                    {
                        DateTime endtime = (DateTime)this.EndTime;
                        predicate4 = x => x.Time <= endtime;
                    }

                    int countOfAllMessages = db.RersonalReportForOneMonths
                        .Where(predicate1)
                        .Where(predicate2)
                        .Where(predicate3)
                        .Where(predicate4)
                        .Count();
                    var tList = db.RersonalReportForOneMonths
                        .Where(predicate1)
                        .Where(predicate2)
                        .Where(predicate3)
                        .Where(predicate4)
                        .OrderByDescending(x => x.Id)
                        .Skip(startRow)
                        .Take(settingOfBase.PageSizeForAdmin)
                        .ToList()
                        .ConvertAll(x => new RersonalAndTeamReportExport(x));

                    return new PageResult<RersonalAndTeamReportExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);

                    #endregion
                }
                else
                {
                    #region 单日个人报表

                    Expression<Func<RersonalReportForOneDay, bool>> predicate1 = x => x.Id > 0;
                    Expression<Func<RersonalReportForOneDay, bool>> predicate2 = x => x.Id > 0;
                    Expression<Func<RersonalReportForOneDay, bool>> predicate3 = x => x.Id > 0;
                    Expression<Func<RersonalReportForOneDay, bool>> predicate4 = x => x.Id > 0;

                    if (this.KeywordOfUsername != null)
                    {
                        this.KeywordOfUsername = VerifyHelper.EliminateSpaces(this.KeywordOfUsername);
                        string[] keywords = this.KeywordOfUsername.Split(new char[] { ' ' });
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
                        predicate3 = x => x.Time >= beginTime;
                    }
                    if (this.EndTime != null)
                    {
                        DateTime endtime = (DateTime)this.EndTime;
                        predicate4 = x => x.Time <= endtime;
                    }

                    int countOfAllMessages = db.RersonalReportForOneDays
                        .Where(predicate1)
                        .Where(predicate2)
                        .Where(predicate3)
                        .Where(predicate4)
                        .Count();
                    var tList = db.RersonalReportForOneDays
                        .Where(predicate1)
                        .Where(predicate2)
                        .Where(predicate3)
                        .Where(predicate4)
                        .OrderByDescending(x => x.Id)
                        .Skip(startRow)
                        .Take(settingOfBase.PageSizeForAdmin)
                        .ToList()
                        .ConvertAll(x => new RersonalAndTeamReportExport(x));

                    return new PageResult<RersonalAndTeamReportExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);

                    #endregion
                }
            }
            else
            {
                if (this.MOD == MonthOrDay.Month)
                {
                    #region 单月团队人报表

                    Expression<Func<TeamReportForOneMonth, bool>> predicate1 = x => x.Id > 0;
                    Expression<Func<TeamReportForOneMonth, bool>> predicate2 = x => x.Id > 0;
                    Expression<Func<TeamReportForOneMonth, bool>> predicate3 = x => x.Id > 0;
                    Expression<Func<TeamReportForOneMonth, bool>> predicate4 = x => x.Id > 0;

                    if (this.KeywordOfUsername != null)
                    {
                        this.KeywordOfUsername = VerifyHelper.EliminateSpaces(this.KeywordOfUsername);
                        string[] keywords = this.KeywordOfUsername.Split(new char[] { ' ' });
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
                        predicate3 = x => x.Time >= beginTime;
                    }
                    if (this.EndTime != null)
                    {
                        DateTime endtime = (DateTime)this.EndTime;
                        predicate4 = x => x.Time <= endtime;
                    }

                    int countOfAllMessages = db.TeamReportForOneMonths
                        .Where(predicate1)
                        .Where(predicate2)
                        .Where(predicate3)
                        .Where(predicate4)
                        .Count();
                    var tList = db.TeamReportForOneMonths
                        .Where(predicate1)
                        .Where(predicate2)
                        .Where(predicate3)
                        .Where(predicate4)
                        .OrderByDescending(x => x.Id)
                        .Skip(startRow)
                        .Take(settingOfBase.PageSizeForAdmin)
                        .ToList()
                        .ConvertAll(x => new RersonalAndTeamReportExport(x));

                    return new PageResult<RersonalAndTeamReportExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);

                    #endregion
                }
                else
                {
                    #region 单月团队人报表

                    Expression<Func<TeamReportForOneDay, bool>> predicate1 = x => x.Id > 0;
                    Expression<Func<TeamReportForOneDay, bool>> predicate2 = x => x.Id > 0;
                    Expression<Func<TeamReportForOneDay, bool>> predicate3 = x => x.Id > 0;
                    Expression<Func<TeamReportForOneDay, bool>> predicate4 = x => x.Id > 0;

                    if (this.KeywordOfUsername != null)
                    {
                        this.KeywordOfUsername = VerifyHelper.EliminateSpaces(this.KeywordOfUsername);
                        string[] keywords = this.KeywordOfUsername.Split(new char[] { ' ' });
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
                        predicate3 = x => x.Time >= beginTime;
                    }
                    if (this.EndTime != null)
                    {
                        DateTime endtime = (DateTime)this.EndTime;
                        predicate4 = x => x.Time <= endtime;
                    }

                    int countOfAllMessages = db.TeamReportForOneDays
                        .Where(predicate1)
                        .Where(predicate2)
                        .Where(predicate3)
                        .Where(predicate4)
                        .Count();
                    var tList = db.TeamReportForOneDays
                        .Where(predicate1)
                        .Where(predicate2)
                        .Where(predicate3)
                        .Where(predicate4)
                        .OrderByDescending(x => x.Id)
                        .Skip(startRow)
                        .Take(settingOfBase.PageSizeForAdmin)
                        .ToList()
                        .ConvertAll(x => new RersonalAndTeamReportExport(x));

                    return new PageResult<RersonalAndTeamReportExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);

                    #endregion
                }
            }
        }

        #endregion
    }
}
