using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [DataContract]
    public class AuthorExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string Username { get; set; }

        /// <summary>
        /// 所属的用户组
        /// </summary>
        [DataMember]
        public UserGroupExport Group { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        [DataMember]
        public UserStatus Status { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        [DataMember]
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 上次登录的网络地址
        /// </summary>
        [DataMember]
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 上次登录的实际地址
        /// </summary>
        [DataMember]
        public string LastLoginAddress { get; set; }

        /// <summary>
        /// 绑定信息
        /// </summary>
        [DataMember]
        public virtual UserBindingExport Binding { get; set; }

        /// <summary>
        /// 游戏资料
        /// </summary>
        [DataMember]
        public virtual UserPlayInfoExport PlayInfo { get; set; }

        /// <summary>
        /// 高点号配额的剩余量
        /// </summary>
        [DataMember]
        public virtual List<UserQuotaExport> UserQuotas { get; set; }

        /// <summary>
        /// 现金余额
        /// </summary>
        [DataMember]
        public double Money { get; set; }

        /// <summary>
        /// 被冻结的现金总额
        /// </summary>
        [DataMember]
        public double Money_Frozen { get; set; }

        /// <summary>
        /// 消费量
        /// </summary>
        [DataMember]
        public double Consumption { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        [DataMember]
        public double Integral { get; set; }

        /// <summary>
        /// 直属下级数量
        /// </summary>
        [DataMember]
        public int Subordinate { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户信息
        /// </summary>
        public AuthorExport()
        {

        }

        /// <summary>
        /// 实例化一个新的用户信息
        /// </summary>
        /// <param name="model">用户的数据模型</param>
        /// <param name="group">所属的用户组</param>
        /// <param name="systemQuotas">系统设置的高点号配额方案</param>
        public AuthorExport(Author model, UserGroup group, List<SystemQuotaDetail> systemQuotas)
        {
            this.Id = model.Id;
            this.Username = model.Username;
            this.Group = new UserGroupExport(group);
            this.Status = model.Status;
            this.CreatedTime = model.CreatedTime;
            this.LastLoginTime = model.LastLoginTime;
            this.LastLoginIp = model.LastLoginIp;
            this.LastLoginAddress = model.LastLoginAddress;
            this.Binding = new UserBindingExport(model.Binding);
            this.PlayInfo = new UserPlayInfoExport(model.PlayInfo);
            this.Money = model.Money;
            this.Money_Frozen = model.Money_Frozen;
            this.Consumption = model.Consumption;
            this.Integral = model.Integral;
            this.Subordinate = model.Subordinate;

            this.UserQuotas = systemQuotas.OrderByDescending(x => x.Rebate).ToList()
                .ConvertAll(sq =>
                {
                    ExtraQuota eq = model.ExtraQuotas.FirstOrDefault(x => x.Rebate == sq.Rebate);
                    if (eq == null)
                    {
                        eq = new ExtraQuota(sq.Rebate, 0);
                    }
                    SubordinateData sd = model.SubordinateOfHighRebate.FirstOrDefault(x => x.Rebate == sq.Rebate);
                    if (sd == null)
                    {
                        sd = new SubordinateData(sq.Rebate, 0);
                    }
                    int sum = sq.Sum + eq.Sum - sd.Sum;
                    if (sum < 0)
                    {
                        sum = 0;
                    }
                    return new UserQuotaExport(sq.Rebate, sum);
                });
        }

        #endregion
    }
}
