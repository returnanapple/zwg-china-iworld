using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 系统基本设置
    /// </summary>
    public class SettingOfBase : SettingBase
    {
        #region 属性
        
        /// <summary>
        /// 前台页面大小（条）
        /// </summary>
        public int PageSizeForClient
        {
            get { return GetIntValue("PageSizeForClient", 12); }
            set { SetValue("PageSizeForClient", value); }
        }

        /// <summary>
        /// 后台页面大小（条）
        /// </summary>
        public int PageSizeForAdmin
        {
            get { return GetIntValue("PageSizeForAdmin", 20); }
            set { SetValue("PageSizeForAdmin", value); }
        }

        /// <summary>
        /// 心跳间隔（秒）
        /// </summary>
        public int HeartbeatInterval
        {
            get { return GetIntValue("HeartbeatInterval", 60); }
            set { SetValue("HeartbeatInterval", value); }
        }

        /// <summary>
        /// 允许取款时间 - 开始
        /// </summary>
        public string WorkingHour_Begin
        {
            get { return GetStringValue("WorkingHour_Begin", "8:00"); }
            set { SetValue("WorkingHour_Begin", value); }
        }

        /// <summary>
        /// 允许取款时间 - 结束
        /// </summary>
        public string WorkingHour_End
        {
            get { return GetStringValue("WorkingHour_End", "17:00"); }
            set { SetValue("WorkingHour_End", value); }
        }

        /// <summary>
        /// 取款虚拟排队
        /// </summary>
        public int VirtualQueuing
        {
            get { return GetIntValue("VirtualQueuing", 3); }
            set { SetValue("VirtualQueuing", value); }
        }

        /// <summary>
        /// 运行采集程序
        /// </summary>
        public bool CollectionRunning
        {
            get { return GetBooleanValue("CollectionRunning", true); }
            set { SetValue("CollectionRunning", value); }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的系统基本设置
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public SettingOfBase(IModelToDbContextOfBase db)
            : base(db)
        {

        }

        #endregion
    }
}
