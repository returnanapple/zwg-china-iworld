using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using zwg_china.backstage.framework;
using zwg_china.backstage.framework.AdministratorService;
using zwg_china.backstage.framework.MessageService;

namespace zwg_china.backstage.control
{
    public partial class BulletinsPage_CreateWindow : ChildWindow
    {
        public BulletinsPage_CreateWindow()
        {
            InitializeComponent();
        }

        #region 错误信息

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error
        {
            get { return (string)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }

        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(string), typeof(BulletinsPage_CreateWindow), new PropertyMetadata(null));

        #endregion

        #region 创建

        private void Create(object sender, RoutedEventArgs e)
        {
            CreateBulleinImport import = new CreateBulleinImport
            {
                Title = input_Title.Text,
                Context = input_Context.Text,
                BeginTime = GetTime(input_BeginTime.Text),
                EndTime = GetTime(input_EndTime.Text),
                Hide = input_Hide.SelectedIndex == 0,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            MessageServiceClient client = new MessageServiceClient();
            client.CreateBulleinCompleted += ShowCreateResult;
            client.CreateBulleinAsync(import);
        }

        void ShowCreateResult(object sender, CreateBulleinCompletedEventArgs e)
        {
            if (!e.Result.Success)
            {
                this.Error = e.Result.Error;
            }
            this.DialogResult = true;
        }

        #endregion

        #region 取消

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion

        #region 私有方法

        DateTime GetTime(string input)
        {
            string[] t = input.Split("-/".ToArray());
            return new DateTime(Convert.ToInt32(t[0])
                , Convert.ToInt32(t[1])
                , Convert.ToInt32(t[2]));
        }

        #endregion
    }
}

