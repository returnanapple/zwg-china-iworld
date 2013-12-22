using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.LotteryService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看虚拟排行页的视图模型
    /// </summary>
    public class VirtualBonusViewModel : ShowListViewModelBase<VirtualBonusExport, LotteryServiceClient>
    {
        #region 私有字段

        string keywordForTicketName = null;
        int? ticketId = null;

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

        #endregion

        #region 构造方法

        public VirtualBonusViewModel()
            : base("彩票管理", "查看虚拟排行")
        {
            client.GetVirtualBonusCompleted += ShowList;
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetVirtualBonusImport import = new GetVirtualBonusImport
            {
                KeywordForTicketName = this.KeywordForTicketName,
                TicketId = this.TicketId,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetVirtualBonusAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForTicketName = null;
            this.TicketId = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetVirtualBonusCompletedEventArgs e)
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
