﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 亲族节点信息（适用于树状结构）
    /// </summary>
    public class Relative : ModelBase
    {
        #region 属性

        /// <summary>
        /// 节点所对应的对象的存储指针
        /// </summary>
        public int NodeId { get; set; }

        /// <summary>
        /// 节点所对应的对象的层级
        /// </summary>
        public int NodeLayer { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的亲族节点
        /// </summary>
        public Relative()
        {
        }

        /// <summary>
        /// 实例化一个新的亲族节点
        /// </summary>
        /// <param name="nodeId">节点所对应的对象的存储指针</param>
        /// <param name="nodeLayer">节点所对应的对象的层级</param>
        public Relative(int nodeId, int nodeLayer)
        {
            this.NodeId = nodeId;
            this.NodeLayer = nodeLayer;
        }

        #endregion
    }
}
