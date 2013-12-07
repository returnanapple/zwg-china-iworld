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
    /// 用于创建新的用户组的数据集
    /// </summary>
    [DataContract]
    public class CreateUserGroupImport : ImportBaseOfAuthor, IPackageForCreateModel<IModelToDbContextOfAuthor, UserGroup>
    {
        #region 属性

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
            bool hadUsedName = db.UserGroups.Any(x => x.Name == this.Name);
            if (hadUsedName)
            {
                string error = string.Format("已经存在同名的用户组（名称：{0}）", this.Name);
                throw new Exception(error);
            }
        }

        /// <summary>
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public UserGroup GetModel(IModelToDbContextOfAuthor db)
        {
            UserGroup group = new UserGroup(this.Name, this.Grade, this.LowerOfConsumption, this.CapsOfConsumption, this.TimesOfWithdrawal
                , this.MinimumWithdrawalAmount, this.MaximumWithdrawalAmount);
            return group;
        }

        #endregion
    }
}
