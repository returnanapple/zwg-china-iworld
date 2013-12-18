using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 玩法的封装
    /// </summary>
    public class HowToPlayOfBet : ModelBase
    {
        #region 私有字段

        string name = "";
        bool selected = false;

        #endregion

        #region 属性

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value) { return; }
                name = value;
                OnPropertyChanged("Name");
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
                if (value == true)
                {
                    if (SelectHowToPlayCommand == null) { return; }
                    SelectHowToPlayCommand.Execute(this.Name);
                }
            }
        }

        /// <summary>
        /// 选中玩法的命令
        /// </summary>
        public UniversalCommand SelectHowToPlayCommand { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的玩法的封装
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="selectHowToPlayCommand">选中玩法的命令</param>
        public HowToPlayOfBet(string name, UniversalCommand selectHowToPlayCommand)
        {
            this.Name = name;
            this.SelectHowToPlayCommand = selectHowToPlayCommand;
        }

        #endregion
    }
}
