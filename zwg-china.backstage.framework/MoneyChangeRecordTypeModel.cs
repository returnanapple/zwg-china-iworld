using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 帐变记录的类型的筛选模型
    /// </summary>
    public class MoneyChangeRecordTypeModel : ModelBase
    {
        #region 私有字段

        Action<object> action = null;
        bool selected = false;

        #endregion

        #region 属性

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 一个布尔值 表示是否被UI选中
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
                if (action == null) { return; }
                this.action(null);
            }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个基础的用户组信息的封装
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="name">名称</param>
        /// <param name="action">选中时候所要执行的方法</param>
        /// <param name="selected">一个布尔值 表示是否被UI选中</param>
        public MoneyChangeRecordTypeModel(string type, string name, Action<object> action, bool selected = false)
        {
            this.Type = type;
            this.Name = name;
            this.action = action;
            this.selected = selected;
        }

        #endregion
    }
}
