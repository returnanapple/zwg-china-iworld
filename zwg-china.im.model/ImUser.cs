using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 用户信息（IM）
    /// </summary>
    /// <typeparam name="T">所采用的回调的类型</typeparam>
    public class ImUser<T>
    {
        #region 私有字段

        /// <summary>
        /// 用户在线状态保持时间（1）
        /// </summary>
        int timeForKeepStatus = 1;

        #endregion

        #region 属性

        /// <summary>
        /// 对应的用户的存储指针
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 上级用户的存储指针（如为0表示自身已经是顶级用户）（如为-1表示自身是客服）
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        public ImUserType UserType
        {
            get { return this.ParentId == 0 ? ImUserType.客服 : ImUserType.普通用户; }
        }

        /// <summary>
        /// 在线状态
        /// </summary>
        public ImOnlineStatus OnlineStatus { get; set; }

        /// <summary>
        /// 登入时间
        /// </summary>
        public DateTime SetInTime { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public DateTime Timeout { get; set; }

        /// <summary>
        /// 自己的标识码
        /// </summary>
        public string TokenOfSelf { get; set; }

        /// <summary>
        /// 当前关注的用户的标识码
        /// </summary>
        public string TokenOfFollow { get; set; }

        /// <summary>
        /// 对应回调
        /// </summary>
        public T Callback { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户信息（IM）
        /// </summary>
        /// <param name="userId">对应的用户的存储指针</param>
        /// <param name="parentId">上级用户的存储指针（如为0表示自身已经是顶级用户）（如为-1表示自身是客服）</param>
        /// <param name="username">用户名</param>
        /// <param name="tokenOfSelf">自己的标识码</param>
        /// <param name="callback">对应回调</param>
        public ImUser(int userId, int parentId, string username, string tokenOfSelf, T callback)
        {
            this.UserId = userId;
            this.ParentId = parentId;
            this.Username = username;
            this.OnlineStatus = ImOnlineStatus.在线;
            this.SetInTime = DateTime.Now;
            this.Timeout = this.SetInTime.AddMinutes(timeForKeepStatus);
            this.TokenOfSelf = tokenOfSelf;
            this.TokenOfFollow = "";
            this.Callback = callback;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 检查令牌是否已经过期
        /// </summary>
        public void CheckIfTimeOut()
        {
            if (this.Timeout > DateTime.Now) { return; }
            if (TimeoutEventHandler == null) { return; }
            TimeoutEventHandler(this, new EventArgs());
        }

        /// <summary>
        /// 保持心跳
        /// </summary>
        public void KeepHeartbeat()
        {
            this.Timeout = DateTime.Now.AddMinutes(timeForKeepStatus);
        }

        #endregion

        #region 事件

        /// <summary>
        /// 通知订阅者改用户的登陆已经过期
        /// </summary>
        public event EventHandler TimeoutEventHandler;

        #endregion
    }
}
