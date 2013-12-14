using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 注册奖励的计划的快照信息
    /// </summary>
    [DataContract]
    public class RewardForRegisterSnapshotExport
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

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的注册奖励的计划的快照信息
        /// </summary>
        /// <param name="model">注册奖励的计划的快照的数据模型</param>
        public RewardForRegisterSnapshotExport(RewardForRegisterSnapshot model)
        {
            this.Id = model.Id;
            this.Title = model.Title;
            this.Description = model.Description;
            this.PrizeType = model.PrizeType;
            this.Sum = model.Sum;
            this.Code = model.Code;
        }

        #endregion
    }
}
