using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.aid;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于新建充值记录的数据集
    /// </summary>
    [DataContract]
    public class CreateRechargeRecordImport : ImportBaseOfAuthor, IPackageForCreateModel<IModelToDbContextOfAuthor, RechargeRecord>
    {
        #region 属性

        /// <summary>
        /// 用户的存储指针
        /// </summary>
        [DataMember]
        public int OwnerId { get; set; }

        /// <summary>
        /// 充值金额
        /// </summary>
        [DataMember]
        public double Sum { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfAuthor db)
        {
            if (this.Sum < 0)
            {
                throw new Exception("充值金额不能小于 0");
            }
        }

        /// <summary>
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public RechargeRecord GetModel(IModelToDbContextOfAuthor db)
        {
            Author owner = db.Authors.Find(this.OwnerId);
            RechargeRecord result = new RechargeRecord(owner, Bank.无, "");
            result.Status = RechargeStatus.后台手动添加;
            return result;
        }

        #endregion
    }
}
