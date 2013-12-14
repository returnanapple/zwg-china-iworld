using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用户的游戏资料
    /// </summary>
    [DataContract]
    public class UserPlayInfoExport
    {
        #region 属性

        /// <summary>
        /// 正常返点
        /// </summary>
        [DataMember]
        public double Rebate_Normal { get; set; }

        /// <summary>
        /// 不定位返点
        /// </summary>
        [DataMember]
        public double Rebate_IndefinitePosition { get; set; }

        /// <summary>
        /// 一级佣金（如果为0则采用系统设置）
        /// </summary>
        [DataMember]
        public double Commission_A { get; set; }

        /// <summary>
        /// 二级佣金（如果为0则采用系统设置）
        /// </summary>
        [DataMember]
        public double Commission_B { get; set; }

        /// <summary>
        /// 分红（百分比）（如果为0则采用系统设置）
        /// </summary>
        [DataMember]
        public double Dividend { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户的游戏资料
        /// </summary>
        public UserPlayInfoExport()
        {

        }

        /// <summary>
        /// 实例化一个新的用户的游戏资料
        /// </summary>
        /// <param name="model">用户的游戏资料的数据模型</param>
        public UserPlayInfoExport(UserPlayInfo model)
        {
            this.Rebate_Normal = model.Rebate_Normal;
            this.Rebate_IndefinitePosition = model.Rebate_IndefinitePosition;
            this.Commission_A = model.Commission_A;
            this.Commission_B = model.Commission_B;
            this.Dividend = model.Dividend;
        }

        #endregion
    }
}
