﻿using System;
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
    /// 用于修改密码的数据集
    /// </summary>
    [DataContract]
    public class EditPasswordImport : ImportBaseOfAuthor, IPackageForUpdateModel<IModelToDbContextOfAuthor, Author>
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
        /// 原密码
        /// </summary>
        [DataMember]
        public string OldPassword { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        [DataMember]
        public string NewPassword { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfAuthor db)
        {
            this.OldPassword = EncryptHelper.EncryptByMd5(this.OldPassword);
            if (this.Self.Password != this.OldPassword)
            {
                throw new Exception("原密码不正确");
            }
            this.NewPassword = EncryptHelper.EncryptByMd5(this.NewPassword);
        }

        /// <summary>
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        public void Update(Author model)
        {
            model.Password = this.NewPassword;
        }

        #endregion
    }
}