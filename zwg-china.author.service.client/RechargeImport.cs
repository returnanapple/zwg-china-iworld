using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using zwg_china.model;
using zwg_china.model.manager;
using System.Runtime.Serialization;

namespace zwg_china.service.client
{
    /// <summary>
    /// 用于创建新的充值记录的数据集
    /// </summary>
    [DataContract]
    public class RechargeImport : ImportBaseOfAuthor, IPackageForCreateModel<IModelToDbContextOfAuthor, RechargeRecord>
    {
        #region 属性

        /// <summary>
        /// 来源银行
        /// </summary>
        [DataMember]
        public Bank ComeFrom { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        [DataMember]
        public string SerialNumber { get; set; }

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
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public RechargeRecord GetModel(IModelToDbContextOfAuthor db)
        {
            Author owner = db.Authors.Find(this.Self.Id);
            return new RechargeRecord(owner, this.ComeFrom, this.SerialNumber);
        }

        #endregion
    }
}
