using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.AdministratorService;
using zwg_china.backstage.framework.RecordOfAuthorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看转账记录页的数据模型
    /// </summary>
    public class TransferRecordsViewModel : ShowListViewModelBase<TransferRecordExport, RecordOfAuthorServiceClient>
    {
        #region 私有字段

        DateTime? beginTime = null;
        DateTime? endTime = null;
        string status = "all";

        #endregion

        #region 属性

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
        /// 状态
        /// </summary>
        public string Status
        {
            get { return status; }
            set
            {
                if (value == "") { return; }
                if (status == value) { return; }
                status = value;
                OnPropertyChanged("Status");
                Refresh(null);
            }
        }

        #endregion

        #region 构造方法

        public TransferRecordsViewModel()
            : base("数据报表", "查看转账记录")
        {
            client.GetTransferRecordsCompleted += ShowList;
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            TransferStatus? _status = null;
            if (this.Status != "all")
            {
                _status = (TransferStatus)Enum.Parse(typeof(TransferStatus), this.Status, false);
            }
            GetTransferRecordsImport import = new GetTransferRecordsImport
            {
                BeginTime = this.BeginTime,
                EndTime = this.EndTime,
                Status = _status,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetTransferRecordsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.BeginTime = null;
            this.EndTime = null;
            this.Status = "all";
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetTransferRecordsCompletedEventArgs e)
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
