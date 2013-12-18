using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.client.framework
{
    public class TagOfBet : ModelBase
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
                    if (SelectTagCommand == null) { return; }
                    SelectTagCommand.Execute(this.Name);
                }
            }
        }

        /// <summary>
        /// 选中玩法标签的命令
        /// </summary>
        public UniversalCommand SelectTagCommand { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的玩法标签的封装
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="selectTagCommand">选中玩法标签的命令</param>
        public TagOfBet(string name, UniversalCommand selectTagCommand)
        {
            this.Name = name;
            this.SelectTagCommand = selectTagCommand;
        }

        #endregion
    }
}
