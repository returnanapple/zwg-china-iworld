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
    /// 用于获取用户组信息的参数集
    /// </summary>
    [DataContract]
    public class GetUserGroupsImport : GetPageListImportOfAuthor
    {
        /// <summary>
        /// 关键字（用户组名）
        /// </summary>
        [DataMember]
        public string KeywordForGroupName { get; set; }

        /// <summary>
        /// 获取用户组信息
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回用户组信息</returns>
        public PageResult<UserGroupExport> GetUserGroups(IModelToDbContextOfAuthor db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            Expression<Func<UserGroup, bool>> predicate1 = x => x.Id > 0;

            if (this.KeywordForGroupName != null)
            {
                this.KeywordForGroupName = VerifyHelper.EliminateSpaces(this.KeywordForGroupName);
                string[] keywords = this.KeywordForGroupName.Split(new char[] { ' ' });
                predicate1 = x => keywords.All(kw => x.Name.Contains(kw));
            }

            int countOfAllMessages = db.UserGroups
                .Where(predicate1)
                .Count();
            var tList = db.UserGroups
                .Where(predicate1)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(userGroup => new UserGroupExport(userGroup));

            return new PageResult<UserGroupExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }
    }
}
