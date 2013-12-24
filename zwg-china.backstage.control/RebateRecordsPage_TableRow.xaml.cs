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
    public partial class RebateRecordsPage_TableRow : UserControl
    {
        public RebateRecordsPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public RebateRecordExport State
        {
            get { return (RebateRecordExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(RebateRecordExport), typeof(RebateRecordsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                RebateRecordsPage_TableRow tool = (RebateRecordsPage_TableRow)d;
                RebateRecordExport data = (RebateRecordExport)e.NewValue;

                tool.text_Owner.Text = data.Owner;
                tool.text_Source.Text = data.Source;
                tool.text_GameName.Text = data.GameName;
                tool.text_Sum.Text = data.Sum.ToString("0.00");
                tool.text_CreatedTime.Text = data.CreatedTime.ToLongDateString();
            }));

        #endregion
    }
}
