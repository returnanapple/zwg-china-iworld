using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 数据模型的基类
    /// </summary>
    public abstract class ModelBase : INotifyPropertyChanged
    {
        #region 事件

        /// <summary>
        /// 当目标属性的值被改变的时候将触发的事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region 保护方法

        /// <summary>
        /// 触发目标属性被改变的事件
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="error">错误信息</param>
        protected void ShowError(string error)
        {
            IPop<string> cw = ViewModelService.GetPop(Pop.ErrorPrompt) as IPop<string>;
            cw.State = error;
            cw.Show();
        }

        #endregion
    }
}
