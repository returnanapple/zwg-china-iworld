using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace zwg_china.service
{
    /// <summary>
    /// 反馈信息
    /// </summary>
    [DataContract]
    public class NormalResult
    {
        #region 属性

        /// <summary>
        /// 一个布尔值 表示操作是否成功
        /// </summary>
        [DataMember]
        public bool Success { get; set; }

        /// <summary>
        /// 错误信息（操作成功时为空）
        /// </summary>
        [DataMember]
        public string Error { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的反馈信息（操作成功）
        /// </summary>
        public NormalResult()
        {
            this.Success = true;
            this.Error = "";
        }

        /// <summary>
        /// 实例化一个新的反馈信息（操作失败）
        /// </summary>
        /// <param name="error">错误信息</param>
        public NormalResult(string error)
        {
            this.Success = false;
            this.Error = error;
        }

        #endregion
    }

    /// <summary>
    /// 反馈信息的泛型实现
    /// </summary>
    /// <typeparam name="T">所要额外传递的信息的类型</typeparam>
    [DataContract]
    public class NormalResult<T> : NormalResult
    {
        #region 属性

        /// <summary>
        /// 额外传递的信息
        /// </summary>
        [DataMember]
        public T Info { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的反馈信息（操作成功）
        /// </summary>
        /// <param name="info">额外传递的信息</param>
        public NormalResult(T info)
        {
            this.Info = info;
        }

        /// <summary>
        /// 实例化一个新的反馈信息（操作失败）
        /// </summary>
        /// <param name="info">额外传递的信息</param>
        /// <param name="error">错误信息</param>
        public NormalResult(T info, string error)
            : base(error)
        {
            this.Info = info;
        }

        #endregion
    }
}
