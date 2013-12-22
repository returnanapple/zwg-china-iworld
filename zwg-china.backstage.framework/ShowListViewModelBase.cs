using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 列表页的视图模型的基类
    /// </summary>
    public abstract class ShowListViewModelBase<TExport, TClient> : ManagerViewModelBase, IShowListViewModel
        where TClient : new()
    {
        #region 私有字段

        int pageIndex = 0;
        int totalPage = 0;
        ObservableCollection<TExport> list = new ObservableCollection<TExport>();
        protected TClient client = new TClient();

        #endregion

        #region 属性

        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex
        {
            get
            {
                return pageIndex;
            }
            set
            {
                if (pageIndex != value)
                {
                    pageIndex = value;
                    OnPropertyChanged("PageIndex");
                }
            }
        }

        /// <summary>
        /// 全部页面数量
        /// </summary>
        public int TotalPage
        {
            get
            {
                return totalPage;
            }
            set
            {
                if (totalPage != value)
                {
                    totalPage = value;
                    OnPropertyChanged("TotalPage");
                }
            }
        }

        /// <summary>
        /// 列表
        /// </summary>
        public ObservableCollection<TExport> List
        {
            get
            {
                return list;
            }
            set
            {
                if (list != value)
                {
                    list = value;
                    OnPropertyChanged("List");
                }
            }
        }

        /// <summary>
        /// 刷新列表的命令
        /// </summary>
        public UniversalCommand RefreshCommand { get; set; }

        /// <summary>
        /// 重置列表的命令
        /// </summary>
        public UniversalCommand RestCommand { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的列表页的试图的基类
        /// </summary>
        /// <param name="selectedText_Menu">导航选择文本</param>
        /// <param name="selectedText_Page">页面选择文本</param>
        public ShowListViewModelBase(string selectedText_Menu, string selectedText_Page)
            : base(selectedText_Menu, selectedText_Page)
        {
            this.RefreshCommand = new UniversalCommand(Refresh);
            this.RestCommand = new UniversalCommand(Reset);
            Refresh(null);
        }

        #endregion

        #region 保护方法

        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="obj">参数</param>
        protected abstract void Refresh(object obj);

        /// <summary>
        /// 充值列表
        /// </summary>
        /// <param name="obj"></param>
        protected abstract void Reset(object obj);

        /// <summary>
        /// 更新列表显示
        /// </summary>
        /// <param name="es">新的内容</param>
        protected void UpdateLsit(List<TExport> es)
        {
            this.List.Clear();
            es.ForEach(e => this.List.Add(e));
        }

        #endregion

        #region 方法

        /// <summary>
        /// 刷新列表
        /// </summary>
        public void Refresh()
        {
            this.JumpCommand.Execute(this.SelectedText_Page);
        }

        #endregion
    }
}
