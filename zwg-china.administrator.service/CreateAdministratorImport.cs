using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.aid;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用于创建新的管理员的数据集
    /// </summary>
    [DataContract]
    public class CreateAdministratorImport : ImportBaseOfAdministrator, IPackageForCreateModel<IModelToDbContextOfAdministrator, Administrator>
    {
        #region 属性

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// 所从属的管理员组的存储指针
        /// </summary>
        [DataMember]
        public int GroupId { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfAdministrator db)
        {
            #region 检查用户名和密码格式是否合法
            this.Username = VerifyHelper.EliminateSpaces(this.Username);
            this.Password = VerifyHelper.EliminateSpaces(this.Password);
            VerifyHelper.Check(this.Username, VerifyHelper.Key.Nickname);
            VerifyHelper.Check(this.Password, VerifyHelper.Key.Password);
            #endregion
            bool hadUsedUsername = db.Administrators.Any(x => x.Username == this.Username);
            if (hadUsedUsername)
            {
                string error = string.Format("用户名 {0} 已经被使用", this.Username);
                throw new Exception(error);
            }
        }

        /// <summary>
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public Administrator GetModel(IModelToDbContextOfAdministrator db)
        {
            string password = EncryptHelper.EncryptByMd5(this.Password);
            AdministratorGroup group = db.AdministratorGroups.Find(this.GroupId);
            return new Administrator(this.Username, password, group);
        }

        #endregion
    }
}
