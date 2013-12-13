using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 注册奖励的计划信息
    /// </summary>
    [DataContract]
    public class RewardForRegisterPlanExport
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
        /// 标识码
        /// </summary>
        [DataMember]
        public string Code { get; set; }

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

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public RegularStatus Status { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的注册奖励的计划信息
        /// </summary>
        /// <param name="model">注册奖励的计划的数据模型</param>
        public RewardForRegisterPlanExport(RewardForRegisterPlan model)
        {
            this.Id = model.Id;
            this.Title = model.Title;
            this.Description = model.Description;
            this.PrizeType = model.PrizeType;
            this.Sum = model.Sum;
            this.Code = model.Code;
            this.BeginTime = model.BeginTime;
            this.EndTime = model.EndTime;
            this.Hide = model.Hide;
            this.Status = model.Status;
        }

        #endregion
    }
}
