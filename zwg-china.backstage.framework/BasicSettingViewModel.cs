using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 基础系统设置页的视图模型
    /// </summary>
    public class BasicSettingViewModel : ManagerViewModelBase
    {
        #region 私有字段

        int pageSizeForClient = 0;
        int pageSizeForAdmin = 0;
        int heartbeatInterval = 0;
        string workingHour_Begin = "";
        string workingHour_End = "";
        int virtualQueuing = 0;
        bool collectionRunning = true;

        AdministratorServiceClient client = new AdministratorServiceClient();

        #endregion

        #region 属性

        /// <summary>
        /// 前台页面大小（条）
        /// </summary>
        public int PageSizeForClient
        {
            get { return pageSizeForClient; }
            set
            {
                if (pageSizeForClient == value) { return; }
                pageSizeForClient = value;
                OnPropertyChanged("PageSizeForClient");
            }
        }

        /// <summary>
        /// 后台页面大小（条）
        /// </summary>
        public int PageSizeForAdmin
        {
            get { return pageSizeForAdmin; }
            set
            {
                if (pageSizeForAdmin == value) { return; }
                pageSizeForAdmin = value;
                OnPropertyChanged("PageSizeForAdmin");
            }
        }

        /// <summary>
        /// 心跳间隔（秒）
        /// </summary>
        public int HeartbeatInterval
        {
            get { return heartbeatInterval; }
            set
            {
                if (heartbeatInterval == value) { return; }
                heartbeatInterval = value;
                OnPropertyChanged("HeartbeatInterval");
            }
        }

        /// <summary>
        /// 允许取款时间 - 开始
        /// </summary>
        public string WorkingHour_Begin
        {
            get { return workingHour_Begin; }
            set
            {
                if (workingHour_Begin == value) { return; }
                workingHour_Begin = value;
                OnPropertyChanged("WorkingHour_Begin");
            }
        }

        /// <summary>
        /// 允许取款时间 - 结束
        /// </summary>
        public string WorkingHour_End
        {
            get { return workingHour_End; }
            set
            {
                if (workingHour_End == value) { return; }
                workingHour_End = value;
                OnPropertyChanged("WorkingHour_End");
            }
        }

        /// <summary>
        /// 取款虚拟排队
        /// </summary>
        public int VirtualQueuing
        {
            get { return virtualQueuing; }
            set
            {
                if (virtualQueuing == value) { return; }
                virtualQueuing = value;
                OnPropertyChanged("VirtualQueuing");
            }
        }

        /// <summary>
        /// 运行采集程序
        /// </summary>
        public bool CollectionRunning
        {
            get { return collectionRunning; }
            set
            {
                if (collectionRunning == value) { return; }
                collectionRunning = value;
                OnPropertyChanged("CollectionRunning");
            }
        }

        /// <summary>
        /// 刷新命令
        /// </summary>
        public UniversalCommand RefreshCommand { get; set; }

        /// <summary>
        /// 修改命令
        /// </summary>
        public UniversalCommand EditCommand { get; set; }

        #endregion

        #region 构造方法

        public BasicSettingViewModel()
            : base("系统设置", "基础系统设置")
        {
            this.RefreshCommand = new UniversalCommand(Refresh);
            this.EditCommand = new UniversalCommand(Edit);

            client.GetSettingOfBaseCompleted += ShowSetting;
            client.SetSettingOfBaseCompleted += ShowEditResult;
            Refresh();
        }

        #region 显示设置明细

        void ShowSetting(object sender, GetSettingOfBaseCompletedEventArgs e)
        {
            this.PageSizeForClient = e.Result.Info.PageSizeForClient;
            this.PageSizeForAdmin = e.Result.Info.PageSizeForAdmin;
            this.HeartbeatInterval = e.Result.Info.HeartbeatInterval;
            this.WorkingHour_Begin = e.Result.Info.WorkingHour_Begin;
            this.WorkingHour_End = e.Result.Info.WorkingHour_End;
            this.VirtualQueuing = e.Result.Info.VirtualQueuing;
            this.CollectionRunning = e.Result.Info.CollectionRunning;
        }

        #endregion

        #endregion

        #region 私有方法

        void Refresh(object obj = null)
        {
            GetSettingOfBaseImport import = new GetSettingOfBaseImport
            {
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetSettingOfBaseAsync(import);
        }

        void Edit(object obj = null)
        {
            IPop<string> cw = ViewModelService.GetPop(Pop.NormalPrompt) as IPop<string>;
            cw.State = "你确定要修改基础系统设置吗？";
            cw.Closed += Edit_do;
            cw.Show();
        }

        void Edit_do(object sender, EventArgs e)
        {
            IPop cw = (IPop)sender;
            if (cw.DialogResult != true) { return; }

            SetSettingOfBaseImport import = new SetSettingOfBaseImport
            {
                PageSizeForClient = this.PageSizeForClient,
                PageSizeForAdmin = this.PageSizeForAdmin,
                HeartbeatInterval = this.HeartbeatInterval,
                WorkingHour_Begin = this.WorkingHour_Begin,
                WorkingHour_End = this.WorkingHour_End,
                VirtualQueuing = this.VirtualQueuing,
                CollectionRunning = this.CollectionRunning,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.SetSettingOfBaseAsync(import);
        }
        void ShowEditResult(object sender, SetSettingOfBaseCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                ShowError("修改成功");
                Refresh();
            }
            else
            {
                ShowError(e.Result.Error);
            }
        }

        #endregion
    }
}
