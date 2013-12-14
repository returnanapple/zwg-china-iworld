using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用户的身份绑定信息
    /// </summary>
    [DataContract]
    public class UserBindingExport
    {
        #region 属性

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
        /// 一个布尔值 表示是否已经绑定银行卡
        /// </summary>
        [DataMember]
        public bool AlreadyBindingCard { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户的身份绑定信息
        /// </summary>
        public UserBindingExport()
        {

        }

        /// <summary>
        /// 实例化一个新的用户的身份绑定信息
        /// </summary>
        /// <param name="model">用户的身份绑定信息的数据模型</param>
        public UserBindingExport(UserBinding model)
        {
            this.Card = model.Card;
            this.HolderOfTheCard = model.HolderOfTheCard;
            this.BankOfTheCard = model.BankOfTheCard;
            this.AlreadyBindingCard = model.AlreadyBindingCard;
        }

        #endregion
    }
}
