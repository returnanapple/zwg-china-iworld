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
    /// 用于创建用户的数据集
    /// </summary>
    [DataContract]
    public class CreateUserImport : ImportBaseOfAuthor, IPackageForCreateModel<IModelToDbContextOfAuthor, Author>
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
        /// 上级用户的存储指针
        /// </summary>
        public int ParentId
        {
            get { return this.Self == null ? 0 : this.Self.Id; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfAuthor db)
        {
            #region 检查用户名和密码格式是否合法
            this.Username = VerifyHelper.EliminateSpaces(this.Username);
            this.Password = VerifyHelper.EliminateSpaces(this.Password);
            VerifyHelper.Check(this.Username, VerifyHelper.Key.Nickname);
            VerifyHelper.Check(this.Password, VerifyHelper.Key.Password);
            #endregion
            bool hadUsedUsername = db.Authors.Any(x => x.Username == this.Username);
            if (hadUsedUsername)
            {
                string error = string.Format("用户名 {0} 已经被使用", this.Username);
                throw new Exception(error);
            }
            SettingOfAuthor settingOfAuthor = new SettingOfAuthor(db);
            #region 检查返点
            if (this.Rebate_Normal < settingOfAuthor.LowerRebate
                || this.Rebate_Normal > settingOfAuthor.CapsRebate)
            {
                string error = string.Format("所要设置的普通返点（{0}）超过系统设限，合法的范围为：{1} - {2}"
                    , this.Rebate_Normal
                    , settingOfAuthor.LowerRebate
                    , settingOfAuthor.CapsRebate);
                throw new Exception(error);
            }
            if (this.Rebate_IndefinitePosition < settingOfAuthor.LowerRebate
                || this.Rebate_IndefinitePosition > settingOfAuthor.CapsRebate)
            {
                string error = string.Format("所要设置的不定位返点（{0}）超过系统设限，合法的范围为：{1} - {2}"
                    , this.Rebate_IndefinitePosition
                    , settingOfAuthor.LowerRebate
                    , settingOfAuthor.CapsRebate);
                throw new Exception(error);
            }

            Author parent = db.Authors.Find(this.ParentId);
            if (this.Rebate_Normal > parent.PlayInfo.Rebate_Normal)
            {
                string error = string.Format("所要设置的普通返点（{0}）不得大于所从属的上级用户的普通返点（{1}）"
                    , this.Rebate_Normal
                    , parent.PlayInfo.Rebate_Normal);
                throw new Exception(error);
            }
            if (this.Rebate_IndefinitePosition > parent.PlayInfo.Rebate_IndefinitePosition)
            {
                string error = string.Format("所要设置的不定位返点（{0}）不得大于所从属的上级用户的不定位返点（{1}）"
                    , this.Rebate_IndefinitePosition
                    , parent.PlayInfo.Rebate_IndefinitePosition);
                throw new Exception(error);
            }
            #region 检查上级用户的高点号配额
            if (this.Rebate_Normal > settingOfAuthor.LowerRebateOfHigh)
            {
                int numOfSq = 0;
                int numOfEq = 0;
                int numOfSd = 0;
                SystemQuota sq = db.SystemQuotas.FirstOrDefault(x => x.Rebate == parent.PlayInfo.Rebate_Normal);
                if (sq != null)
                {
                    SystemQuotaDetail sqd = sq.Details.FirstOrDefault(x => x.Rebate == this.Rebate_Normal);
                    if (sqd != null)
                    {
                        numOfSq = sqd.Sum;
                    }
                }
                ExtraQuota eq = parent.ExtraQuotas.FirstOrDefault(x => x.Rebate == this.Rebate_Normal);
                if (eq != null)
                {
                    numOfEq = eq.Sum;
                }
                SubordinateData sd = parent.SubordinateOfHighRebate.FirstOrDefault(x => x.Rebate == this.Rebate_Normal);
                if (sd != null)
                {
                    numOfSd = sd.Sum;
                }
                int surplus = numOfSq + numOfEq - numOfSd;
                if (surplus <= 0)
                {
                    string error = string.Format("作为上级用户的用户（用户名：{0}）的返点为 {1} 的高点号配额为 0，操作无效"
                        , parent.Username
                        , this.Rebate_Normal);
                    throw new Exception(error);
                }
            }
            #endregion

            #endregion
        }

        /// <summary>
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public Author GetModel(IModelToDbContextOfAuthor db)
        {
            string password = EncryptHelper.EncryptByMd5(this.Password);
            UserPlayInfo playInfo = new UserPlayInfo(this.Rebate_Normal, this.Rebate_IndefinitePosition);
            Author result = new Author(this.Username, password, playInfo);
            return result;
        }
        #endregion
    }
}
