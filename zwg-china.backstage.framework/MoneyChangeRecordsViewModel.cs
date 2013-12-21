using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using zwg_china.backstage.framework.RecordOfAuthorService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看帐变记录页的视图模型
    /// </summary>
    public class MoneyChangeRecordsViewModel : ShowListViewModelBase<MoneyChangeRecordExport, RecordOfAuthorServiceClient>
    {
        #region 私有字段

        string keywordForUsername = null;
        int? userId = null;
        DateTime? beginTime = null;
        DateTime? endTime = null;
        ObservableCollection<MoneyChangeRecordTypeModel> types = new ObservableCollection<MoneyChangeRecordTypeModel>();

        #endregion

        #region 属性

        /// <summary>
        /// 关键字（用户名）
        /// </summary>
        public string KeywordForUsername
        {
            get { return keywordForUsername; }
            set
            {
                if (keywordForUsername == value) { return; }
                keywordForUsername = value == "" ? null : value;
                OnPropertyChanged("KeywordForUsername");
                Refresh(null);
            }
        }

        /// <summary>
        /// 用户的存储指针
        /// </summary>
        public int? UserId
        {
            get { return userId; }
            set
            {
                if (userId == value) { return; }
                userId = value;
                OnPropertyChanged("UserId");
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
                Refresh(null);
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
                Refresh(null);
            }
        }

        /// <summary>
        /// 帐变类型
        /// </summary>
        public ObservableCollection<MoneyChangeRecordTypeModel> Types
        {
            get { return types; }
            set { types = value; }
        }

        #endregion

        #region 构造方法

        public MoneyChangeRecordsViewModel()
            : base("用户管理", "查看帐变记录")
        {
            this.Types.Add(new MoneyChangeRecordTypeModel(null, "全部", Refresh, true));
            this.Types.Add(new MoneyChangeRecordTypeModel("充值", "充值", Refresh));
            this.Types.Add(new MoneyChangeRecordTypeModel("提现", "提现", Refresh));
            this.Types.Add(new MoneyChangeRecordTypeModel("投注", "投注", Refresh));
            this.Types.Add(new MoneyChangeRecordTypeModel("中奖", "中奖", Refresh));
            this.Types.Add(new MoneyChangeRecordTypeModel("返点", "返点", Refresh));
            this.Types.Add(new MoneyChangeRecordTypeModel("佣金", "佣金", Refresh));
            this.Types.Add(new MoneyChangeRecordTypeModel("分红", "分红", Refresh));
            this.Types.Add(new MoneyChangeRecordTypeModel("注册奖励", "注册奖励", Refresh));
            this.Types.Add(new MoneyChangeRecordTypeModel("消费奖励", "消费奖励", Refresh));
            this.Types.Add(new MoneyChangeRecordTypeModel("充值奖励", "充值奖励", Refresh));
            this.Types.Add(new MoneyChangeRecordTypeModel("积分兑换", "积分兑换", Refresh));
            client.GetMoneyChangeRecordsCompleted += ShowList;
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            string type = this.Types.Count == 0 ? null : this.types.First(x => x.Selected).Type;
            GetMoneyChangeRecordsImport import = new GetMoneyChangeRecordsImport
            {
                KeywordForUsername = this.KeywordForUsername,
                UserId = this.UserId,
                BeginTime = this.BeginTime,
                EndTime = this.EndTime,
                Type = type,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetMoneyChangeRecordsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForUsername = null;
            this.UserId = null;
            this.BeginTime = null;
            this.EndTime = null;
            this.Types.First(x => x.Type == null).Selected = true;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetMoneyChangeRecordsCompletedEventArgs e)
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
