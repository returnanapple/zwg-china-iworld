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
using zwg_china.backstage.framework.LotteryService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.control
{
    public partial class VirtualBonusPage_TableRow : UserControl
    {
        public VirtualBonusPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public VirtualBonusExport State
        {
            get { return (VirtualBonusExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(VirtualBonusExport), typeof(VirtualBonusPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                VirtualBonusPage_TableRow tool = (VirtualBonusPage_TableRow)d;
                VirtualBonusExport data = (VirtualBonusExport)e.NewValue;

                tool.text_Ticket.Text = data.Ticket;
                tool.text_Sum.Text = data.Sum.ToString("0.00");

                AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
                if (aInfo.Group.CanEditUsers) { return; }
                tool.button_Edit.Visibility = Visibility.Collapsed;
                tool.button_Remove.Visibility = Visibility.Collapsed;
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

        #region 修改

        private void Edit(object sender, RoutedEventArgs e)
        {
            VirtualBonusPage_EditWindow fw = new VirtualBonusPage_EditWindow();
            fw.State = this.State;
            fw.Closed += ShowEditResult;
            fw.Show();
        }

        void ShowEditResult(object sender, EventArgs e)
        {
            VirtualBonusPage_EditWindow fw = (VirtualBonusPage_EditWindow)sender;
            if (fw.DialogResult != true) { return; }
            if (fw.Error == null)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "修改用户的额外配额成功";
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

        #region 删除虚拟排行

        private void Remove(object sender, RoutedEventArgs e)
        {
            NormalPrompt np = new NormalPrompt();
            np.State = "你确定要删除虚拟排行吗？注意：该操作不可逆转。";
            np.Closed += Remove_do;
            np.Show();
        }

        void Remove_do(object sender, EventArgs e)
        {
            NormalPrompt np = (NormalPrompt)sender;
            if (np.DialogResult != true) { return; }
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);

            RemoveVirtualBonusImport import = new RemoveVirtualBonusImport
            {
                Id = this.State.Id,
                Token = aInfo.Token
            };
            LotteryServiceClient client = new LotteryServiceClient();
            client.RemoveVirtualBonusCompleted += ShowRemoveResult;
            client.RemoveVirtualBonusAsync(import);
        }

        void ShowRemoveResult(object sender, RemoveVirtualBonusCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "删除虚拟排行成功";
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
