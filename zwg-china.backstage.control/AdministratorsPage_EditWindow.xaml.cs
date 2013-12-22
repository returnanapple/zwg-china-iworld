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

namespace zwg_china.backstage.control
{
    public partial class AdministratorsPage_EditWindow : ChildWindow
    {
        AdministratorServiceClient client = new AdministratorServiceClient();

        public AdministratorsPage_EditWindow()
        {
            InitializeComponent();
            this.Loaded += InsertGroups;
            client.GetBasicAdministratorGroupsCompleted += InsertGroups_do;
            client.ChangeGroupCompleted += ShowEditResult;
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
            DependencyProperty.Register("Error", typeof(string), typeof(AdministratorsPage_EditWindow), new PropertyMetadata(null));

        #endregion

        #region 附加内容

        public BasicAdministratorExport State
        {
            get { return (BasicAdministratorExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(BasicAdministratorExport), typeof(AdministratorsPage_EditWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                AdministratorsPage_EditWindow tool = (AdministratorsPage_EditWindow)d;
                BasicAdministratorExport data = (BasicAdministratorExport)e.NewValue;

                tool.text_Username.Text = data.Username;
            }));

        #endregion

        #region 填充管理员组下拉选单

        void InsertGroups(object sender, RoutedEventArgs e)
        {
            GetBasicAdministratorGroupsImport import = new GetBasicAdministratorGroupsImport
            {
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetBasicAdministratorGroupsAsync(import);
        }

        void InsertGroups_do(object sender, GetBasicAdministratorGroupsCompletedEventArgs e)
        {
            if (!e.Result.Success) { return; }
            input_group.ItemsSource = e.Result.Info;
            input_group.SelectedItem = e.Result.Info.First(x => x.Name == this.State.Group);
        }

        #endregion

        #region 修改

        private void Edit(object sender, RoutedEventArgs e)
        {
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            ChangeGroupImport import = new ChangeGroupImport
            {
                Id = this.State.Id,
                NewGroupId = ((BasicAdministratorGroupExport)input_group.SelectedItem).Id,
                Token = aInfo.Token
            };
            client.ChangeGroupAsync(import);
        }

        void ShowEditResult(object sender, ChangeGroupCompletedEventArgs e)
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
    }
}

