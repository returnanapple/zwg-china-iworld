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
    /// 用于获取公告列表的数据集
    /// </summary>
    [DataContract]
    public class GetBulletinsImport : GetPageListImportBaseOfMessage
    {
        #region 属性

        /// <summary>
        /// 关键字
        /// </summary>
        [DataMember]
        public string KeywordOfTitle { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回公告列表</returns>
        public PageResult<BulletinExport> GetBulletins(IModelToDbContextOfMessage db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            Expression<Func<Bulletin, bool>> predicate1 = x => x.Id > 0;
            Expression<Func<Bulletin, bool>> predicate2 = x => x.EndTime >= DateTime.Now;

            if (this.KeywordOfTitle != null)
            {
                this.KeywordOfTitle = VerifyHelper.EliminateSpaces(this.KeywordOfTitle);
                string[] keywords = this.KeywordOfTitle.Split(new char[] { ' ' });
                predicate1 = x => keywords.All(kw => x.Title.Contains(kw));
            }

            int countOfAllMessages = db.Bulletins
                .Where(predicate1)
                .Where(predicate2)
                .Count();
            var tList = db.Bulletins
                .Where(predicate1)
                .Where(predicate2)
                .OrderByDescending(x => x.CreatedTime)
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(x => new BulletinExport(x));

            return new PageResult<BulletinExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
