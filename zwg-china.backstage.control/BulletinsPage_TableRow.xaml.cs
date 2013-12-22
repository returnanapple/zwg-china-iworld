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
    public partial class BulletinsPage_TableRow : UserControl
    {
        public BulletinsPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public BulletinExport State
        {
            get { return (BulletinExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(BulletinExport), typeof(BulletinsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                BulletinsPage_TableRow tool = (BulletinsPage_TableRow)d;
                BulletinExport data = (BulletinExport)e.NewValue;

                tool.text_Title.Text = data.Title;
                tool.text_Status.Text = data.Status.ToString();

                AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
                if (aInfo.Group.CanEditAdministrator) { return; }
                tool.button_Remove.Visibility = System.Windows.Visibility.Collapsed;
            }));

        #endregion

        #region 刷新列表

        /// <summary>
        /// 当需要刷新列表时候触发
        /// </summary>
        public event EventHandler RefreshEventHandler;

        /// <summary>
        /// 触发刷新列表动作
        /// </summary>
        protected void OnRefresh(object sender, EventArgs e)
        {
            if (RefreshEventHandler == null) { return; }
            RefreshEventHandler(this, new EventArgs());
        }

        #endregion

        #region 显示详细信息

        private void ShowFullWindow(object sender, RoutedEventArgs e)
        {
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            if (aInfo.Group.CanEditSettings)
            {
                BulletinsPage_EditWindow fw = new BulletinsPage_EditWindow();
                fw.State = this.State;
                fw.Closed += ShowEditResult;
                fw.Show();
                fw.Show();
            }
            else
            {
                BulletinsPage_FullWindow fw = new BulletinsPage_FullWindow();
                fw.State = this.State;
                fw.Show();
            }
        }

        void ShowEditResult(object sender, EventArgs e)
        {
            BulletinsPage_EditWindow fw = (BulletinsPage_EditWindow)sender;
            if (fw.DialogResult != true) { return; }
            if (fw.Error == null)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "编辑公告成功";
                ep.Closed += OnRefresh;
                ep.Show();
            }
            else
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = fw.Error;
                ep.Show();
            }
        }

        #endregion

        #region 移除

        private void Remove(object sender, RoutedEventArgs e)
        {
            NormalPrompt np = new NormalPrompt();
            np.State = "你确定要删除公告吗？注意：该操作不可逆转。";
            np.Closed += Remove_do;
            np.Show();
        }

        void Remove_do(object sender, EventArgs e)
        {
            NormalPrompt np = (NormalPrompt)sender;
            if (np.DialogResult != true) { return; }
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);

            RemoveBulleinImport import = new RemoveBulleinImport
            {
                Id = this.State.Id,
                Token = aInfo.Token
            };
            MessageServiceClient client = new MessageServiceClient();
            client.RemoveBulleinCompleted += ShowRemoveResult;
            client.RemoveBulleinAsync(import);
        }

        void ShowRemoveResult(object sender, RemoveBulleinCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "删除公告成功";
                ep.Closed += OnRefresh;
                ep.Show();
            }
            else
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = e.Result.Error;
                ep.Show();
            }
        }

        #endregion
    }
}
