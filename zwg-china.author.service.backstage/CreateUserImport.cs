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
    /// 用于创建用户的数据集
    /// </summary>
    [DataContract]
    public class CreateUserImport : IPackageForCreateModel<Author>
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
        /// 游戏资料
        /// </summary>
        [DataMember]
        public virtual CreateUserPlayInfoImport PlayInfo { get; set; }

        /// <summary>
        /// 上级用户的存储指针
        /// </summary>
        [DataMember]
        public int? ParentId { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContext db)
        {
            this.Username = VerifyHelper.EliminateSpaces(this.Username);
            this.Password = VerifyHelper.EliminateSpaces(this.Password);
            VerifyHelper.Check(this.Username, VerifyHelper.Key.Nickname);
            VerifyHelper.Check(this.Password, VerifyHelper.Key.Password);
            SettingOfAuthor settingOfAuthor = new SettingOfAuthor((IModelToDbContextOfBase)db);
            if (this.PlayInfo.Rebate_Normal < settingOfAuthor.LowerRebate
                || this.PlayInfo.Rebate_Normal > settingOfAuthor.CapsRebate)
            {
                string error = string.Format("");
                throw new Exception(error);
            }
        }

        /// <summary>
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public Author GetModel(IModelToDbContext db)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 内嵌元素

        /// <summary>
        /// 用于创建用户的游戏资料的数据集
        /// </summary>
        [DataContract]
        public class CreateUserPlayInfoImport
        {
            /// <summary>
            /// 正常返点
            /// </summary>
            [DataMember]
            public double Rebate_Normal { get; set; }

            /// <summary>
            /// 不定位返点
            /// </summary>
            [DataMember]
            public double Rebate_IndefinitePosition { get; set; }

            /// <summary>
            /// 一级佣金（如果为0则采用系统设置）
            /// </summary>
            [DataMember]
            public double Commission_A { get; set; }

            /// <summary>
            /// 二级佣金（如果为0则采用系统设置）
            /// </summary>
            [DataMember]
            public double Commission_B { get; set; }

            /// <summary>
            /// 分红（百分比）（如果为0则采用系统设置）
            /// </summary>
            [DataMember]
            public double Dividend { get; set; }
        }

        #endregion
    }
}
