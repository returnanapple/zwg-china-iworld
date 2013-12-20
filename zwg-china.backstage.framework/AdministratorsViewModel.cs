using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看管理员列表的视图模型
    /// </summary>
    public class AdministratorsViewModel : ShowListViewModelBase<BasicAdministratorExport, AdministratorServiceClient>
    {
        #region 私有字段

        string keywordForUsername = null;
        int? groupId = null;

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
                keywordForUsername = value;
                OnPropertyChanged("KeywordForUsername");
            }
        }

        /// <summary>
        /// 所从属的用户组的存储指针
        /// </summary>
        public int? GroupId
        {
            get { return groupId; }
            set
            {
                if (groupId == value) { return; }
                groupId = value;
                OnPropertyChanged("GroupId");
            }
        }

        #endregion

        #region 构造方法

        public AdministratorsViewModel()
            : base("管理员组", "查看管理员列表")
        {
            client.GetAdministratorsCompleted += ShowList;
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetAdministratorsImport import = new GetAdministratorsImport
            {
                KeywordForUsername = this.KeywordForUsername,
                GroupId = this.GroupId,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetAdministratorsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForUsername = null;
            this.GroupId = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetAdministratorsCompletedEventArgs e)
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
