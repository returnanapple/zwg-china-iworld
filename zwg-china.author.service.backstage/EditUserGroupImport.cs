using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.aid;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用于修改用户组的数据集
    /// </summary>
    [DataContract]
    public class EditUserGroupImport : ImportBaseOfAuthor, IPackageForUpdateModel<IModelToDbContextOfAuthor, UserGroup>
    {
        #region 属性

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

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfAuthor db)
        {
            this.Name = VerifyHelper.EliminateSpaces(this.Name);
        }

        /// <summary>
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        public void Update(UserGroup model)
        {
            model.Name = this.Name;
            model.Grade = this.Grade;
            model.LowerOfConsumption = this.LowerOfConsumption;
            model.CapsOfConsumption = this.CapsOfConsumption;
            model.TimesOfWithdrawal = this.TimesOfWithdrawal;
            model.MinimumWithdrawalAmount = this.MinimumWithdrawalAmount;
            model.MaximumWithdrawalAmount = this.MaximumWithdrawalAmount;
        }

        #endregion
    }
}
