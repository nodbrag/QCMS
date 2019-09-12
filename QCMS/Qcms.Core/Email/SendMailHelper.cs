using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.IO;
namespace Qcms.Core.Email
{
   #region 邮件帮助类
       /// <summary>
       /// 邮件帮助类
       /// </summary>
       public static class SendMailHelper
       {
           /// <summary>
           /// 发送邮件
           /// </summary>
         /// <param name="request">邮件内容对象</param>
          /// <returns>发送邮件所遇到的异常</returns>
          public static string SendMail(MailRequest request)
          {
              try
              {
                  MailMessage mail = new MailMessage();
  
                  if (string.IsNullOrEmpty(request.From))
                  {
                    request.From ="czwytest@163.com";
                  }
                  mail.From = new MailAddress(request.From, "Tetra Pak Admin");
  
                  PaserMailAddress(request.To, mail.To);
                  PaserMailAddress(request.CC, mail.CC);
                  PaserMailAddress(request.Bcc, mail.Bcc);
  
                  mail.Subject = request.Subject;
                  mail.SubjectEncoding = System.Text.Encoding.UTF8;
                  mail.Body = request.Body;
                  mail.ReplyTo = new MailAddress(request.From);
                  mail.IsBodyHtml = true;
  
                  if (request.Attachments != null && request.Attachments.Length > 0)
                  {
                      for (int i = 0; i<request.Attachments.Length; i++)
                      {
                          Attachment mailAttach = new Attachment(ByteArrayToStream(request.Attachments[i].FileData), request.Attachments[i].FileName);
  
                          mail.Attachments.Add(mailAttach);
                      }
                  }
              
                  //Smtp Server
                SmtpClient mailClient = new SmtpClient();
                mailClient.Port = 25; 
                mailClient.Host = "smtp.163.com";
                mailClient.Credentials = new System.Net.NetworkCredential("czwytest@163.com", "123456789a");
                mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                 
  
                mailClient.Send(mail);
                mail.Dispose();
  
                  return string.Empty;
              }
              catch (SmtpFailedRecipientsException e)
              {
                  return e.Message;
             }
              catch (SmtpFailedRecipientException e)
              {
                  return e.Message;
              }
              catch (SmtpException e)
              {
                  return e.Message;
              }
              catch (Exception e)
              {
                  return e.Message;
              }
          }
  
          /// <summary>
          /// 解析分解邮件地址
         /// </summary>
         /// <param name="mailAddress">邮件地址</param>
         /// <param name="mailCollection">邮件对象</param>
         private static void PaserMailAddress(string mailAddress, MailAddressCollection mailCollection)
         {
             if (string.IsNullOrEmpty(mailAddress))
             {
                 return;
             }
 
             char[] separator = new char[2] { ',', ';' };
             string[] addressArray = mailAddress.Split(separator);
 
             foreach (string address in addressArray)
             {
                 if (address.Trim() == string.Empty)
                 {
                     continue;
                 }
 
                 mailCollection.Add(new MailAddress(address));
             }
         }
 
         /// <summary>
         /// 字节数组转换为流
         /// </summary>
         /// <param name="byteArray">字节数组</param>
         /// <returns>Stream</returns>
         private static Stream ByteArrayToStream(byte[] byteArray)
         {
             MemoryStream mstream = new MemoryStream(byteArray);

            return mstream;
         }
     }
    #endregion
}
