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
        /// 赔率
        /// </summary>
        [DataMember]
        public double Odds { get; set; }

        /// <summary>
        /// 一个布尔值，表示该玩法是否对前台用户隐藏
        /// </summary>
        [DataMember]
        public bool Hide { get; set; }

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
            this.Odds = model.Odds;
            this.Hide = model.Hide;
            this.Order = model.Order;
        }

        #endregion
    }
}
