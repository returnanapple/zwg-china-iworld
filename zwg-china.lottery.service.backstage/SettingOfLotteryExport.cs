using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 彩票相关的系统设置
    /// </summary>
    [DataContract]
    public class SettingOfLotteryExport
    {
        #region 属性

        /// <summary>
        /// 单注价格
        /// </summary>
        [DataMember]
        public double UnitPrice { get; set; }

        /// <summary>
        /// 返奖基数
        /// （2 : n）
        /// </summary>
        [DataMember]
        public int PayoutBase { get; set; }

        /// <summary>
        /// 禁止投注的基数线
        /// </summary>
        [DataMember]
        public int LineForProhibitBetting { get; set; }

        /// <summary>
        /// 返奖金额上限
        /// </summary>
        [DataMember]
        public int MaximumPayout { get; set; }

        /// <summary>
        /// 奖金 - 返点换算率
        /// </summary>
        [DataMember]
        public double ConversionRates { get; set; }

        /// <summary>
        /// 最大投注倍数
        /// </summary>
        [DataMember]
        public int MaximumBetsNumber { get; set; }

        /// <summary>
        /// 封单时间（秒）
        /// </summary>
        [DataMember]
        public int ClosureSingleTime { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的彩票相关的系统设置
        /// </summary>
        /// <param name="model">彩票相关的系统设置的数据模型</param>
        public SettingOfLotteryExport(SettingOfLottery model)
        {
            this.UnitPrice = model.UnitPrice;
            this.PayoutBase = model.PayoutBase;
            this.LineForProhibitBetting = model.LineForProhibitBetting;
            this.MaximumPayout = model.MaximumPayout;
            this.ConversionRates = model.ConversionRates;
            this.MaximumBetsNumber = model.MaximumBetsNumber;
            this.ClosureSingleTime = model.ClosureSingleTime;
        }

        #endregion
    }
}
