using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 银行账号
    /// </summary>
    [DataContract]
    public class SystemBankAccountExport
    {
        #region 属性

        /// <summary>
        /// 开户人
        /// </summary>
        [DataMember]
        public string HolderOfTheCard { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        [DataMember]
        public string Card { get; set; }

        /// <summary>
        /// 银行
        /// </summary>
        [DataMember]
        public Bank BankOfTheCard { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

        /// <summary>
        /// 排列系数
        /// </summary>
        [DataMember]
        public int Order { get; set; }

        /// <summary>
        /// 一个布尔值 表示该对象是否隐藏
        /// </summary>
        [DataMember]
        public bool Hide { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的银行账号
        /// </summary>
        public SystemBankAccountExport()
        {

        }

        /// <summary>
        /// 实例化一个新的银行账号
        /// </summary>
        /// <param name="model">银行账号的数据模型</param>
        public SystemBankAccountExport(SystemBankAccount model)
        {
            this.HolderOfTheCard = model.HolderOfTheCard;
            this.Card = model.Card;
            this.BankOfTheCard = model.BankOfTheCard;
            this.Remark = model.Remark;
            this.Order = model.Order;
            this.Hide = model.Hide;
        }

        #endregion
    }
}
