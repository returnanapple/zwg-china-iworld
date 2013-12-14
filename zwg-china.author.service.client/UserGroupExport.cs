using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.client
{
    /// <summary>
    /// 用户组信息
    /// </summary>
    [DataContract]
    public class UserGroupExport
    {
        #region 属性

        #region 基本信息

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [DataMember]
        public int Grade { get; set; }

        /// <summary>
        /// 消费量下限
        /// </summary>
        [DataMember]
        public double LowerOfConsumption { get; set; }

        /// <summary>
        /// 消费量上限
        /// </summary>
        [DataMember]
        public double CapsOfConsumption { get; set; }

        #endregion

        #region 权限

        /// <summary>
        /// 每日允许提现次数（如为0则采用系统参数）
        /// </summary>
        [DataMember]
        public int TimesOfWithdrawal { get; set; }

        /// <summary>
        /// 单笔最低取款金额（如为0则采用系统参数）
        /// </summary>
        [DataMember]
        public double MinimumWithdrawalAmount { get; set; }

        /// <summary>
        /// 单笔最高取款金额（如为0则采用系统参数）
        /// </summary>
        [DataMember]
        public double MaximumWithdrawalAmount { get; set; }

        #endregion

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户组信息
        /// </summary>
        public UserGroupExport()
        {

        }

        /// <summary>
        /// 实例化一个新的用户组信息
        /// </summary>
        /// <param name="model">用户组的数据模型</param>
        public UserGroupExport(UserGroup model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Grade = model.Grade;
            this.LowerOfConsumption = model.LowerOfConsumption;
            this.CapsOfConsumption = model.CapsOfConsumption;
            this.TimesOfWithdrawal = model.TimesOfWithdrawal;
            this.MinimumWithdrawalAmount = model.MinimumWithdrawalAmount;
            this.MaximumWithdrawalAmount = model.MaximumWithdrawalAmount;
        }

        #endregion
    }
}
