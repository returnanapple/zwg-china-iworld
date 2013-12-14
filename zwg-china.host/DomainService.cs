using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.ServiceModel;

namespace zwg_china.host
{
    /// <summary>
    /// 域名跨域服务
    /// </summary>
    public class DomainService : IDomainService
    {
        /// <summary>
        /// 获取跨域文件
        /// </summary>
        /// <returns>返回跨域文件</returns>
        public Message GetPolicyFile()
        {
            try
            {
                XElement doc = XElement.Load(@"Content/clientaccesspolicy.xml");
                return Message.CreateMessage(MessageVersion.None, "", doc);
            }
            catch (Exception ex)
            {
                throw new FaultException<string>(ex.Message);
            }
        }
    }
}
