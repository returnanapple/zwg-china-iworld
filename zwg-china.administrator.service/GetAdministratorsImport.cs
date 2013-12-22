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
    /// 用于获取管理员信息的分页列表的数据集
    /// </summary>
    [DataContract]
    public class GetAdministratorsImport : GetPageListImportBaseOfAdministrator
    {
        #region 属性

        /// <summary>
        /// 关键字（用户名）
        /// </summary>
        [DataMember]
        public string KeywordForUsername { get; set; }

        /// <summary>
        /// 所从属的用户组的存储指针
        /// </summary>
        [DataMember]
        public int? GroupId { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取管理员信息的分页列表
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回管理员信息的分页列表</returns>
        public PageResult<BasicAdministratorExport> GetAdministrators(IModelToDbContextOfAdministrator db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);


            Expression<Func<Administrator, bool>> predicate1 = x => x.Id > 0;
            Expression<Func<Administrator, bool>> predicate2 = x => x.Id > 0;

            if (this.KeywordForUsername != null)
            {
                this.KeywordForUsername = VerifyHelper.EliminateSpaces(this.KeywordForUsername);
                string[] keywords = this.KeywordForUsername.Split(new char[] { ' ' });
                predicate1 = x => keywords.All(kw => x.Username.Contains(kw));
            }
            if (this.GroupId != null)
            {
                int groupId = (int)this.GroupId;
                predicate2 = x => x.Group.Id == groupId;
            }

            int countOfAllMessages = db.Administrators
                .Where(predicate1)
                .Where(predicate2)
                .Count();
            var tList = db.Administrators
                .Where(predicate1)
                .Where(predicate2)
                .OrderBy(x => x.Username)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(x => new BasicAdministratorExport(x));

            return new PageResult<BasicAdministratorExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
