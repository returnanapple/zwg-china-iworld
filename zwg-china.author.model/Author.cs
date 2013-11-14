using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class Author : CategoryModelBase
    {
        #region 属性

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 资金密码
        /// </summary>
        public string FundsCode { get; set; }

        /// <summary>
        /// 安全码
        /// </summary>
        public string SafeCode { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 上次登录的网络地址
        /// </summary>
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 绑定信息
        /// </summary>
        public virtual UserBinding Binding { get; set; }

        /// <summary>
        /// 游戏资料
        /// </summary>
        public virtual UserPlayInfo PlayInfo { get; set; }

        /// <summary>
        /// 统计数据
        /// </summary>
        public virtual UserData Data { get; set; }

        /// <summary>
        /// 额外的高点号配额
        /// </summary>
        public virtual List<ExtraQuota> ExtraQuotas { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户信息
        /// </summary>
        public Author()
        {
        }

        /// <summary>
        /// 实例化一个新的用户信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="playInfo">游戏资料</param>
        /// <param name="relatives">父祖节点</param>
        /// <param name="tree">所从属的树</param>
        public Author(string username, string password, UserPlayInfo playInfo, List<Relative> relatives, string tree)
            : base(relatives, tree)
        {
            this.Username = username;
            this.Password = password;
            this.FundsCode = "未设置";
            this.SafeCode = "未设置";
            this.PlayInfo = playInfo;
            this.Status = UserStatus.未激活;
            this.LastLoginIp = "从未登陆";
            this.LastLoginTime = DateTime.Now;
            this.Data = new UserData();
            this.Binding = new UserBinding();
            this.ExtraQuotas = new List<ExtraQuota>();
        }

        #endregion
    }
}
