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
    /// 用于修改绑定信息的数据集
    /// </summary>
    [DataContract]
    public class EditBankImport : ImportBaseOfAuthor, IPackageForUpdateModel<IModelToDbContextOfAuthor, Author>
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        public int Id
        {
            get
            {
                if (this.Self == null) { return 0; }
                return this.Self.Id;
            }
        }

        /// <summary>
        /// 开户人
        /// </summary>
        [DataMember]
        public string HolderOfTheCard { get; set; }

        /// <summary>
        /// 银行卡
        /// </summary>
        [DataMember]
        public string Card { get; set; }

        /// <summary>
        /// 银行
        /// </summary>
        [DataMember]
        public Bank BankOfTheCard { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfAuthor db)
        {
            if (this.Self.Binding.AlreadyBindingCard)
            {
                throw new Exception("用户资料已经绑定，请勿重复操作");
            }
            VerifyHelper.EliminateSpaces(this.HolderOfTheCard);
            VerifyHelper.EliminateSpaces(this.Card);
        }

        /// <summary>
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        public void Update(Author model)
        {
            model.Binding.Card = this.Card;
            model.Binding.HolderOfTheCard = this.HolderOfTheCard;
            model.Binding.BankOfTheCard = this.BankOfTheCard;
            model.Binding.AlreadyBindingCard = true;
        }

        #endregion
    }
}
