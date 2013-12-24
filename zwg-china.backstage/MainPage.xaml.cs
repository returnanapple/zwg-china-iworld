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
using zwg_china.backstage.control;
using zwg_china.backstage.framework;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage
{
    /// <summary>
    /// 主界面
    /// </summary>
    public partial class MainPage : UserControl, IMainPage
    {
        #region 私有字段

        AdministratorServiceClient client = new AdministratorServiceClient();

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的主界面
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += KeepHeartbeat;
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

            //注册弹窗
            new RI().Register();
        }

        #endregion

        #region 心跳协议

        void KeepHeartbeat(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();
            sb.Duration = new Duration(new TimeSpan(0, 0, 10));
            sb.Completed += KeepHeartbeat_do;
            sb.Begin();
        }

        void KeepHeartbeat_do(object sender, EventArgs e)
        {
            if (!DataManager.HaveValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo)) { return; }
            AdministratorExport info = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            client.KeepHeartbeatAsync(info.Token);
            Storyboard sb = (Storyboard)sender;
            sb.Begin();
        }

        #endregion
    }
}
