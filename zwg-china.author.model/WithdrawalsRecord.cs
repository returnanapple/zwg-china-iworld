using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 提现记录
    /// </summary>
    public class WithdrawalsRecord : RecordingTimeModelBase
    {
        #region 公开属性

        /// <summary>
        /// 申请人
        /// </summary>
        public virtual Author Owner { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public double Sum { get; set; }

        /// <summary>
        /// 银行卡
        /// </summary>
        public string Card { get; set; }

        /// <summary>
        /// 银行卡的开户人
        /// </summary>
        public string HolderOfTheCard { get; set; }

        /// <summary>
        /// 银行卡的开户银行
        /// </summary>
        public Bank BankOfTheCard { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        public WithdrawalsStatus Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的提现记录
        /// </summary>
        public WithdrawalsRecord()
        {
        }

        /// <summary>
        /// 实例化一个新的提现记录
        /// </summary>
        /// <param name="owner">申请人</param>
        /// <param name="sum">金额</param>
        /// <param name="card">目标银行卡的卡号</param>
        /// <param name="holderOfTheCard">目标银行卡的开户人姓名</param>
        /// <param name="bankOfTheCard">目标银行卡的开户银行</param>
        public WithdrawalsRecord(Author owner, double sum, string card, string holderOfTheCard, Bank bankOfTheCard)
        {
            this.Owner = owner;
            this.Sum = sum;
            this.Card = card;
            this.HolderOfTheCard = holderOfTheCard;
            this.BankOfTheCard = bankOfTheCard;
            this.Status = WithdrawalsStatus.等待处理;
            this.Remark = "";
        }

        #endregion
    }
}
