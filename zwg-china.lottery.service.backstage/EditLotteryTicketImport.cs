using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于修改彩票信息的数据集
    /// </summary>
    [DataContract]
    public class EditLotteryTicketImport : ImportBaseOfLottery, IPackageForUpdateModel<IModelToDbContextOfLottery, LotteryTicket>
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 下辖的玩法标签
        /// </summary>
        [DataMember]
        public List<EditPlayTagImport> Tags { get; set; }

        /// <summary>
        /// 开奖时间
        /// </summary>
        [DataMember]
        public List<EditLotteryTimeImport> Times { get; set; }

        /// <summary>
        /// 一个布尔值，表示该彩票是否对前台客户隐藏
        /// </summary>
        [DataMember]
        public bool Hide { get; set; }

        /// <summary>
        /// 排序系数
        /// </summary>
        [DataMember]
        public int Order { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfLottery db)
        {
        }

        /// <summary>
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        public void Update(LotteryTicket model)
        {
            model.Name = this.Name;
            model.Hide = this.Hide;
            model.Order = this.Order;
            model.Tags
                .ForEach(tag =>
                {
                    EditPlayTagImport eTag = this.Tags.FirstOrDefault(x => x.Name == tag.Name);
                    if (eTag == null) { return; }
                    tag.Hide = eTag.Hide;
                    tag.HowToPlays
                        .ForEach(howToPlay =>
                        {
                            EditHowToPlayImport eHowToPlay = eTag.HowToPlays.FirstOrDefault(x => x.Name == howToPlay.Name);
                            if (eHowToPlay == null) { return; }
                            howToPlay.Hide = eHowToPlay.Hide;
                        });
                });
            model.Times
                .ForEach(time =>
                {
                    EditLotteryTimeImport eTime = this.Times.FirstOrDefault(x => x.Issue == time.Issue);
                    if (eTime == null) { return; }
                    time.TimeValue = eTime.TimeValue;
                });
        }

        #endregion
    }
}
