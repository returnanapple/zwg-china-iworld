using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<BasicUserGroupModel> groups = new ObservableCollection<BasicUserGroupModel>();

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
        /// 管理员组
        /// </summary>
        public ObservableCollection<BasicUserGroupModel> Groups
        {
            get { return groups; }
            set
            {
                if (groups == value) { return; }
                groups = value;
                OnPropertyChanged("Groups");
            }
        }

        #endregion

        #region 构造方法

        public AdministratorsViewModel()
            : base("管理员组", "查看管理员列表")
        {
            this.Groups.Add(new BasicUserGroupModel(null, "全部", Refresh, true));

            client.GetAdministratorsCompleted += ShowList;
            client.GetBasicAdministratorGroupsCompleted += InsetBasicGroups;
            GetBasicAdministratorGroupsImport import = new GetBasicAdministratorGroupsImport
            {
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetBasicAdministratorGroupsAsync(import);
        }

        void InsetBasicGroups(object sender, GetBasicAdministratorGroupsCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                e.Result.Info.ForEach(x => this.Groups.Add(new BasicUserGroupModel(x.Id, x.Name, Refresh)));
            }
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            int? id = this.groups.Count == 0 ? null : this.Groups.First(x => x.Selected).Id;
            GetAdministratorsImport import = new GetAdministratorsImport
            {
                KeywordForUsername = this.KeywordForUsername,
                GroupId = id,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetAdministratorsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForUsername = null;
            this.Groups.First(x => x.Id == null).Selected = true;
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
