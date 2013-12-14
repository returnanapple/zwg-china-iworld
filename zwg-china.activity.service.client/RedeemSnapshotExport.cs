using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using zwg_china.model;

namespace zwg_china.service.client
{
    /// <summary>
    /// 积分兑换的计划的快照
    /// </summary>
    [DataContract]
    public class RedeemSnapshotExport
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
        /// 标识码
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的积分兑换的计划的快照
        /// </summary>
        /// <param name="model">积分兑换的计划的快照的数据模型</param>
        public RedeemSnapshotExport(RedeemSnapshot model)
        {
            this.Id = model.Id;
            this.Title = model.Title;
            this.Description = model.Description;
            this.Integral = model.Integral;
            this.Money = model.Money;
            this.Code = model.Code;
        }

        #endregion
    }
}
