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
    /// 用于创建注册奖励的计划的数据集
    /// </summary>
    [DataContract]
    public class CreateRewardForRegisterPlanImport_Backstage : ImportBaseOfActivity, IPackageForCreateModel<IModelToDbContextOfActivity, RewardForRegisterPlan>
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
        /// 奖品类型
        /// </summary>
        [DataMember]
        public PrizesOfActivityType PrizeType { get; set; }

        /// <summary>
        /// 数额
        /// </summary>
        [DataMember]
        public double Sum { get; set; }

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
            if (this.EndTime <= this.BeginTime)
            {
                throw new Exception("结束时间必须大于开始时间");
            }
            if (this.Sum <= 0)
            {
                throw new Exception("奖励必须大于 0");
            }
        }

        /// <summary>
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public RewardForRegisterPlan GetModel(IModelToDbContextOfActivity db)
        {
            return new RewardForRegisterPlan(this.Title, this.Description, this.PrizeType, this.Sum, this.BeginTime, this.EndTime, this.Hide);
        }

        #endregion
    }
}
