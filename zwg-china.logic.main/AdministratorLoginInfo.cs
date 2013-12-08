using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.logic
{
    /// <summary>
    /// 管理员的登陆信息
    /// </summary>
    public class AdministratorLoginInfo
    {
        #region 属性

        /// <summary>
        /// 身份标识
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 管理员信息的存储指针
        /// </summary>
        public int AdministratorId { get; set; }

        /// <summary>
        /// 登陆时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public DateTime Timeout { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的管理员的登陆信息
        /// </summary>
        /// <param name="db">数据库存储指针</param>
        /// <param name="administratorId">管理员信息的存储指针</param>
        public AdministratorLoginInfo(IModelToDbContextOfAdministrator db, int administratorId)
        {
            SettingOfBase setting = new SettingOfBase(db);
            int s = setting.HeartbeatInterval * 3;

            this.Token = Guid.NewGuid().ToString("N");
            this.AdministratorId = administratorId;
            this.LoginTime = DateTime.Now;
            this.Timeout = this.LoginTime.AddSeconds(s);
        }

        #endregion

        #region 方法

        /// <summary>
        /// 超时
        /// </summary>
        /// <param name="now">当前时间</param>
        /// <returns>返回一个布尔值，表示信息是否已经超时</returns>
        public bool IsTimeout(DateTime now)
        {
            return this.Timeout < now;
        }

        /// <summary>
        /// 保持心跳
        /// </summary>
        /// <param name="db">数据库存储指针</param>
        public void KeepHeartbeat(IModelToDbContextOfAdministrator db)
        {
            SettingOfBase setting = new SettingOfBase(db);
            int s = setting.HeartbeatInterval * 3;

            this.Timeout = DateTime.Now.AddSeconds(s);
        }

        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <param name="db">数据库存储指针</param>
        /// <returns>返回管理员信息</returns>
        public Administrator GetUser(IModelToDbContextOfAdministrator db)
        {
            return db.Administrators.Find(this.AdministratorId);
        }

        #endregion
    }
}
