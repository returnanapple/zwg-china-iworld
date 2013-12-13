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
    /// 用于创建新的积分兑换参与记录
    /// </summary>
    [DataContract]
    public class CreateRedeemRecordsImport : ImportBaseOfActivity, IPackageForCreateModel<IModelToDbContextOfActivity, RedeemRecord>
    {
        #region 私有字段

        RedeemPlan plan = null;

        #endregion

        #region 属性

        /// <summary>
        /// 对应的计划（快照）
        /// </summary>
        [DataMember]
        public int PlanId { get; set; }

        /// <summary>
        /// 兑换数量
        /// </summary>
        [DataMember]
        public int Sum { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfActivity db)
        {
            this.plan = db.RedeemPlans.Find(this.PlanId);
            if (this.Self.Integral < this.plan.Integral * this.Sum)
            {
                throw new Exception("积分不足");
            }
        }

        /// <summary>
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public RedeemRecord GetModel(IModelToDbContextOfActivity db)
        {
            RedeemSnapshot rs = db.RedeemSnapshots.FirstOrDefault(x => x.Code == this.plan.Code);
            if (rs == null)
            {
                rs = new RedeemSnapshot(this.plan);
            }
            return new RedeemRecord(this.Self, rs, this.Sum);
        }

        #endregion
    }
}
