using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.client
{
    /// <summary>
    /// 中奖排行信息
    /// </summary>
    [DataContract]
    public class TopBonus
    {
        #region 属性

        /// <summary>
        /// 期号
        /// </summary>
        [DataMember]
        public string Issue { get; set; }

        /// <summary>
        /// 中奖金额
        /// </summary>
        [DataMember]
        public double Sum { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的中奖排行信息
        /// </summary>
        /// <param name="model">中奖排行信息的数据模型</param>
        public TopBonus(VirtualBonus model)
        {
            string t1 = (model.Id / 1000000).ToString("00");
            string t2 = (model.Id % 100).ToString("00");
            this.Issue = string.Format("{0}****{1}", t1, t2);
            this.Sum = model.Sum;
        }

        /// <summary>
        /// 实例化一个新的中奖排行信息
        /// </summary>
        /// <param name="model">中奖排行信息的数据模型</param>
        public TopBonus(Betting model)
        {
            string t1 = (model.Id / 1000000).ToString("00");
            string t2 = (model.Id % 100).ToString("00");
            this.Issue = string.Format("{0}****{1}", t1, t2);
            this.Sum = model.Bonus;
        }

        /// <summary>
        /// 实例化一个新的中奖排行信息
        /// </summary>
        /// <param name="model">中奖排行信息的数据模型</param>
        public TopBonus(BettingWithChasing model)
        {
            string t1 = (model.Id / 1000000).ToString("00");
            string t2 = (model.Id % 100).ToString("00");
            this.Issue = string.Format("{0}****{1}", t1, t2);
            this.Sum = model.Bonus;
        }

        #endregion
    }
}
