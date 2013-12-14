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
    /// 用于提现的数据集
    /// </summary>
    [DataContract]
    public class WithdrawImport : ImportBaseOfAuthor, IPackageForCreateModel<IModelToDbContextOfAuthor, WithdrawalsRecord>
    {
        #region 属性

        /// <summary>
        /// 提现金额
        /// </summary>
        [DataMember]
        public double Sum { get; set; }

        /// <summary>
        /// 资金密码
        /// </summary>
        [DataMember]
        public string FundsCode { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfAuthor db)
        {
            this.FundsCode = VerifyHelper.EliminateSpaces(this.FundsCode);
            this.FundsCode = EncryptHelper.EncryptByMd5(this.FundsCode);
            if (this.Self.FundsCode != this.FundsCode)
            {
                throw new Exception("资金密码不正确，请重新输入");
            }
            if (!this.Self.Binding.AlreadyBindingCard)
            {
                throw new Exception("未绑定银行卡信息，操作无效");
            }
            UserGroup group = db.UserGroups.FirstOrDefault(g => g.LowerOfConsumption < this.Self.Consumption && g.CapsOfConsumption > this.Self.Consumption);
            if (group == null)
            {
                group = db.UserGroups.Where(g => g.CapsOfConsumption <= this.Self.Consumption).OrderByDescending(g => g.CapsOfConsumption).FirstOrDefault();
            }
            if (group == null)
            {
                group = db.UserGroups.Where(g => g.LowerOfConsumption > this.Self.Consumption).OrderBy(g => g.LowerOfConsumption).FirstOrDefault();
            }
            DateTime now = DateTime.Now;
            SettingOfAuthor settingOfAuthor = new SettingOfAuthor(db);
            int timesOfWithdrawal = group.TimesOfWithdrawal == 0
                ? settingOfAuthor.TimesOfWithdrawal
                : group.TimesOfWithdrawal;
            int times = db.WithdrawalsRecords.Count(x => x.Owner.Id == this.Self.Id
                && x.CreatedTime.Year == now.Year
                && x.CreatedTime.Month == now.Month
                && x.CreatedTime.Day == now.Day);
            if (times > timesOfWithdrawal)
            {
                string error = string.Format("本日提现次数（{0}）已经超过系统设限（{1}），操作无效"
                    , times
                    , timesOfWithdrawal);
                throw new Exception(error);
            }
            double minimumWithdrawalAmount = group.MinimumWithdrawalAmount == 0
                ? settingOfAuthor.MinimumWithdrawalAmount
                : group.MinimumWithdrawalAmount;
            double maximumWithdrawalAmount = group.MaximumWithdrawalAmount == 0
                ? settingOfAuthor.MaximumWithdrawalAmount
                : group.MaximumWithdrawalAmount;
            if (this.Sum < minimumWithdrawalAmount
                || this.Sum > maximumWithdrawalAmount)
            {
                string error = string.Format("提现金额（{0}）超出系统设限（{1} - {2}），操作无效"
                    , this.Sum
                    , minimumWithdrawalAmount
                    , maximumWithdrawalAmount);
                throw new Exception(error);
            }
            if (this.Sum > this.Self.Money)
            {
                throw new Exception("提现金额不能高于账户余额，操作无效");
            }
        }

        /// <summary>
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public WithdrawalsRecord GetModel(IModelToDbContextOfAuthor db)
        {
            Author owner = db.Authors.Find(this.Self.Id);
            return new WithdrawalsRecord(owner, this.Sum);
        }

        #endregion
    }
}
