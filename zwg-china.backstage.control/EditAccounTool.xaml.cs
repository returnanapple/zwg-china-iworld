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
    [Window(Pop.EditAccounTool)]
    public partial class EditAccounTool : ChildWindow, IPop<ManagerViewModelBase.EditEditAccounPackage>
    {
        public EditAccounTool()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Enter(object sender, RoutedEventArgs e)
        {
            this.State = new ManagerViewModelBase.EditEditAccounPackage
            {
                OldPassword = input_oldPassword.Password,
                NewPassword = input_newPassword.Password,
                NewPassword2 = inpu_newPassword_confirm.Password
            };
            this.DialogResult = true;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        /// <summary>
        /// 内容
        /// </summary>
        public ManagerViewModelBase.EditEditAccounPackage State { get; set; }
    }
}

