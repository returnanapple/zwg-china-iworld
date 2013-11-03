using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 类目相关的数据模型的基类的拓展
    /// </summary>
    public static class CategoryModelBaseExtensions
    {
        #region 静态方法

        /// <summary>
        /// 判断当前对象是否与目标对象位于同一节点树
        /// </summary>
        /// <param name="self">当前对象</param>
        /// <param name="beau">目标对象</param>
        /// <returns>返回一个布尔值 标识当前对象是否与目标对象位于同一节点树</returns>
        public static bool IsInSameTree(this CategoryModelBase self, CategoryModelBase beau)
        {
            bool result = self.Tree == beau.Tree;
            return result;
        }

        /// <summary>
        /// 判断当前对象是否是目标对象的父祖节点
        /// </summary>
        /// <param name="self">当前对象</param>
        /// <param name="beau">目标对象</param>
        /// <returns>返回一个布尔值 标识当前对象是否是目标对象的父祖节点</returns>
        public static bool IsAncestry(this CategoryModelBase self, CategoryModelBase beau)
        {
            bool result = self.Tree == beau.Tree
                && beau.Relatives.Any(x => x.NodeId == self.Id);
            return result;
        }

        /// <summary>
        /// 判断当前对象是否是目标对象的父节点
        /// </summary>
        /// <param name="self">当前对象</param>
        /// <param name="beau">目标对象</param>
        /// <returns>返回一个布尔值 标识当前对象是否是目标对象的父节点</returns>
        public static bool IsParent(this CategoryModelBase self, CategoryModelBase beau)
        {
            bool result = self.Tree == beau.Tree
                && beau.Relatives.Any(x => x.NodeId == self.Id)
                && self.Layer == beau.Layer - 1;
            return result;
        }

        /// <summary>
        /// 判断当前对象是否是目标对象的子节点
        /// </summary>
        /// <param name="self">当前对象</param>
        /// <param name="beau">目标对象</param>
        /// <returns>返回一个布尔值 标识当前对象是否是目标对象的子节点</returns>
        public static bool IsChild(this CategoryModelBase self, CategoryModelBase beau)
        {
            bool result = self.Tree == beau.Tree
                   && self.Relatives.Any(x => x.NodeId == beau.Id)
                   && beau.Layer == self.Layer - 1;
            return result;
        }

        /// <summary>
        /// 判断当前对象是否是目标对象的子孙节点
        /// </summary>
        /// <param name="self">当前对象</param>
        /// <param name="beau">目标对象</param>
        /// <returns>返回一个布尔值 标识当前对象是否是目标对象的子孙节点</returns>
        public static bool IsOffspring(this CategoryModelBase self, CategoryModelBase beau)
        {
            bool result = self.Tree == beau.Tree
                   && self.Relatives.Any(x => x.NodeId == beau.Id);
            return result;
        }

        #endregion
    }
}
