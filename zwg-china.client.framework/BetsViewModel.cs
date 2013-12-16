using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.client.framework.LotteryService;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 投注明细页面试图
    /// </summary>
    public class BetsViewModel : ShowListViewModelBase<BettingExport, LotteryServiceClient>
    {
        #region 私有字段

        public DateTime? beginTime = null;
        public DateTime? endTime = null;
        public BettingStatus? status = null;

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
        public BettingStatus? Status
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

        public BetsViewModel()
            : base("投注明细")
        {
            client.GetBettingsCompleted += ShowList;
        }
        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            GetBettingsImport import = new GetBettingsImport
            {
                BeginTime = this.BeginTime,
                EndTime = this.EndTime,
                Status = this.Status,
                PageIndex = this.PageIndex,
                Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
            };
            client.GetBettingsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.BeginTime = null;
            this.EndTime = null;
            this.Status = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetBettingsCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                this.PageIndex = e.Result.PageInde;
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
