using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.client
{
    /// <summary>
    /// 用于获取自己的用户信息的数据集
    /// </summary>
    [DataContract]
    public class GetUserInfoImpoert : ImportBaseOfAuthor
    {
        #region 方法

        /// <summary>
        /// 获取自己的用户信息
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回自己的用户信息</returns>
        public NormalResult<AuthorExport> GetSelf(IModelToDbContextOfAuthor db)
        {
            SettingOfAuthor settingOfAuthor = new SettingOfAuthor(db);
            UserGroup group = db.UserGroups.FirstOrDefault(g => g.LowerOfConsumption < this.Self.Consumption && g.CapsOfConsumption > this.Self.Consumption);
            if (group == null)
            {
                group = db.UserGroups.Where(g => g.CapsOfConsumption <= this.Self.Consumption).OrderByDescending(g => g.CapsOfConsumption).FirstOrDefault();
            }
            if (group == null)
            {
                group = db.UserGroups.Where(g => g.LowerOfConsumption > this.Self.Consumption).OrderBy(g => g.LowerOfConsumption).FirstOrDefault();
            }
            SystemQuota systemQuota = db.SystemQuotas.FirstOrDefault(s => s.Rebate == this.Self.PlayInfo.Rebate_Normal);
            if (systemQuota == null)
            {
                systemQuota = new SystemQuota(this.Self.PlayInfo.Rebate_Normal, new List<SystemQuotaDetail>());
                for (double i = settingOfAuthor.LowerRebateOfHigh; i <= settingOfAuthor.CapsRebateOfHigh; i += 0.1)
                {
                    SystemQuotaDetail sqd = new SystemQuotaDetail(i, 0);
                    systemQuota.Details.Add(sqd);
                }
            }

            AuthorExport authorExport = new AuthorExport(this.Self, group, systemQuota.Details);
            return new NormalResult<AuthorExport>(authorExport);
        }

        #endregion
    }
}
