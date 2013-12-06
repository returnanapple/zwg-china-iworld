using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 推广记录
    /// </summary>
    public class SpreadRecord : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 推广人
        /// </summary>
        public virtual Author Owner { get; set; }

        /// <summary>
        /// 标识码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 正常返点
        /// </summary>
        public double Rebate_Normal { get; set; }

        /// <summary>
        /// 不定位返点
        /// </summary>
        public double Rebate_IndefinitePosition { get; set; }

        /// <summary>
        /// 一个布尔值，表示该推广记录是否已经被使用
        /// </summary>
        public bool HadUsed { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的推广记录
        /// </summary>
        public SpreadRecord()
        {
        }

        /// <summary>
        /// 实例化一个新的推广记录
        /// </summary>
        /// <param name="owner">推广人</param>
        /// <param name="rebate_Normal">正常返点数</param>
        /// <param name="rebate_IndefinitePosition">不定位返点数</param>
        public SpreadRecord(Author owner, double rebate_Normal, double rebate_IndefinitePosition)
        {
            this.Owner = owner;
            this.Code = Guid.NewGuid().ToString("N");
            this.Rebate_Normal = rebate_Normal;
            this.Rebate_IndefinitePosition = rebate_IndefinitePosition;
            this.HadUsed = false;
        }

        #endregion
    }
}
