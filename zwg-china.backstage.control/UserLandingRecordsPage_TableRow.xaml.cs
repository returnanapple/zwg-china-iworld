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
using zwg_china.backstage.framework.AuthorService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.control
{
    public partial class UserLandingRecordsPage_TableRow : UserControl
    {
        public UserLandingRecordsPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public AuthorLandingRecordExport State
        {
            get { return (AuthorLandingRecordExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(AuthorLandingRecordExport), typeof(UserLandingRecordsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                UserLandingRecordsPage_TableRow tool = (UserLandingRecordsPage_TableRow)d;
                AuthorLandingRecordExport data = (AuthorLandingRecordExport)e.NewValue;

                tool.text_Owner.Text = data.Owner;
                tool.text_CreatedTime.Text = string.Format("{0} {1}"
                    , data.CreatedTime.ToShortDateString()
                    , data.CreatedTime.ToLongTimeString());
                tool.text_Ip.Text = data.Ip;
                tool.text_Address.Text = data.Address;
            }));

        #endregion
    }
}
