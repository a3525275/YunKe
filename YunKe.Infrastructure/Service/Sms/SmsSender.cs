using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace YunKe.Infrastructure.Service.Sms
{
    public class SmsSender : ISmsSender
    {
        private readonly ISmsAccountProvider _account;

        public SmsSender(ISmsAccountProvider account)
        {
            _account = account;
        }

        public void SendSms(string mobile, string content)
        {
            Send(mobile, content);
        }

        private void Send(string mobile, string content)
        {
            string postStrTpl = "account={0}&password={1}&mobile={2}&content={3}";

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(string.Format(postStrTpl, _account.SmsAccount, _account.SmsSecurity,
                mobile, content));

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(_account.SmsApiUrl);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                //反序列化upfileMmsMsg.Text
                //实现自己的逻辑
            }
            else
            {
                throw new Exception("发送失败：" + myResponse);
                //访问失败
            }
        }
    }
}
