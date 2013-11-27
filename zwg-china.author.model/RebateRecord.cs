using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 返点记录
    /// </summary>
    public class RebateRecord : RecordingTimeModelBase
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
        /// 游戏
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// 返点金额
        /// </summary>
        public double Sum { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的返点记录
        /// </summary>
        public RebateRecord()
        {

        }

        /// <summary>
        /// 实例化一个新的返点记录
        /// </summary>
        /// <param name="owner">用户</param>
        /// <param name="source">来源</param>
        /// <param name="isImmediate">一个布尔值，表示该返点记录是否由直属下级触发</param>
        /// <param name="gameName">游戏</param>
        /// <param name="sum">返点金额</param>
        public RebateRecord(Author owner, Author source, bool isImmediate, string gameName, double sum)
        {
            this.Owner = owner;
            this.Source = source;
            this.IsImmediate = isImmediate;
            this.GameName = gameName;
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
            string result = string.Format("来源于用户 {0}{1}，游戏：{2}"
                , this.Source.Username
                , this.IsImmediate ? "" : " 的下级"
                , this.GameName);
            return result;
        }

        #endregion
    }
}
