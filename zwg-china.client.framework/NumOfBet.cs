using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 用于投注的号码的封装
    /// </summary>
    public class NumOfBet : ModelBase
    {
        #region 私有字段

        int num = 0;
        bool selected = false;

        #endregion

        #region 属性

        /// <summary>
        /// 号码
        /// </summary>
        public int Num
        {
            get { return num; }
            set
            {
                if (num == value) { return; }
                num = value;
                OnPropertyChanged("Num");
            }
        }

        /// <summary>
        /// 一个布尔值 表示号码是否已经被选中
        /// </summary>
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected == value) { return; }
                selected = value;
                OnPropertyChanged("Selected");
                if (selected == false) { return; }
                if (ClearBetCommand == null) { return; }
                ClearBetCommand.Execute(null);
            }
        }

        /// <summary>
        /// 清理已选投注的命令
        /// </summary>
        public UniversalCommand ClearBetCommand { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用于投注的号码的封装
        /// </summary>
        /// <param name="num">号码</param>
        /// <param name="clearBetCommand">清理已选投注的命令</param>
        public NumOfBet(int num, UniversalCommand clearBetCommand)
        {
            this.Num = num;
            this.ClearBetCommand = clearBetCommand;
        }

        #endregion
    }
}
