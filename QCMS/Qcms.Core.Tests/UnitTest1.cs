using System;
using Xunit;
using Qcms.Core.Email;

namespace Qcms.Core.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            MailRequestAttachments mailRequestAttachments = new MailRequestAttachments();
            mailRequestAttachments.FileData=System.IO.File.ReadAllBytes("F://export.xls");
            mailRequestAttachments.FileName = "车间能源消耗周报.xls";
            string body = "您好，有新的待确认收款≥ http://192.168.100.56/web/TechnicalReformation.html";
            //string bcc = string.Empty;
            string to = "nodbrag@qq.com";//收件人
            //string cc = "";//抄送人
            MailRequest mail = new MailRequest();
            mail.Subject = "收款确认";//主题
            mail.Body = body;//内容
           // mail.Bcc = bcc;//秘密抄送人
            //mail.From = "nodbrag@qq.com";//发送人
            mail.To = to; //收件人
            // mail.CC = cc; //抄送人
            mail.Attachments = new MailRequestAttachments[] { mailRequestAttachments };
            string sendMainResult = "-1";
            if (!string.IsNullOrEmpty(mail.To.Trim()) || !string.IsNullOrEmpty(mail.CC.Trim()))
            {
                sendMainResult = SendMailHelper.SendMail(mail);
                Assert.True(string.IsNullOrEmpty(sendMainResult));
            }
        }
    }
}
