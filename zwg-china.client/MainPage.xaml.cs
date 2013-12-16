using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using zwg_china.client.framework;

namespace zwg_china.client
{
    /// <summary>
    /// 主界面
    /// </summary>
    public partial class MainPage : UserControl, IMainPage
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的主界面
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        #endregion

        #region 实现IMainPage接口

        /// <summary>
        /// 显示目标子界面
        /// </summary>
        /// <param name="userControl">所要显示的子界面</param>
        public void Show(UserControl userControl)
        {
            body.Children.Clear();
            body.Children.Add(userControl);
        }

        /// <summary>
        /// 注册可跳转界面
        /// </summary>
        public void RegisterViews()
        {
            //获取目标程序集
            Assembly assembly = Assembly.GetExecutingAssembly();

            #region 注册可跳转界面

            assembly.GetTypes()
                .Where(x => x.GetCustomAttributes(true).Any(t => t is ViewAttribute))
                .ToList().ForEach(x =>
                {
                    var attribute = x.GetCustomAttributes(true).First(t => t is ViewAttribute) as ViewAttribute;
                    ViewModelService.RegisterPage(attribute.Page
                        , x.Name
                        , attribute.IsDefault
                        , new ViewModelService.ControlCreater(() =>
                        {
                            return assembly.CreateInstance(x.FullName) as UserControl;
                        }));
                });

            #endregion

            #region 注册弹窗

            assembly.GetTypes()
                .Where(x => (x.GetInterfaces().Any(t => t == typeof(IPop)))
                    && (x.GetCustomAttributes(true).Any(t => t is WindowAttribute)))
                .ToList().ForEach(_type =>
                {
                    WindowAttribute attribute = _type.GetCustomAttributes(true)
                        .First(x => x is WindowAttribute) as WindowAttribute;
                    ViewModelService.RegisterPop(attribute.Pop
                        , new ViewModelService.WindowCreater(() =>
                        {
                            return assembly.CreateInstance(_type.FullName) as ChildWindow;
                        }));
                });

            #endregion
        }

        #endregion

        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            App.Current.MainWindow.DragMove();
        }
    }
}
