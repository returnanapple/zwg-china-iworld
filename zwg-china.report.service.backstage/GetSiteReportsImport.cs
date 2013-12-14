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
    /// 用于获取站点统计的数据集
    /// </summary>
    [DataContract]
    public class GetSiteReportsImport : GetPageListImportBaseOfReport
    {
        #region 属性

        /// <summary>
        /// 月还是日
        /// </summary>
        [DataMember]
        public MonthOrDay MOD { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取站点统计
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回站点统计</returns>
        public PageResult<SiteReportExpot> GetSiteReports(IModelToDbContextOfReport db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            if (this.MOD == MonthOrDay.Month)
            {
                int countOfAllMessages = db.SiteReportForOneMonths
                    .Count();
                var tList = db.SiteReportForOneMonths
                    .OrderByDescending(x => x.Id)
                    .Skip(startRow)
                    .Take(settingOfBase.PageSizeForAdmin)
                    .ToList()
                    .ConvertAll(x => new SiteReportExpot(x));

                return new PageResult<SiteReportExpot>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
            }
            else
            {
                int countOfAllMessages = db.SiteReportForOneDays
                    .Count();
                var tList = db.SiteReportForOneDays
                    .OrderByDescending(x => x.Id)
                    .Skip(startRow)
                    .Take(settingOfBase.PageSizeForAdmin)
                    .ToList()
                    .ConvertAll(x => new SiteReportExpot(x));

                return new PageResult<SiteReportExpot>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
            }
        }

        #endregion
    }
}
