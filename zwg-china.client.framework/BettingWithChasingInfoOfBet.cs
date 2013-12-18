using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 用于追号的投注信息
    /// </summary>
    public class BettingWithChasingInfoOfBet : ModelBase
    {
        #region 私有字段

        string issue = "";
        double multiple = 1;

        #endregion

        #region 属性

        /// <summary>
        /// 期号
        /// </summary>
        public string Issue
        {
            get { return issue; }
            set
            {
                if (issue == value) { return; }
                issue = value;
                OnPropertyChanged("Issue");
            }
        }

        /// <summary>
        /// 倍数
        /// </summary>
        public double Multiple
        {
            get { return multiple; }
            set
            {
                if (multiple == value) { return; }
                multiple = value;
                OnPropertyChanged("Multiple");
            }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用于追号的投注信息
        /// </summary>
        /// <param name="issue">期号</param>
        public BettingWithChasingInfoOfBet(string issue)
        {
            this.Issue = issue;
        }

        #endregion
    }
}
