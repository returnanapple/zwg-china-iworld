using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 定义列表页的视图模型
    /// </summary>
    public interface IShowListViewModel
    {
        /// <summary>
        /// 刷新列表
        /// </summary>
        void Refresh();
    }
}
