using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class Author : CategoryModelBase
    {
        #region 私有字段

        double money = 0;
        double money_Frozen = 0;
        double consumption = 0;
        double integral = 0;
        int subordinate = 0;
        List<SubordinateData> subordinateOfHighRebate = new List<SubordinateData>();

        #endregion

        #region 属性

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 资金密码
        /// </summary>
        public string FundsCode { get; set; }

        /// <summary>
        /// 安全码
        /// </summary>
        public string SafeCode { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 上次登录的网络地址
        /// </summary>
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 上次登录的实际地址
        /// </summary>
        public string LastLoginAddress { get; set; }

        /// <summary>
        /// 绑定信息
        /// </summary>
        public virtual UserBinding Binding { get; set; }

        /// <summary>
        /// 游戏资料
        /// </summary>
        public virtual UserPlayInfo PlayInfo { get; set; }

        /// <summary>
        /// 额外的高点号配额
        /// </summary>
        public virtual List<ExtraQuota> ExtraQuotas { get; set; }

        #region 数据

        /// <summary>
        /// 现金余额
        /// </summary>
        public double Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("现金余额不能小于0");
                }
                money = value;
            }
        }

        /// <summary>
        /// 被冻结的现金总额
        /// </summary>
        public double Money_Frozen
        {
            get { return money_Frozen; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("被冻结的现金总额不能小于0");
                }
                money_Frozen = value;
            }
        }

        /// <summary>
        /// 消费量
        /// </summary>
        public double Consumption
        {
            get { return consumption; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("消费量不能小于0");
                }
                consumption = value;
            }
        }

        /// <summary>
        /// 积分
        /// </summary>
        public double Integral
        {
            get { return integral; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("积分不能小于0");
                }
                integral = value;
            }
        }

        /// <summary>
        /// 直属下级数量
        /// </summary>
        public int Subordinate
        {
            get { return subordinate; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("直属下级数量不能小于0");
                }
                subordinate = value;
            }
        }

        /// <summary>
        /// 直属的高点用户数量
        /// </summary>
        public virtual List<SubordinateData> SubordinateOfHighRebate
        {
            get { return subordinateOfHighRebate; }
            set { subordinateOfHighRebate = value; }
        }

        #endregion

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户信息
        /// </summary>
        public Author()
        {
        }

        /// <summary>
        /// 实例化一个新的用户信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="playInfo">游戏资料</param>
        /// <param name="parent">父节点</param>
        public Author(string username, string password, UserPlayInfo playInfo, Author parent = null)
            : base(parent)
        {
            this.Username = username;
            this.Password = password;
            this.FundsCode = "未设置";
            this.SafeCode = "未设置";
            this.PlayInfo = playInfo;
            this.Status = UserStatus.未激活;
            this.LastLoginIp = "从未登陆";
            this.LastLoginAddress = "从未登陆";
            this.LastLoginTime = DateTime.Now;
            this.Binding = new UserBinding();
            this.ExtraQuotas = new List<ExtraQuota>();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 声明用户已经登录
        /// </summary>
        /// <param name="ip">网络地址</param>
        /// <param name="address">实际地址</param>
        public void OnLogin(string ip, string address)
        {
            this.LastLoginIp = ip;
            this.LastLoginAddress = address;
            this.LastLoginTime = DateTime.Now;
        }

        #endregion
    }
}
