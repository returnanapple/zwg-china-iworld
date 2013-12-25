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
using zwg_china.client.framework.RecordOfAuthorService;

namespace zwg_china.client
{
    public partial class DividendRecordsPage_TableRow : UserControl
    {
        public DividendRecordsPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public DividendRecordExport State
        {
            get { return (DividendRecordExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(DividendRecordExport), typeof(DividendRecordsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                DividendRecordsPage_TableRow tool = (DividendRecordsPage_TableRow)d;
                DividendRecordExport data = (DividendRecordExport)e.NewValue;

                tool.text_Owner.Text = data.Owner;
                tool.text_Profit.Text = data.Profit.ToString("0.00");
                tool.text_Sum.Text = data.Sum.ToString("0.00");
                tool.text_Sum.Text = data.Sum.ToString("0.00");
                tool.text_CreatedTime.Text = data.CreatedTime.ToLongDateString();
            }));

        #endregion
    }
}
