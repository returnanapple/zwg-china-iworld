using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于修改系统设定的高点号配额方案的数据集
    /// </summary>
    [DataContract]
    public class SetStstemQuotaImport : SetSettingImportBase
    {
        #region 属性

        /// <summary>
        /// 方案
        /// </summary>
        [DataMember]
        public List<QuotaImport> Quotas { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 设置并保存
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void SetAndSave(IModelToDbContextOfAuthor db)
        {
            List<SystemQuota> sqs = db.SystemQuotas.ToList();
            sqs.Where(x => !this.Quotas.Any(q => q.Rebate == x.Rebate)).ToList()
                .ForEach(x =>
                {
                    db.SystemQuotas.Remove(x);
                });
            this.Quotas
                .ForEach(quota =>
                {
                    SystemQuota sq = sqs.FirstOrDefault(x => x.Rebate == quota.Rebate);
                    if (sq == null)
                    {
                        sq = new SystemQuota(quota.Rebate, new List<SystemQuotaDetail>());
                        db.SystemQuotas.Add(sq);
                    }
                    sq.Details.RemoveAll(x => !quota.Details.Any(d => d.Rebate == x.Rebate));
                    quota.Details
                        .ForEach(detail =>
                        {
                            SystemQuotaDetail sqd = sq.Details.FirstOrDefault(x => x.Rebate == detail.Rebate);
                            if (sqd == null)
                            {
                                sqd = new SystemQuotaDetail(detail.Rebate, detail.Sum);
                                sq.Details.Add(sqd);
                            }
                            else
                            {
                                sqd.Sum = detail.Sum;
                            }
                        });
                });
            db.SaveChanges();
        }
        #endregion

        #region 内嵌类型

        /// <summary>
        /// 方案
        /// </summary>
        [DataContract]
        public class QuotaImport
        {
            /// <summary>
            /// 返点
            /// </summary>
            [DataMember]
            public double Rebate { get; set; }

            /// <summary>
            /// 明细
            /// </summary>
            [DataMember]
            public List<QuotaDetailImport> Details { get; set; }
        }

        /// <summary>
        /// 明细
        /// </summary>
        [DataContract]
        public class QuotaDetailImport
        {
            /// <summary>
            /// 返点
            /// </summary>
            [DataMember]
            public double Rebate { get; set; }

            /// <summary>
            /// 数量
            /// </summary>
            [DataMember]
            public int Sum { get; set; }
        }

        #endregion
    }
}
