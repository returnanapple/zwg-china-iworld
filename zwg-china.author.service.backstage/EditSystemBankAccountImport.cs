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
    /// 用于修改银行账户的数据集
    /// </summary>
    [DataContract]
    public class EditSystemBankAccountImport : ImportBaseOfAuthor, IPackageForUpdateModel<IModelToDbContextOfAuthor, SystemBankAccount>
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

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
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        public void Update(SystemBankAccount model)
        {
            model.HolderOfTheCard = this.HolderOfTheCard;
            model.Card = this.Card;
            model.BankOfTheCard = this.BankOfTheCard;
            model.Remark = this.Remark;
            model.Order = this.Order;
            model.Hide = this.Hide;
        }

        #endregion
    }
}
