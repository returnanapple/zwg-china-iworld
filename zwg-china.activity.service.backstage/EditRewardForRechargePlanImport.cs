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

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于修改充值奖励的计划的数据集
    /// </summary>
    [DataContract]
    public class EditRewardForRechargePlanImport : ImportBaseOfActivity, IPackageForUpdateModel<IModelToDbContextOfActivity, RewardForRechargePlan>
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

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
        public List<RewardForRechargePlanDetailImport> Details { get; set; }

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
        }

        /// <summary>
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        public void Update(RewardForRechargePlan model)
        {
            model.Title = this.Title;
            model.Description = this.Description;
            model.PlanType = this.PlanType;
            model.Timescale = this.Timescale;
            model.BeginTime = this.BeginTime;
            model.EndTime = this.EndTime;
            model.Hide = this.Hide;

            if (this.Details.Count < model.Details.Count)
            {
                model.Details.Take(model.Details.Count - this.Details.Count).ToList()
                    .ForEach(x =>
                    {
                        model.Details.Remove(x);
                    });
            }
            for (int i = 0; i < this.Details.Count; i++)
            {
                if (i <= model.Details.Count)
                {
                    model.Details[i].LowerRecharge = this.Details[i].LowerRecharge;
                    model.Details[i].CapsRecharge = this.Details[i].CapsRecharge;
                    model.Details[i].PrizeType = this.Details[i].PrizeType;
                    model.Details[i].Sum = this.Details[i].Sum;
                    model.Details[i].WaysToReward = this.Details[i].WaysToReward;
                }
                else
                {
                    RewardForRechargePlanDetail detail = new RewardForRechargePlanDetail(this.Details[i].LowerRecharge
                        , this.Details[i].CapsRecharge, this.Details[i].PrizeType, this.Details[i].Sum, this.Details[i].WaysToReward);
                    model.Details.Add(detail);
                }
            }
        }

        #endregion
    }
}
