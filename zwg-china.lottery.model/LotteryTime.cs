using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 开奖时间
    /// </summary>
    public class LotteryTime : ModelBase
    {
        #region 属性

        /// <summary>
        /// 期号
        /// </summary>
        public int Issue { get; set; }

        /// <summary>
        /// 时间的值（“小时：分：秒”格式）
        /// </summary>
        public string TimeValue { get; set; }

        /// <summary>
        /// 时间（本日）
        /// </summary>
        public DateTime Time
        {
            get { return GetTime(); }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的开奖时间
        /// </summary>
        public LotteryTime()
        {
        }

        /// <summary>
        /// 实例化一个新的开奖时间
        /// </summary>
        /// <param name="issue">期号</param>
        /// <param name="timeValue">时间的值（“小时：分”格式）</param>
        public LotteryTime(int issue, string timeValue)
        {
            this.Issue = issue;
            this.TimeValue = timeValue;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 获取 DateTime 格式的时间信息（当日）
        /// </summary>
        /// <returns>返回 DateTime 格式的时间信息（当日）</returns>
        DateTime GetTime()
        {
            string[] t = TimeValue.Split(new char[] { ':', '：' });
            int tHour = Convert.ToInt32(t[0]);
            int tMinute = Convert.ToInt32(t[1]);
            int tSecond = Convert.ToInt32(t[2]);
            return new DateTime(DateTime.Now.Year
                , DateTime.Now.Month
                , DateTime.Now.Day
                , tHour
                , tMinute
                , tSecond);
        }

        #endregion
    }
}
