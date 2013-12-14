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
    /// 用于获取用户信息列表的参数集
    /// </summary>
    [DataContract]
    public class GetUsersImport : GetPageListImportOfAuthor
    {
        #region 属性

        /// <summary>
        /// 关键字（用户名）
        /// </summary>
        [DataMember]
        public string KeywordForUsername { get; set; }

        /// <summary>
        /// 一个布尔值，表示只查看直属下级
        /// </summary>
        [DataMember]
        public bool? OnlyImmediate { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取用户信息列表
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回用户信息列表</returns>
        public PageResult<BasicAuthorExport> GetUsers(IModelToDbContextOfAuthor db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            SettingOfAuthor settingOfAuthor = new SettingOfAuthor(db);
            int startRow = settingOfBase.PageSizeForClient * (this.PageIndex - 1);

            Expression<Func<Author, bool>> predicate1 = x => x.Id > 0;
            Expression<Func<Author, bool>> predicate2 = x => x.Id > 0;
            Expression<Func<Author, bool>> predicate3 = x => x.Relatives.Any(r => r.NodeId == this.Self.Id);

            if (this.KeywordForUsername != null)
            {
                this.KeywordForUsername = VerifyHelper.EliminateSpaces(this.KeywordForUsername);
                string[] keywords = this.KeywordForUsername.Split(new char[] { ' ' });
                predicate1 = x => keywords.All(kw => x.Username.Contains(kw));
            }
            if (this.OnlyImmediate == true)
            {
                predicate2 = x => x.Layer == this.Self.Layer + 1;
            }

            int countOfAllMessages = db.Authors
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .Count();
            var tList = db.Authors
                .Where(predicate1)
                .Where(predicate2)
                .Where(predicate3)
                .OrderByDescending(x => x.Layer)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForClient)
                .ToList()
                .ConvertAll(x =>
                {
                    UserGroup group = db.UserGroups.FirstOrDefault(g => g.LowerOfConsumption < x.Consumption && g.CapsOfConsumption > x.Consumption);
                    if (group == null)
                    {
                        group = db.UserGroups.Where(g => g.CapsOfConsumption <= x.Consumption).OrderByDescending(g => g.CapsOfConsumption).FirstOrDefault();
                    }
                    if (group == null)
                    {
                        group = db.UserGroups.Where(g => g.LowerOfConsumption > x.Consumption).OrderBy(g => g.LowerOfConsumption).FirstOrDefault();
                    }

                    return new BasicAuthorExport(x, group);
                });

            return new PageResult<BasicAuthorExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForClient, tList);
        }

        #endregion
    }
}
