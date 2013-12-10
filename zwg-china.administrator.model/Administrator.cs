using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class Administrator : RecordingTimeModelBase
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
        /// 用户组
        /// </summary>
        public virtual AdministratorGroup Group { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 上次登录的网络地址
        /// </summary>
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 上次登录的实际地址
        /// </summary>
        public string LastLoginAddress { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的管理员
        /// </summary>
        public Administrator()
        {
        }

        /// <summary>
        /// 实例化一个新的管理员
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="group">用户组</param>
        public Administrator(string username, string password, AdministratorGroup group)
        {
            this.Username = username;
            this.Password = password;
            this.Group = group;
            this.LastLoginTime = DateTime.Now;
            this.LastLoginIp = "从未登陆";
            this.LastLoginAddress = "从未登陆";
        }

        #endregion

        #region 方法

        /// <summary>
        /// 声明用户已经登录
        /// </summary>
        /// <param name="ip">网络地址</param>
        /// <param name="address">实际地址</param>
        public void OnLogin(string ip, string address)
        {
            this.LastLoginIp = ip;
            this.LastLoginAddress = address;
            this.LastLoginTime = DateTime.Now;
        }

        #endregion
    }
}
