﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 用户的身份绑定信息
    /// </summary>
    public class UserBinding : ModelBase
    {
        #region 属性

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
        /// 一个布尔值 表示是否已经绑定银行卡
        /// </summary>
        public bool AlreadyBindingCard { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户的身份绑定信息
        /// </summary>
        public UserBinding()
        {
            this.Card = "";
            this.HolderOfTheCard = "";
            this.BankOfTheCard = Bank.无;
            this.AlreadyBindingCard = false;
        }

        #endregion
    }
}
