using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.aid;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.client
{
    /// <summary>
    /// 用于绑定用户初始信息的数据集
    /// </summary>
    [DataContract]
    public class BindingUserInfoImport : ImportBaseOfAuthor, IPackageForUpdateModel<IModelToDbContextOfAuthor, Author>
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
        /// 旧密码
        /// </summary>
        [DataMember]
        public string OldPassword { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        [DataMember]
        public string NewPassword { get; set; }

        /// <summary>
        /// 资金密码
        /// </summary>
        [DataMember]
        public string FundsCode { get; set; }

        /// <summary>
        /// 安全码
        /// </summary>
        [DataMember]
        public string SafeCode { get; set; }

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

            VerifyHelper.EliminateSpaces(this.OldPassword);
            VerifyHelper.EliminateSpaces(this.NewPassword);
            VerifyHelper.EliminateSpaces(this.FundsCode);
            VerifyHelper.EliminateSpaces(this.SafeCode);
            VerifyHelper.EliminateSpaces(this.HolderOfTheCard);
            VerifyHelper.EliminateSpaces(this.Card);
            VerifyHelper.Check(this.OldPassword, VerifyHelper.Key.Password);
            VerifyHelper.Check(this.NewPassword, VerifyHelper.Key.Password);
            VerifyHelper.Check(this.FundsCode, VerifyHelper.Key.Password);
            VerifyHelper.Check(this.SafeCode, VerifyHelper.Key.Password);

            this.OldPassword = EncryptHelper.EncryptByMd5(this.OldPassword);
            if (this.Self.Password != this.OldPassword)
            {
                throw new Exception("原密码不正确");
            }
            this.NewPassword = EncryptHelper.EncryptByMd5(this.NewPassword);
            this.FundsCode = EncryptHelper.EncryptByMd5(this.FundsCode);
            this.SafeCode = EncryptHelper.EncryptByMd5(this.SafeCode);
        }

        /// <summary>
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        public void Update(Author model)
        {
            model.Password = this.NewPassword;
            model.FundsCode = this.FundsCode;
            model.SafeCode = this.SafeCode;
            model.Binding.Card = this.Card;
            model.Binding.HolderOfTheCard = this.HolderOfTheCard;
            model.Binding.BankOfTheCard = this.BankOfTheCard;
            model.Binding.AlreadyBindingCard = true;
        }

        #endregion
    }
}
