using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.aid;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    [DataContract]
    public class CreateBulleinImport : ImportBaseOfMessage, IPackageForCreateModel<IModelToDbContextOfMessage, Bulletin>
    {
        #region 属性

        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        [DataMember]
        public string Context { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember]
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 一个布尔值 标识活动是否暂停
        /// </summary>
        [DataMember]
        public bool Hide { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfMessage db)
        {
            this.Title = VerifyHelper.EliminateSpaces(this.Title);
            this.Context = VerifyHelper.EliminateSpaces(this.Context);
            if (this.EndTime < this.BeginTime)
            {
                throw new Exception("结束时间不能小于开始时间，请检查输入");
            }
        }

        /// <summary>
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public Bulletin GetModel(IModelToDbContextOfMessage db)
        {
            return new Bulletin(this.Title, this.Context, this.BeginTime, this.EndTime, this.Hide);
        }

        #endregion
    }
}
