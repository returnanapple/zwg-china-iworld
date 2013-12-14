using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 分红记录
    /// </summary>
    [DataContract]
    public class DividendRecordExport
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
        /// 标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 下线盈亏
        /// </summary>
        [DataMember]
        public double Profit { get; set; }

        /// <summary>
        /// 分红比例
        /// </summary>
        [DataMember]
        public double Scale { get; set; }

        /// <summary>
        /// 分红金额
        /// </summary>
        [DataMember]
        public double Sum { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public DividendStatus Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的分红记录
        /// </summary>
        public DividendRecordExport()
        {

        }

        /// <summary>
        /// 实例化一个新的分红记录
        /// </summary>
        /// <param name="model">分红记录的数据模型</param>
        public DividendRecordExport(DividendRecord model)
        {
            this.Id = model.Id;
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.Title = model.Title;
            this.Profit = model.Profit;
            this.Scale = model.Scale;
            this.Sum = model.Sum;
            this.Status = model.Status;
            this.Remark = model.Remark;
            this.CreatedTime = model.CreatedTime;
        }

        #endregion
    }
}
