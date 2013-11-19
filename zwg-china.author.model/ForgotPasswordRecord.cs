using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 找回密码记录
    /// </summary>
    public class ForgotPasswordRecord : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 用户
        /// </summary>
        public virtual Author Owner { get; set; }

        /// <summary>
        /// 标识码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 一个布尔值，表示该找回密码记录是否已经被使用
        /// </summary>
        public bool HadUsed { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的找回密码记录
        /// </summary>
        public ForgotPasswordRecord()
        {

        }

        /// <summary>
        /// 实例化一个新的找回密码记录
        /// </summary>
        /// <param name="owner">用户</param>
        /// <param name="code">标识码</param>
        /// <param name="hadUsed">一个布尔值，表示该找回密码记录是否已经被使用</param>
        public ForgotPasswordRecord(Author owner, string code, bool hadUsed)
        {
            this.Owner = owner;
            this.Code = code;
            this.HadUsed = hadUsed;
        }

        #endregion
    }
}
