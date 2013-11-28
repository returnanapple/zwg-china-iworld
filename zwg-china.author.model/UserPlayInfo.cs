using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 用户的游戏资料
    /// </summary>
    public class UserPlayInfo : ModelBase
    {
        #region 属性

        /// <summary>
        /// 正常返点
        /// </summary>
        public double Rebate_Normal { get; set; }

        /// <summary>
        /// 不定位返点
        /// </summary>
        public double Rebate_IndefinitePosition { get; set; }

        /// <summary>
        /// 一级佣金（如果为0则采用系统设置）
        /// </summary>
        public double Commission_A { get; set; }

        /// <summary>
        /// 二级佣金（如果为0则采用系统设置）
        /// </summary>
        public double Commission_B { get; set; }

        /// <summary>
        /// 分红（百分比）（如果为0则采用系统设置）
        /// </summary>
        public double Dividend { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户的游戏资料
        /// </summary>
        public UserPlayInfo()
        {
        }

        /// <summary>
        /// 实例化一个新的用户的游戏资料
        /// </summary>
        /// <param name="rebate_Normal">正常返点</param>
        /// <param name="rebate_IndefinitePosition">不定位返点</param>
        /// <param name="commission_A">一级佣金</param>
        /// <param name="commission_B">二级佣金</param>
        /// <param name="dvidend">分红（百分比）</param>
        public UserPlayInfo(double rebate_Normal, double rebate_IndefinitePosition, double commission_A, double commission_B, double dvidend)
        {
            this.Rebate_Normal = rebate_Normal;
            this.Rebate_IndefinitePosition = rebate_IndefinitePosition;
            this.Commission_A = commission_A;
            this.Commission_B = commission_B;
            this.Dividend = dvidend;
        }

        #endregion
    }
}
