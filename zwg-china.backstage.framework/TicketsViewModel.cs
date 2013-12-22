using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.LotteryService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看彩票列表页的视图模型
    /// </summary>
    public class TicketsViewModel : ShowListViewModelBase<LotteryTicketExport, LotteryServiceClient>
    {
        #region 私有字段

        string keywordForName = null;

        #endregion

        #region 属性

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeywordForName
        {
            get { return keywordForName; }
            set
            {
                if (keywordForName == value) { return; }
                keywordForName = value;
                OnPropertyChanged("KeywordForName");
            }
        }

        #endregion

        #region 构造方法

        public TicketsViewModel()
            : base("彩票管理", "查看彩票列表")
        {
            client.GetLotteryTicketsCompleted += ShowList;
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetLotteryTicketsImport import = new GetLotteryTicketsImport
            {
                KeywordForName = this.KeywordForName,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetLotteryTicketsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForName = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetLotteryTicketsCompletedEventArgs e)
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
