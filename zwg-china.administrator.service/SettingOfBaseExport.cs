using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 基础的系统设置
    /// </summary>
    [DataContract]
    public class SettingOfBaseExport
    {
        #region 属性

        /// <summary>
        /// 前台页面大小（条）
        /// </summary>
        [DataMember]
        public int PageSizeForClient { get; set; }

        /// <summary>
        /// 后台页面大小（条）
        /// </summary>
        [DataMember]
        public int PageSizeForAdmin { get; set; }

        /// <summary>
        /// 心跳间隔（秒）
        /// </summary>
        [DataMember]
        public int HeartbeatInterval { get; set; }

        /// <summary>
        /// 允许取款时间 - 开始
        /// </summary>
        [DataMember]
        public string WorkingHour_Begin { get; set; }

        /// <summary>
        /// 允许取款时间 - 结束
        /// </summary>
        [DataMember]
        public string WorkingHour_End { get; set; }

        /// <summary>
        /// 取款虚拟排队
        /// </summary>
        [DataMember]
        public int VirtualQueuing { get; set; }

        /// <summary>
        /// 运行采集程序
        /// </summary>
        [DataMember]
        public bool CollectionRunning { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 基础的系统设置
        /// </summary>
        /// <param name="model">基础的系统设置的数据模型</param>
        public SettingOfBaseExport(SettingOfBase model)
        {
            this.PageSizeForClient = model.PageSizeForClient;
            this.PageSizeForAdmin = model.PageSizeForAdmin;
            this.HeartbeatInterval = model.HeartbeatInterval;
            this.WorkingHour_Begin = model.WorkingHour_Begin;
            this.WorkingHour_End = model.WorkingHour_End;
            this.VirtualQueuing = model.VirtualQueuing;
            this.CollectionRunning = model.CollectionRunning;
        }

        #endregion
    }
}
