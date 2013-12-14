using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using zwg_china.model;

namespace zwg_china.service.client
{
    /// <summary>
    /// 积分兑换的参与记录
    /// </summary>
    [DataContract]
    public class RedeemRecordExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 用户的存储指针
        /// </summary>
        [DataMember]
        public int OwnerId { get; set; }

        /// <summary>
        /// 用户的用户名
        /// </summary>
        [DataMember]
        public string Owner { get; set; }

        /// <summary>
        /// 对应的计划（快照）
        /// </summary>
        [DataMember]
        public virtual RedeemSnapshotExport Plan { get; set; }

        /// <summary>
        /// 兑换数量
        /// </summary>
        [DataMember]
        public int Sum { get; set; }

        /// <summary>
        /// 单次单个兑换所需要消耗的积分
        /// </summary>
        [DataMember]
        public int PriceOfIntegral { get; set; }

        /// <summary>
        /// 单次单个兑换所能获得的人民币
        /// </summary>
        [DataMember]
        public double PriceOfMoney { get; set; }

        /// <summary>
        /// 总计消耗的积分
        /// </summary>
        [DataMember]
        public int SumOfIntegral { get; set; }

        /// <summary>
        /// 总计获得的人民币
        /// </summary>
        [DataMember]
        public double SumOfMoney { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的积分兑换的参与记录
        /// </summary>
        /// <param name="model">积分兑换的参与记录的数据模型</param>
        public RedeemRecordExport(RedeemRecord model)
        {
            this.Id = model.Id;
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.Plan = new RedeemSnapshotExport(model.Plan);
            this.Sum = model.Sum;
            this.PriceOfIntegral = model.PriceOfIntegral;
            this.PriceOfMoney = model.PriceOfMoney;
            this.SumOfIntegral = model.SumOfIntegral;
            this.SumOfMoney = model.SumOfMoney;
        }

        #endregion
    }
}
