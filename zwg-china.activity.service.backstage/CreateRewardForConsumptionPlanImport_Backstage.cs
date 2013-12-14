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
    /// 用于创建消费奖励的计划的数据集
    /// </summary>
    [DataContract]
    public class CreateRewardForConsumptionPlanImport_Backstage : ImportBaseOfActivity, IPackageForCreateModel<IModelToDbContextOfActivity, RewardForConsumptionPlan>
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
        /// 计划类型
        /// </summary>
        [DataMember]
        public RewardPlanType PlanType { get; set; }

        /// <summary>
        /// 时间刻度（只在计划类型为“满就送”时候生效）
        /// </summary>
        [DataMember]
        public TimescaleOfActivity Timescale { get; set; }

        /// <summary>
        /// 明细
        /// </summary>
        [DataMember]
        public List<RewardForConsumptionPlanDetailImport> Details { get; set; }

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
            if (this.Details.Count <= 0)
            {
                throw new Exception("明细不能为空，请检查输入");
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
        public RewardForConsumptionPlan GetModel(IModelToDbContextOfActivity db)
        {
            List<RewardForConsumptionPlanDetail> details = this.Details
                .ConvertAll(x => new RewardForConsumptionPlanDetail(x.LowerConsumption, x.CapsConsumption, x.PrizeType, x.Sum, x.WaysToReward));
            return new RewardForConsumptionPlan(this.Title, this.Description, this.PlanType, this.Timescale, details
                , this.BeginTime, this.EndTime, this.Hide);
        }

        #endregion
    }
}
