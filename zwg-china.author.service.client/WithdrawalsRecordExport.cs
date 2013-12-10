using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 提现记录
    /// </summary>
    [DataContract]
    public class WithdrawalsRecordExport
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
        /// 金额
        /// </summary>
        [DataMember]
        public double Sum { get; set; }

        /// <summary>
        /// 银行卡
        /// </summary>
        [DataMember]
        public string Card { get; set; }

        /// <summary>
        /// 银行卡的开户人
        /// </summary>
        [DataMember]
        public string HolderOfTheCard { get; set; }

        /// <summary>
        /// 银行卡的开户银行
        /// </summary>
        [DataMember]
        public Bank BankOfTheCard { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        [DataMember]
        public WithdrawalsStatus Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的充值记录
        /// </summary>
        public WithdrawalsRecordExport()
        {

        }

        /// <summary>
        /// 实例化一个新的充值记录
        /// </summary>
        /// <param name="model">充值记录的数据模型</param>
        public WithdrawalsRecordExport(WithdrawalsRecord model)
        {
            this.Id = model.Id;
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.Sum = model.Sum;
            this.Card = model.Card;
            this.HolderOfTheCard = model.HolderOfTheCard;
            this.BankOfTheCard = model.BankOfTheCard;
            this.Status = model.Status;
            this.Remark = model.Remark;
            this.CreatedTime = model.CreatedTime;
        }

        #endregion
    }
}
