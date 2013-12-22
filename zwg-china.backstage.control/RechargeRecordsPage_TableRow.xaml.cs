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
using zwg_china.backstage.framework.RecordOfAuthorService;

namespace zwg_china.backstage.control
{
    public partial class RechargeRecordsPage_TableRow : UserControl
    {
        public RechargeRecordsPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public RechargeRecordExport State
        {
            get { return (RechargeRecordExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(RechargeRecordExport), typeof(RechargeRecordsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                RechargeRecordsPage_TableRow tool = (RechargeRecordsPage_TableRow)d;
                RechargeRecordExport data = (RechargeRecordExport)e.NewValue;

                tool.text_Owner.Text = data.Owner;
                tool.text_SerialNumber.Text = data.SerialNumber;
                tool.text_Sum.Text = data.Sum.ToString("0.00");
                tool.text_ComeFrom.Text = data.ComeFrom.ToString();
                tool.text_Status.Text = data.Status.ToString();
                tool.text_CreatedTime.Text = data.CreatedTime.ToLongDateString();
            }));

        #endregion
    }
}
