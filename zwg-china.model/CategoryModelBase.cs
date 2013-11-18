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
        public virtual List<Relative> Relatives { get; set; }

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
        /// <param name="parent">父节点</param>
        public CategoryModelBase(CategoryModelBase parent)
        {
            this.Relatives = new List<Relative>();
            if (parent == null)
            {
                this.Layer = 1;
                this.Tree = Guid.NewGuid().ToString("N");
            }
            else
            {
                this.Layer = parent.Layer + 1;
                this.Tree = parent.Tree;
                parent.Relatives.OrderBy(x => x.NodeLayer).ToList().ForEach(x =>
                    {
                        this.Relatives.Add(new Relative(x.NodeId, x.NodeLayer));
                    });
                this.Relatives.Add(new Relative(parent.Id, parent.Layer));
            }
        }

        #endregion
    }
}
