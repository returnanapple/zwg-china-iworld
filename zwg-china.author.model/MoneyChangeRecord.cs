using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 帐变记录
    /// </summary>
    public class MoneyChangeRecord : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 用户
        /// </summary>
        public virtual Author Owner { get; set; }

        /// <summary>
        /// 帐变类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 收入
        /// </summary>
        public double Income { get; set; }

        /// <summary>
        /// 支出
        /// </summary>
        public double Expenses { get; set; }

        /// <summary>
        /// 实际变动
        /// </summary>
        public double Sum { get; set; }

        /// <summary>
        /// 当前余额
        /// </summary>
        public double Money { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的帐变记录
        /// </summary>
        public MoneyChangeRecord()
        {

        }

        /// <summary>
        /// 实例化一个新的帐变记录
        /// </summary>
        /// <param name="owner">用户</param>
        /// <param name="type">帐变类型</param>
        /// <param name="description">描述</param>
        /// <param name="income">收入</param>
        /// <param name="expenses">支出</param>
        public MoneyChangeRecord(Author owner, string type, string description, double income, double expenses)
        {
            this.Owner = owner;
            this.Type = type;
            this.Description = description;
            this.Income = income;
            this.Expenses = expenses;
            this.Sum = this.Income - this.Expenses;
            this.Money = this.Owner.Money + this.Sum;
        }

        #endregion
    }
}
