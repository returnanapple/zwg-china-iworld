using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.LotteryService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看开奖记录页的视图模型
    /// </summary>
    public class LotteriesViewModel : ShowListViewModelBase<LotteryExport, LotteryServiceClient>
    {
        #region 私有字段

        string keywordForTicketName = null;
        int? ticketId = null;
        DateTime? beginTime = null;
        DateTime? endTime = null;

        #endregion

        #region 属性

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeywordForTicketName
        {
            get { return keywordForTicketName; }
            set
            {
                if (keywordForTicketName == value) { return; }
                keywordForTicketName = value;
                OnPropertyChanged("KeywordForTicketName");
            }
        }

        /// <summary>
        /// 所从属的彩票的存储指针
        /// </summary>
        public int? TicketId
        {
            get { return ticketId; }
            set
            {
                if (ticketId == value) { return; }
                ticketId = value;
                OnPropertyChanged("TicketId");
            }
        }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? BeginTime
        {
            get { return beginTime; }
            set
            {
                if (beginTime == value) { return; }
                beginTime = value;
                OnPropertyChanged("BeginTime");
            }
        }

        /// <summary>
        /// 终止时间
        /// </summary>
        public DateTime? EndTime
        {
            get { return endTime; }
            set
            {
                if (endTime == value) { return; }
                endTime = value;
                OnPropertyChanged("EndTime");
            }
        }

        #endregion

        #region 构造方法

        public LotteriesViewModel()
            : base("彩票管理", "查看开奖记录")
        {
            client.GetLotteriesCompleted += ShowList;
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetLotteriesImport import = new GetLotteriesImport
            {
                KeywordForTicketName = this.KeywordForTicketName,
                TicketId = this.TicketId,
                BeginTime = this.BeginTime,
                EndTime = this.EndTime,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetLotteriesAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForTicketName = null;
            this.TicketId = null;
            this.BeginTime = null;
            this.EndTime = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetLotteriesCompletedEventArgs e)
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
