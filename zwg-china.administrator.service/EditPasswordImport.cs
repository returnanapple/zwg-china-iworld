using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.aid;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于修改密码的数据集
    /// </summary>
    [DataContract]
    public class EditPasswordImport : ImportBaseOfAdministrator, IPackageForUpdateModel<IModelToDbContextOfAdministrator, Administrator>
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// 原密码
        /// </summary>
        [DataMember]
        public string OldPassowrd { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        [DataMember]
        public string NewPassowrd { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfAdministrator db)
        {
            this.OldPassowrd = VerifyHelper.EliminateSpaces(this.OldPassowrd);
            this.NewPassowrd = VerifyHelper.EliminateSpaces(this.NewPassowrd);
            VerifyHelper.Check(this.OldPassowrd, VerifyHelper.Key.Password);
            VerifyHelper.Check(this.NewPassowrd, VerifyHelper.Key.Password);
            this.OldPassowrd = EncryptHelper.EncryptByMd5(this.OldPassowrd);
            Administrator administrator = AdministratorLoginInfoPond.GetAdministratorInfo(db, this.Token);
            if (this.OldPassowrd != administrator.Password)
            {
                throw new Exception("原密码不正确");
            }
            this.Id = administrator.Id;
        }

        /// <summary>
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        public void Update(Administrator model)
        {
            this.NewPassowrd = EncryptHelper.EncryptByMd5(this.NewPassowrd);
            model.Password = this.NewPassowrd;
        }

        #endregion
    }
}
