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
    /// 用于修改用户信息的数据集
    /// </summary>
    [DataContract]
    public class EditUserImport : ImportBaseOfAuthor, IPackageForUpdateModel<IModelToDbContextOfAuthor, Author>
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        [DataMember]
        public UserStatus Status { get; set; }

        /// <summary>
        /// 银行卡
        /// </summary>
        [DataMember]
        public string Card { get; set; }

        /// <summary>
        /// 银行卡的开户人
        /// </summary>
        [DataMember]
        public string HolderOfTheCard { get; set; }

        /// <summary>
        /// 银行卡的开户银行
        /// </summary>
        [DataMember]
        public Bank BankOfTheCard { get; set; }

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

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfAuthor db)
        {
            SettingOfAuthor settingOfAuthor = new SettingOfAuthor(db);
            if (this.Status == UserStatus.未激活)
            {
                throw new Exception("不允许将用户的状态修改为“未激活”，操作无效");
            }
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
        }

        /// <summary>
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        public void Update(Author model)
        {
            model.Status = this.Status;
            model.Binding.Card = this.Card;
            model.Binding.HolderOfTheCard = this.HolderOfTheCard;
            model.Binding.BankOfTheCard = this.BankOfTheCard;
            model.PlayInfo.Rebate_Normal = this.Rebate_Normal;
            model.PlayInfo.Rebate_IndefinitePosition = this.Rebate_IndefinitePosition;
            model.PlayInfo.Commission_A = this.Commission_A;
            model.PlayInfo.Commission_B = this.Commission_B;
            model.PlayInfo.Dividend = this.Dividend;
        }

        #endregion
    }
}
