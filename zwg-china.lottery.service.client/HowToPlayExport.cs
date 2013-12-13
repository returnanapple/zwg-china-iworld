using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 玩法信息
    /// </summary>
    [DataContract]
    public class HowToPlayExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 选位下限
        /// </summary>
        [DataMember]
        public int LowerSeats { get; set; }

        /// <summary>
        /// 选位上限
        /// </summary>
        [DataMember]
        public int CapsSeats { get; set; }

        /// <summary>
        /// 赔率
        /// </summary>
        [DataMember]
        public double Odds { get; set; }

        /// <summary>
        /// 所采用的返奖接口
        /// </summary>
        [DataMember]
        public LotteryInterface Interface { get; set; }

        /// <summary>
        /// 允许自选位
        /// </summary>
        [DataMember]
        public bool AllowFreeSeats { get; set; }

        /// <summary>
        /// 可选位
        /// </summary>
        [DataMember]
        public string OptionalSeats { get; set; }

        /// <summary>
        /// 一个布尔值，表示该玩法是否为复式玩法（只在反奖接口为“任N直选”时有效）
        /// </summary>
        [DataMember]
        public bool IsDuplex { get; set; }

        /// <summary>
        /// 中奖位数（至少）（只在反奖接口为“任N组选”时有效）
        /// </summary>
        [DataMember]
        public int CountOfSeatsForWin { get; set; }

        /// <summary>
        /// 排序系数
        /// </summary>
        [DataMember]
        public int Order { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的玩法信息
        /// </summary>
        public HowToPlayExport()
        {

        }

        /// <summary>
        /// 实例化一个新的玩法信息
        /// </summary>
        /// <param name="model">玩法信息的数据模型</param>
        public HowToPlayExport(HowToPlay model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.LowerSeats = model.LowerSeats;
            this.CapsSeats = model.CapsSeats;
            this.Odds = model.Odds;
            this.Interface = model.Interface;
            this.AllowFreeSeats = model.AllowFreeSeats;
            this.OptionalSeats = model.OptionalSeats;
            this.IsDuplex = model.IsDuplex;
            this.CountOfSeatsForWin = model.CountOfSeatsForWin;
            this.Order = model.Order;
        }

        #endregion
    }
}
