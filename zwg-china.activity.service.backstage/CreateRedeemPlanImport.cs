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
    /// 用于创建积分兑换的计划的数据集
    /// </summary>
    [DataContract]
    public class CreateRedeemPlanImport : ImportBaseOfActivity, IPackageForCreateModel<IModelToDbContextOfActivity, RedeemPlan>
    {
        #region 属性

        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 积分（用于兑换的单价）
        /// </summary>
        [DataMember]
        public int Integral { get; set; }

        /// <summary>
        /// 人民币（单次兑换数额）
        /// </summary>
        [DataMember]
        public double Money { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember]
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 一个布尔值 标识活动是否暂停
        /// </summary>
        [DataMember]
        public bool Hide { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfActivity db)
        {
            this.Title = VerifyHelper.EliminateSpaces(this.Title);
            this.Description = VerifyHelper.EliminateSpaces(this.Description);
            if (this.Integral <= 0)
            {
                throw new Exception("兑换用的积分必须大于 0，请检查输入");
            }
            if (this.Money <= 0)
            {
                throw new Exception("作为奖励的现金必须大于 0，请检查输入");
            }
            if (this.BeginTime >= this.EndTime)
            {
                throw new Exception("结束时间不能小于开始时间，请检查输入");
            }
        }

        /// <summary>
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public RedeemPlan GetModel(IModelToDbContextOfActivity db)
        {
            return new RedeemPlan(this.Title, this.Description, this.Integral, this.Money, this.BeginTime, this.EndTime, this.Hide);
        }

        #endregion
    }
}
