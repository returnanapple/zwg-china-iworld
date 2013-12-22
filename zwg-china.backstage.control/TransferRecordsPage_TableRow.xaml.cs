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
    public partial class TransferRecordsPage_TableRow : UserControl
    {
        public TransferRecordsPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public TransferRecordExport State
        {
            get { return (TransferRecordExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(TransferRecordExport), typeof(TransferRecordsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                TransferRecordsPage_TableRow tool = (TransferRecordsPage_TableRow)d;
                TransferRecordExport data = (TransferRecordExport)e.NewValue;

                tool.text_SerialNumber.Text = data.SerialNumber;
                tool.text_Sum.Text = data.Sum.ToString("0.00");
                tool.text_ComeFrom.Text = data.ComeFrom.ToString();
                tool.text_Status.Text = data.Status.ToString();
                tool.text_CreatedTime.Text = data.CreatedTime.ToLongDateString();
            }));

        #endregion
    }
}
