using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace zwg_china.model
{
    /// <summary>
    ///  类目相关的数据模型的基类
    /// </summary>
    public abstract class CategoryModelBase : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 父祖节点
        /// </summary>
        public List<Relative> Relatives { get; set; }

        /// <summary>
        /// 所从属的树
        /// </summary>
        public string Tree { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        public int Layer { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的树状结构的数据模型
        /// </summary>
        public CategoryModelBase()
        {
        }

        /// <summary>
        /// 实例化一个新的树状结构的数据模型
        /// </summary>
        /// <param name="relatives">父祖节点</param>
        /// <param name="tree">所从属的树</param>
        public CategoryModelBase(List<Relative> relatives, string tree = "")
        {
            if (relatives == null)
            {
                this.Relatives = new List<Relative>();
                this.Layer = 1;
                this.Tree = Guid.NewGuid().ToString("N");
            }
            else if (relatives.Count > 0)
            {
                this.Relatives = relatives;
                this.Layer = relatives.Max(x => x.NodeLayer) + 1;

                Regex reg = new Regex(@"^[a-zA-Z0-9]{32}$");
                if (!reg.IsMatch(tree))
                {
                    throw new Exception("树状结构的名称应为32位的guid");
                }
                this.Tree = tree;
            }
            else
            {
                throw new Exception("输入的父祖节点不应为空列表 如果该对象是第一级节点 请将父祖节点输入为null");
            }
        }

        #endregion
    }
}
