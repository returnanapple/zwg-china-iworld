using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 彩票相关的系统设置
    /// </summary>
    public class SettingOfLottery : SettingBase
    {
        #region 属性

        /// <summary>
        /// 单注价格
        /// </summary>
        public double UnitPrice
        {
            get { return GetDoubleValue("UnitPrice", 2); }
            set { SetValue("UnitPrice", value); }
        }

        /// <summary>
        /// 返奖基数
        /// （2 : n）
        /// </summary>
        public int PayoutBase
        {
            get { return GetIntValue("PayoutBase", 1700); }
            set { SetValue("PayoutBase", value); }
        }

        /// <summary>
        /// 禁止投注的基数线
        /// </summary>
        public int LineForProhibitBetting
        {
            get { return GetIntValue("LineForProhibitBetting", 1950); }
            set { SetValue("LineForProhibitBetting", value); }
        }

        /// <summary>
        /// 返奖金额上限
        /// </summary>
        public int MaximumPayout
        {
            get { return GetIntValue("MaximumPayout", 100000); }
            set { SetValue("MaximumPayout", value); }
        }

        /// <summary>
        /// 奖金 - 返点换算率
        /// </summary>
        public double ConversionRates
        {
            get { return GetDoubleValue("ConversionRates", 20); }
            set { SetValue("ConversionRates", value); }
        }

        /// <summary>
        /// 最大投注倍数
        /// </summary>
        public int MaximumBetsNumber
        {
            get { return GetIntValue("MaximumBetsNumber", 12); }
            set { SetValue("MaximumBetsNumber", value); }
        }

        /// <summary>
        /// 封单时间（秒）
        /// </summary>
        public int ClosureSingleTime
        {
            get { return GetIntValue("ClosureSingleTime", 30); }
            set { SetValue("ClosureSingleTime", value); }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个彩票相关的系统设置
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public SettingOfLottery(IModelToDbContextOfBase db)
            : base(db)
        {

        }

        #endregion
    }
}
