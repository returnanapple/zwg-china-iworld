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
    /// 用于获取管理员组信息的分页列表的数据集
    /// </summary>
    [DataContract]
    public class GetAdministratorGroupsImport : GetPageListImportBaseOfAdministrator
    {
        #region 属性

        /// <summary>
        /// 关键字（用户名）
        /// </summary>
        [DataMember]
        public string KeywordForUsername { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取管理员组信息的分页列表
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回管理员组信息的分页列表</returns>
        public PageResult<AdministratorGroupExport> GetAdministratorGroups(IModelToDbContextOfAdministrator db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);


            Expression<Func<AdministratorGroup, bool>> predicate1 = x => x.Id > 0;

            if (this.KeywordForUsername != null)
            {
                this.KeywordForUsername = VerifyHelper.EliminateSpaces(this.KeywordForUsername);
                string[] keywords = this.KeywordForUsername.Split(new char[] { ' ' });
                predicate1 = x => keywords.All(kw => x.Name.Contains(kw));
            }

            int countOfAllMessages = db.AdministratorGroups
                .Where(predicate1)
                .Count();
            var tList = db.AdministratorGroups
                .Where(predicate1)
                .OrderBy(x => x.Name)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(x => new AdministratorGroupExport(x));

            return new PageResult<AdministratorGroupExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
