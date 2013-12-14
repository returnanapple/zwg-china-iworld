using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于设置基本的系统设置的数据集
    /// </summary>
    [DataContract]
    public class SetSettingOfBaseImport : SetSettingImportBase
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

        #region 方法

        /// <summary>
        /// 设置并保存
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void SetAndSave(IModelToDbContextOfAdministrator db)
        {
            SettingOfBase setting = new SettingOfBase(db);

            setting.PageSizeForClient = this.PageSizeForClient;
            setting.PageSizeForAdmin = this.PageSizeForAdmin;
            setting.HeartbeatInterval = this.HeartbeatInterval;
            setting.WorkingHour_Begin = this.WorkingHour_Begin;
            setting.WorkingHour_End = this.WorkingHour_End;
            setting.VirtualQueuing = this.VirtualQueuing;
            setting.CollectionRunning = this.CollectionRunning;

            setting.Save(db);
        }

        #endregion
    }
}
