﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 佣金记录
    /// </summary>
    public class CommissionRecord : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 用户
        /// </summary>
        public virtual Author Owner { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public virtual Author Source { get; set; }

        /// <summary>
        /// 一个布尔值，表示该返点记录是否由直属下级触发
        /// </summary>
        public bool IsImmediate { get; set; }

        /// <summary>
        /// 返点金额
        /// </summary>
        public double Sum { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的佣金记录
        /// </summary>
        public CommissionRecord()
        {

        }

        /// <summary>
        /// 实例化一个新的佣金记录
        /// </summary>
        /// <param name="owner">用户</param>
        /// <param name="source">来源</param>
        /// <param name="isImmediate">一个布尔值，表示该返点记录是否由直属下级触发</param>
        /// <param name="sum">返点金额</param>
        public CommissionRecord(Author owner, Author source, bool isImmediate, double sum)
        {
            this.Owner = owner;
            this.Source = source;
            this.IsImmediate = isImmediate;
            this.Sum = sum;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取相关描述
        /// </summary>
        /// <returns>返回相关描述</returns>
        public string GetDescription()
        {
            string result = string.Format("来源于用户 {0}{1}"
                , this.Source.Username
                , this.IsImmediate ? "" : " 的下级");
            return result;
        }

        #endregion
    }
}
