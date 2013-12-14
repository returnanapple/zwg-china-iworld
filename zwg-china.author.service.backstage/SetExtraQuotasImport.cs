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
    /// 用于修改额外的直属高点号配额的数据集
    /// </summary>
    [DataContract]
    public class SetExtraQuotasImport : ImportBaseOfAuthor, IPackageForUpdateModel<IModelToDbContextOfAuthor, Author>
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 额外的直属高点号配额
        /// </summary>
        [DataMember]
        public List<ExtraQuotaImport> ExtraQuotas { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfAuthor db)
        {
        }

        /// <summary>
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        public void Update(Author model)
        {
            this.ExtraQuotas
                .ForEach(x =>
                {
                    ExtraQuota eq = model.ExtraQuotas.FirstOrDefault(e => e.Rebate == x.Rebate);
                    if (eq != null)
                    {
                        eq.Sum = x.Sum;
                    }
                    else
                    {
                        eq = new ExtraQuota(x.Rebate, x.Sum);
                        model.ExtraQuotas.Add(eq);
                    }
                });
        }

        #endregion

        #region 内嵌类型

        /// <summary>
        /// 用于修改额外的直属高点号配额的数据集
        /// </summary>
        [DataContract]
        public class ExtraQuotaImport
        {
            /// <summary>
            /// 返点
            /// </summary>
            [DataMember]
            public double Rebate { get; set; }

            /// <summary>
            /// 人数
            /// </summary>
            [DataMember]
            public int Sum { get; set; }
        }

        #endregion
    }
}
