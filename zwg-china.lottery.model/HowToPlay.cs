using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 玩法
    /// </summary>
    public class HowToPlay : ModelBase
    {
        #region 公开属性

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所从属的玩法标签
        /// </summary>
        public virtual PlayTag Tag { get; set; }

        /// <summary>
        /// 选位下限
        /// </summary>
        public int LowerSeats { get; set; }

        /// <summary>
        /// 选位上限
        /// </summary>
        public int CapsSeats { get; set; }

        /// <summary>
        /// 赔率
        /// </summary>
        public double Odds { get; set; }

        /// <summary>
        /// 所采用的返奖接口
        /// </summary>
        public LotteryInterface Interface { get; set; }

        /// <summary>
        /// 允许自选位
        /// </summary>
        public bool AllowFreeSeats { get; set; }

        /// <summary>
        /// 有效位
        /// </summary>
        public string ValidSeats { get; set; }

        /// <summary>
        /// 可选位
        /// </summary>
        public string OptionalSeats { get; set; }

        /// <summary>
        /// 一个布尔值，表示该玩法是否为复式玩法（只在反奖接口为“任N直选”时有效）
        /// </summary>
        public bool IsDuplex { get; set; }

        /// <summary>
        /// 中奖位数（至少）（只在反奖接口为“任N组选”时有效）
        /// </summary>
        public int CountOfSeatsForWin { get; set; }

        /// <summary>
        /// 中奖的位中不同号的个数（至少）（只在反奖接口为“任N组选”时有效）
        /// </summary>
        public int LowerCountOfDifferentSeatsForWin { get; set; }


        /// <summary>
        /// 中奖的位中不同号的个数（至多）（只在反奖接口为“任N组选”时有效）
        /// </summary>
        public int CapsCountOfDifferentSeatsForWin { get; set; }

        /// <summary>
        /// 一个布尔值，表示该玩法是否对前台用户隐藏
        /// </summary>
        public bool Hide { get; set; }

        /// <summary>
        /// 排序系数
        /// </summary>
        public int Order { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的玩法
        /// </summary>
        public HowToPlay()
        {
        }

        /// <summary>
        /// 实例化一个新的玩法
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="tag">所从属的玩法标签</param>
        /// <param name="lowerSeats">选位下限</param>
        /// <param name="capsSeats">选位上限</param>
        /// <param name="odds">赔率</param>
        /// <param name="_interface">所采用的返奖接口</param>
        /// <param name="allowFreeSeats">允许自选位</param>
        /// <param name="validSeats">有效位</param>
        /// <param name="optionalSeats">可选位</param>
        /// <param name="isDuplex">一个布尔值，表示该玩法是否为复式玩法（只在反奖接口为“任N直选”时有效）</param>
        /// <param name="countOfSeatsForWin">中奖位数（至少）（只在反奖接口为“任N组选”时有效）</param>
        /// <param name="lowerCountOfDifferentSeatsForWin">中奖的位中不同号的个数（至少）（只在反奖接口为“任N组选”时有效）</param>
        /// <param name="capsCountOfDifferentSeatsForWin">中奖的位中不同号的个数（至多）（只在反奖接口为“任N组选”时有效）</param>
        /// <param name="order">排序系数</param>
        public HowToPlay(string name, PlayTag tag, int lowerSeats, int capsSeats, double odds, LotteryInterface _interface
            , bool allowFreeSeats, string validSeats, string optionalSeats, bool isDuplex, int countOfSeatsForWin
            , int lowerCountOfDifferentSeatsForWin, int capsCountOfDifferentSeatsForWin, int order)
        {
            this.Name = name;
            this.Tag = tag;
            this.LowerSeats = lowerSeats;
            this.CapsSeats = capsSeats;
            this.Odds = odds;
            this.Interface = _interface;
            this.AllowFreeSeats = allowFreeSeats;
            this.ValidSeats = validSeats;
            this.OptionalSeats = optionalSeats;
            this.IsDuplex = isDuplex;
            this.CountOfSeatsForWin = countOfSeatsForWin;
            this.LowerCountOfDifferentSeatsForWin = lowerCountOfDifferentSeatsForWin;
            this.CapsCountOfDifferentSeatsForWin = capsCountOfDifferentSeatsForWin;
            this.Hide = false;
            this.Order = order;
        }

        #endregion
    }
}
