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
            mailRequestAttachments.FileName = "������Դ�����ܱ�.xls";
            string body = "���ã����µĴ�ȷ���տ�� http://192.168.100.56/web/TechnicalReformation.html";
            //string bcc = string.Empty;
            string to = "nodbrag@qq.com";//�ռ���
            //string cc = "";//������
            MailRequest mail = new MailRequest();
            mail.Subject = "�տ�ȷ��";//����
            mail.Body = body;//����
           // mail.Bcc = bcc;//���ܳ�����
            //mail.From = "nodbrag@qq.com";//������
            mail.To = to; //�ռ���
            // mail.CC = cc; //������
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
