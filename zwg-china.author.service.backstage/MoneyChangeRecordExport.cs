using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 帐变记录
    /// </summary>
    [DataContract]
    public class MoneyChangeRecordExport
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
        /// 帐变类型
        /// </summary>
        [DataMember]
        public string Type { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 收入
        /// </summary>
        [DataMember]
        public double Income { get; set; }

        /// <summary>
        /// 支出
        /// </summary>
        [DataMember]
        public double Expenses { get; set; }

        /// <summary>
        /// 实际变动
        /// </summary>
        [DataMember]
        public double Sum { get; set; }

        /// <summary>
        /// 当前余额
        /// </summary>
        [DataMember]
        public double Money { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的帐变记录
        /// </summary>
        public MoneyChangeRecordExport()
        {

        }

        /// <summary>
        /// 实例化一个新的帐变记录
        /// </summary>
        /// <param name="model">帐变记录的数据模型</param>
        public MoneyChangeRecordExport(MoneyChangeRecord model)
        {
            this.Id = model.Id;
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.Type = model.Type;
            this.Description = model.Description;
            this.Income = model.Income;
            this.Expenses = model.Expenses;
            this.Sum = model.Sum;
            this.Money = model.Money;
            this.CreatedTime = model.CreatedTime;
        }

        #endregion
    }
}
