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
        /// 所从属的用户组的存储指针
        /// </summary>
        [DataMember]
        public int? GroupId { get; set; }

        /// <summary>
        /// 所隶属的上级（无论是否直属）用户的存储指针
        /// </summary>
        [DataMember]
        public int? BelongingUserId { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取用户信息列表
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回用户信息列表</returns>
        public PageResult<AuthorExport> GetUsers(IModelToDbContextOfAuthor db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            SettingOfAuthor settingOfAuthor = new SettingOfAuthor(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            Expression<Func<Author, bool>> predicate1 = x => x.Id > 0;
            Expression<Func<Author, bool>> predicate2 = x => x.Id > 0;
            Expression<Func<Author, bool>> predicate3 = x => x.Id > 0;

            if (this.KeywordForUsername != null)
            {
                this.KeywordForUsername = VerifyHelper.EliminateSpaces(this.KeywordForUsername);
                string[] keywords = this.KeywordForUsername.Split(new char[] { ' ' });
                predicate1 = x => keywords.All(kw => x.Username.Contains(kw));
            }
            if (this.GroupId != null)
            {
                int groupId = (int)this.GroupId;
                UserGroup group = db.UserGroups.Find(groupId);
                predicate2 = x => x.Consumption >= group.LowerOfConsumption
                    && x.Consumption < group.CapsOfConsumption;
            }
            if (this.BelongingUserId != null)
            {
                int belongingUserId = (int)this.BelongingUserId;
                predicate3 = x => x.Relatives.Any(r => r.NodeId == belongingUserId);
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
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
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
                    SystemQuota systemQuota = db.SystemQuotas.FirstOrDefault(s => s.Rebate == x.PlayInfo.Rebate_Normal);
                    if (systemQuota == null)
                    {
                        systemQuota = new SystemQuota(x.PlayInfo.Rebate_Normal, new List<SystemQuotaDetail>());
                        for (double i = settingOfAuthor.LowerRebateOfHigh; i <= settingOfAuthor.CapsRebateOfHigh; i += 0.1)
                        {
                            SystemQuotaDetail sqd = new SystemQuotaDetail(i, 0);
                            systemQuota.Details.Add(sqd);
                        }
                    }

                    return new AuthorExport(x, group, systemQuota.Details);
                });

            return new PageResult<AuthorExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
