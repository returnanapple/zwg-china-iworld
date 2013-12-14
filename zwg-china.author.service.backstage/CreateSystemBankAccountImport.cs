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
    /// 用于创建银行账户的
    /// </summary>
    [DataContract]
    public class CreateSystemBankAccountImport : ImportBaseOfAuthor, IPackageForCreateModel<IModelToDbContextOfAuthor, SystemBankAccount>
    {
        #region 属性

        /// <summary>
        /// 开户人
        /// </summary>
        [DataMember]
        public string HolderOfTheCard { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        [DataMember]
        public string Card { get; set; }

        /// <summary>
        /// 银行
        /// </summary>
        [DataMember]
        public Bank BankOfTheCard { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

        /// <summary>
        /// 排列系数
        /// </summary>
        [DataMember]
        public int Order { get; set; }

        /// <summary>
        /// 一个布尔值 表示该对象是否隐藏
        /// </summary>
        [DataMember]
        public bool Hide { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfAuthor db)
        {
        }

        /// <summary>
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public SystemBankAccount GetModel(IModelToDbContextOfAuthor db)
        {
            return new SystemBankAccount(this.HolderOfTheCard, this.Card, this.BankOfTheCard, this.Remark, this.Order, this.Hide);
        }

        #endregion
    }
}
