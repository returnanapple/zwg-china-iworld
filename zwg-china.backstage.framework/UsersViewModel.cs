using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.AuthorService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看用户列表页的视图模型
    /// </summary>
    public class UsersViewModel : ShowListViewModelBase<AuthorExport, AuthorServiceClient>
    {
        #region 私有字段

        string keywordForUsername = null;
        ObservableCollection<BasicUserGroupModel> groups = new ObservableCollection<BasicUserGroupModel>();
        int? belongingUserId = null;

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
        /// 用户组
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

        /// <summary>
        /// 所隶属的上级（无论是否直属）用户的存储指针
        /// </summary>
        public int? BelongingUserId
        {
            get { return belongingUserId; }
            set
            {
                if (belongingUserId == value) { return; }
                belongingUserId = value;
                OnPropertyChanged("BelongingUserId");
            }
        }

        #endregion

        #region 构造方法

        public UsersViewModel()
            : base("用户管理", "查看用户列表")
        {
            this.Groups.Add(new BasicUserGroupModel(null, "全部", Refresh, true));

            client.GetUsersCompleted += ShowList;
            client.GetBasicUserGroupsCompleted += InsetBasicGroups;
            GetBasicUserGroupsImport import = new GetBasicUserGroupsImport
            {
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetBasicUserGroupsAsync(import);
        }

        void InsetBasicGroups(object sender, GetBasicUserGroupsCompletedEventArgs e)
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
            GetUsersImport import = new GetUsersImport
            {
                KeywordForUsername = this.KeywordForUsername,
                GroupId = id,
                BelongingUserId = this.BelongingUserId,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetUsersAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForUsername = null;
            this.Groups.First(x => x.Id == null).Selected = true;
            this.BelongingUserId = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetUsersCompletedEventArgs e)
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
