﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 玩法标签信息
    /// </summary>
    [DataContract]
    public class PlayTagExport
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
        /// 下辖玩法
        /// </summary>
        [DataMember]
        public virtual List<HowToPlayExport> HowToPlays { get; set; }

        /// <summary>
        /// 排序系数
        /// </summary>
        [DataMember]
        public int Order { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的玩法标签信息
        /// </summary>
        public PlayTagExport()
        {

        }

        /// <summary>
        /// 实例化一个新的玩法标签信息
        /// </summary>
        /// <param name="model">玩法标签信息的数据模型</param>
        public PlayTagExport(PlayTag model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.HowToPlays = model.HowToPlays.Where(x => x.Hide == false).ToList()
                .ConvertAll(x => new HowToPlayExport(x));
            this.Order = model.Order;
        }

        #endregion
    }
}
