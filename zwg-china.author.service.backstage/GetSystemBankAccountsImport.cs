using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用于获取银行账户信息的参数集
    /// </summary>
    [DataContract]
    public class GetSystemBankAccountsImport : GetSettingImport
    {
        #region 属性

        /// <summary>
        /// 页码
        /// </summary>
        [DataMember]
        public int PageIndex { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 获取银行账户信息
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回银行账户信息</returns>
        public PageResult<SystemBankAccountExport> GetSystemBankAccounts(IModelToDbContextOfAuthor db)
        {
            if (this.PageIndex < 1) { this.PageIndex = 1; }
            SettingOfBase settingOfBase = new SettingOfBase(db);
            int startRow = settingOfBase.PageSizeForAdmin * (this.PageIndex - 1);

            int countOfAllMessages = db.SystemBankAccounts
                .Count();
            var tList = db.SystemBankAccounts
                .Skip(startRow)
                .Take(settingOfBase.PageSizeForAdmin)
                .ToList()
                .ConvertAll(x => new SystemBankAccountExport(x));

            return new PageResult<SystemBankAccountExport>(this.PageIndex, countOfAllMessages, settingOfBase.PageSizeForAdmin, tList);
        }

        #endregion
    }
}
