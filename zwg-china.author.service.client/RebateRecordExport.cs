using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 返点记录
    /// </summary>
    [DataContract]
    public class RebateRecordExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 用户的存储指针
        /// </summary>
        [DataMember]
        public int OwnerId { get; set; }

        /// <summary>
        /// 用户的用户名
        /// </summary>
        [DataMember]
        public string Owner { get; set; }

        /// <summary>
        /// 来源用户的存储指针
        /// </summary>
        [DataMember]
        public int SourceId { get; set; }

        /// <summary>
        /// 来源用户的用户名
        /// </summary>
        [DataMember]
        public string Source { get; set; }

        /// <summary>
        /// 一个布尔值，表示该返点记录是否由直属下级触发
        /// </summary>
        [DataMember]
        public bool IsImmediate { get; set; }

        /// <summary>
        /// 游戏
        /// </summary>
        [DataMember]
        public string GameName { get; set; }

        /// <summary>
        /// 返点金额
        /// </summary>
        [DataMember]
        public double Sum { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的返点记录
        /// </summary>
        public RebateRecordExport()
        {

        }

        /// <summary>
        /// 实例化一个新的返点记录
        /// </summary>
        /// <param name="model">返点记录的数据模型</param>
        public RebateRecordExport(RebateRecord model)
        {
            this.Id = model.Id;
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.SourceId = model.Source.Id;
            this.Source = model.Source.Username;
            this.IsImmediate = model.IsImmediate;
            this.GameName = model.GameName;
            this.Sum = model.Sum;
        }

        #endregion
    }
}
