﻿using System;
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
    public partial class MoneyChangePage_TableRow : UserControl
    {
        public MoneyChangePage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public MoneyChangeRecordExport State
        {
            get { return (MoneyChangeRecordExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(MoneyChangeRecordExport), typeof(MoneyChangePage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                MoneyChangePage_TableRow tool = (MoneyChangePage_TableRow)d;
                MoneyChangeRecordExport data = (MoneyChangeRecordExport)e.NewValue;

                tool.text_Owner.Text = data.Owner;
                tool.text_Type.Text = data.Type;
                tool.text_Income.Text = data.Income.ToString("0.00");
                tool.text_Expenses.Text = data.Expenses.ToString("0.00");
                tool.text_Sum.Text = data.Sum.ToString("0.00");
                tool.text_Money.Text = data.Money.ToString("0.00");
                tool.text_CreatedTime.Text = data.CreateTime.ToLongDateString();
                tool.SetValue(ToolTipService.ToolTipProperty,data.Description);
            }));

        #endregion
    }
}