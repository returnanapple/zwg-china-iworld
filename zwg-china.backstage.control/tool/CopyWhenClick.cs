using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace zwg_china.backstage.control
{
    /// <summary>
    /// 点击的时候将文本内容复制到剪贴板
    /// </summary>
    public class CopyWhenClick : TriggerBase<TextBlock>
    {
        #region 保护方法

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.MouseLeftButtonDown += Copy;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.MouseLeftButtonDown -= Copy;
        }

        #endregion

        /// <summary>
        /// 清空信息
        /// </summary>
        /// <param name="sender">触发对象</param>
        /// <param name="e">监视对象</param>
        void Copy(object sender, EventArgs e)
        {
            string text = ((TextBlock)sender).Text;
            Clipboard.SetText(text);

            ErrorPrompt ep = new ErrorPrompt();
            ep.State = "所选内容已经复制到剪贴板";
            ep.Show();
        }
    }
}
