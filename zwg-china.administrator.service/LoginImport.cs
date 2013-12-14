using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.RegularExpressions;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;


namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于登陆的数据集
    /// </summary>
    [DataContract]
    public class LoginImport : ImportBase, AdministratorManager.IPackageForLogin
    {
        #region 属性

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// 网络地址
        /// </summary>
        [DataMember]
        public string Ip { get; set; }

        /// <summary>
        /// 实际地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 判定当前用户是否允许执行操作
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public override void CheckAllowExecuteOrNot(ModelToDbContext db)
        {
            var endpoint = OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            this.Ip = endpoint.Address;

            IpToAddressComparison ipToAddress = db.IpToAddressComparisons.FirstOrDefault(x => x.Ip == this.Ip);
            if (ipToAddress != null)
            {
                this.Address = ipToAddress.Address;
            }
            else
            {
                string path = "http://www.ip138.com/ips138.asp?ip=" + this.Ip;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(path);
                request.Method = "GET";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("gb2312"));
                string html = reader.ReadToEnd();
                stream.Close();

                Regex reg = new Regex("<ul class=\"ul1\"><li>本站主数据：([\\w\\W]*)</li><li>参考数据");
                this.Address = reg.Match(html).Groups[1].Value;
                ipToAddress = new IpToAddressComparison(this.Ip, this.Address);
                db.IpToAddressComparisons.Add(ipToAddress);
                db.SaveChanges();
            }
        }

        #endregion
    }
}
