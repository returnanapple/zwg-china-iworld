using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.client
{
    /// <summary>
    /// 基本的自身数据信息
    /// </summary>
    [DataContract]
    public class BasicSelfInfoExport
    {
        #region 属性

        /// <summary>
        /// 现金余额
        /// </summary>
        [DataMember]
        public double Money { get; set; }

        /// <summary>
        /// 被冻结的现金总额
        /// </summary>
        [DataMember]
        public double Money_Frozen { get; set; }

        /// <summary>
        /// 消费量
        /// </summary>
        [DataMember]
        public double Consumption { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        [DataMember]
        public double Integral { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的基本的自身数据信息
        /// </summary>
        public BasicSelfInfoExport()
        {

        }

        /// <summary>
        /// 实例化一个新的基本的自身数据信息
        /// </summary>
        /// <param name="model">用户信息的数据模型</param>
        public BasicSelfInfoExport(Author model)
        {
            this.Money = model.Money;
            this.Money_Frozen = model.Money_Frozen;
            this.Consumption = model.Consumption;
            this.Integral = model.Integral;
        }

        #endregion
    }
}
