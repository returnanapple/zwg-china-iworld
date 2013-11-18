using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 标记改方法将注册到信使服务的监听池
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ListenAttribute : Attribute
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

        /// <summary>
        /// 感兴趣的动作的当前执行顺序
        /// </summary>
        public ExecutionOrder InterestedOrder { get; private set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 标记改方法将注册到信使服务的监听池
        /// </summary>
        /// <param name="listenTo">监听对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        /// <param name="interestedOrder">感兴趣的动作的当前执行顺序</param>
        public ListenAttribute(Type listenTo, object interestedAction, ExecutionOrder interestedOrder)
        {
            this.ListenTo = listenTo;
            this.InterestedAction = interestedAction;
            this.InterestedOrder = interestedOrder;
        }

        #endregion
    }
}
