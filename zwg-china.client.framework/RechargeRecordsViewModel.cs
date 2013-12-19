using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.client.framework.RecordOfAuthorService;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 充值记录页
    /// </summary>
    public class RechargeRecordsViewModel : ShowListViewModelBase<RechargeRecordExport, RecordOfAuthorServiceClient>
    {
        #region 私有字段

        public DateTime? beginTime = null;
        public DateTime? endTime = null;
        public RechargeStatus? status = null;

        #endregion

        #region 属性

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime
        {
            get
            {
                return beginTime;
            }
            set
            {
                if (beginTime != value)
                {
                    beginTime = value;
                    OnPropertyChanged("BeginTime");
                }
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                if (endTime != value)
                {
                    endTime = value;
                    OnPropertyChanged("EndTime");
                }
            }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public RechargeStatus? Status
        {
            get
            {
                return status;
            }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

        #endregion

        #region 构造方法

        public RechargeRecordsViewModel()
            : base("资金管理")
        {
            client.GetRechargeDetailsCompleted += ShowList;
        }
        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetRechargeDetailsImport import = new GetRechargeDetailsImport
            {
                BeginTime = this.BeginTime,
                EndTime = this.EndTime,
                Status = this.Status,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
            };
            client.GetRechargeDetailsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.BeginTime = null;
            this.EndTime = null;
            this.Status = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetRechargeDetailsCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                this.PageIndex = e.Result.PageIndex;
                this.TotalPage = e.Result.CountOfPage;
                UpdateLsit(e.Result.List);
            }
            else
            {
                ShowError(e.Result.Error);
            }
        }


        #endregion
    }
}
