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
using zwg_china.backstage.framework.MessageService;
using zwg_china.backstage.framework.AdministratorService;
using zwg_china.backstage.framework;

namespace zwg_china.backstage.control
{
    public partial class BulletinsPage_EditWindow : ChildWindow
    {
        public BulletinsPage_EditWindow()
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
            DependencyProperty.Register("Error", typeof(string), typeof(BulletinsPage_EditWindow), new PropertyMetadata(null));

        #endregion

        #region 附加内容

        public BulletinExport State
        {
            get { return (BulletinExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(BulletinExport), typeof(BulletinsPage_EditWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                BulletinsPage_EditWindow tool = (BulletinsPage_EditWindow)d;
                BulletinExport data = (BulletinExport)e.NewValue;

                tool.input_Title.Text = data.Title;
                tool.input_Context.Text = data.Context;
                tool.input_BeginTime.Text = string.Format("{0}/{1}/{2}"
                    , data.BeginTime.Year
                    , data.BeginTime.Month
                    , data.BeginTime.Day);
                tool.input_EndTime.Text = string.Format("{0}/{1}/{2}"
                    , data.EndTime.AddDays(-1).Year
                    , data.EndTime.AddDays(-1).Month
                    , data.EndTime.AddDays(-1).Day); ;
                tool.input_Hide.SelectedIndex = data.Hide ? 0 : 1;
            }));

        #endregion

        #region 修改

        private void Edit(object sender, RoutedEventArgs e)
        {
            EditBulleinImport import = new EditBulleinImport
            {
                Id = this.State.Id,
                Title = input_Title.Text,
                Context = input_Context.Text,
                BeginTime = GetTime(input_BeginTime.Text),
                EndTime = GetTime(input_EndTime.Text),
                Hide = input_Hide.SelectedIndex == 0,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            MessageServiceClient client = new MessageServiceClient();
            client.EditBulleinCompleted += ShowEditResult;
            client.EditBulleinAsync(import);
        }

        void ShowEditResult(object sender, EditBulleinCompletedEventArgs e)
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

