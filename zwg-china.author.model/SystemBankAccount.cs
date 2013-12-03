namespace zwg_china.model
{
    /// <summary>
    /// 银行账号
    /// </summary>
    public class SystemBankAccount : ModelBase
    {
        #region 属性

        /// <summary>
        /// 开户人
        /// </summary>
        public string HolderOfTheCard { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string Card { get; set; }

        /// <summary>
        /// 银行
        /// </summary>
        public Bank BankOfTheCard { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 排列系数
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 一个布尔值 表示该对象是否隐藏
        /// </summary>
        public bool Hide { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的银行帐号
        /// </summary>
        public SystemBankAccount()
        {
        }

        /// <summary>
        /// 实例化一个新的银行帐号
        /// </summary>
        /// <param name="holderOfTheCard">开户人</param>
        /// <param name="card">卡号</param>
        /// <param name="bank">银行</param>
        /// <param name="remark">备注</param>
        /// <param name="order">排列系数</param>
        /// <param name="hide">一个布尔值 表示该对象是否隐藏</param>
        public SystemBankAccount(string holderOfTheCard, string card, Bank bank, string remark, int order, bool hide)
        {
            this.HolderOfTheCard = holderOfTheCard;
            this.Card = card;
            this.BankOfTheCard = bank;
            this.Remark = remark;
            this.Order = order;
            this.Hide = hide;
        }

        #endregion
    }
}
