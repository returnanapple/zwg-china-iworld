using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 标记该方法将注册到信使服务的服务池
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class OnCallAttribute : Attribute
    {
        #region 属性

        /// <summary>
        /// 监听对象
        /// </summary>
        public Type ListenTo { get; private set; }

        /// <summary>
        /// 感兴趣的动作
        /// </summary>
        public object InterestedAction { get; private set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的服务信息
        /// </summary>
        /// <param name="listenTo">监听对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        public OnCallAttribute(Type listenTo, object interestedAction)
        {
            this.ListenTo = listenTo;
            this.InterestedAction = interestedAction;
        }

        #endregion
    }
}
