using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于设置彩票相关的系统设置的数据及
    /// </summary>
    [DataContract]
    public class SetSettingOfLotteryImport : SetSettingImportBase
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

        #region 方法

        /// <summary>
        /// 设置并保存
        /// </summary>
        /// <param name="db"></param>
        public void SetAndSave(IModelToDbContextOfLottery db)
        {
            SettingOfLottery setting = new SettingOfLottery(db);

            setting.UnitPrice = this.UnitPrice;
            setting.PayoutBase = this.PayoutBase;
            setting.LineForProhibitBetting = this.LineForProhibitBetting;
            setting.MaximumPayout = this.MaximumPayout;
            setting.ConversionRates = this.ConversionRates;
            setting.MaximumBetsNumber = this.MaximumBetsNumber;
            setting.ClosureSingleTime = this.ClosureSingleTime;

            setting.Save(db);
        }

        #endregion
    }
}
