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
    /// 用于修改资金密码的数据集
    /// </summary>
    [DataContract]
    public class EditFundsCodeImport : ImportBaseOfAuthor, IPackageForUpdateModel<IModelToDbContextOfAuthor, Author>
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
        /// 原资金密码
        /// </summary>
        [DataMember]
        public string OldFundsCode { get; set; }

        /// <summary>
        /// 新资金密码
        /// </summary>
        [DataMember]
        public string NewFundsCode { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfAuthor db)
        {
            this.OldFundsCode = EncryptHelper.EncryptByMd5(this.OldFundsCode);
            if (this.Self.FundsCode != this.OldFundsCode)
            {
                throw new Exception("原资金密码不正确");
            }
            this.NewFundsCode = EncryptHelper.EncryptByMd5(this.NewFundsCode);
        }

        /// <summary>
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        public void Update(Author model)
        {
            model.FundsCode = this.NewFundsCode;
        }

        #endregion
    }
}
