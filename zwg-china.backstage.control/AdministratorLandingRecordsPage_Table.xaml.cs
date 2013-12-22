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
    public partial class AdministratorLandingRecordsPage_Table : UserControl
    {
        public AdministratorLandingRecordsPage_Table()
        {
            InitializeComponent();
        }

        #region 附加内容

        public AdministratorLandingRecordExport State
        {
            get { return (AdministratorLandingRecordExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(AdministratorLandingRecordExport), typeof(AdministratorLandingRecordsPage_Table)
            , new PropertyMetadata(null, (d, e) =>
            {
                AdministratorLandingRecordsPage_Table tool = (AdministratorLandingRecordsPage_Table)d;
                AdministratorLandingRecordExport data = (AdministratorLandingRecordExport)e.NewValue;

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
