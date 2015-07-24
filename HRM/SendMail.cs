using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace HRM
{
    public static class SendMail
    {
        public static void Send(string[] to, string subject, string body)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            try
            {
                foreach (string s in to)
                {
                    MailAddress toAddress = new MailAddress(s, s);
                    message.To.Add(toAddress);
                }

                message.Subject = subject;
                message.Body = body;
                smtpClient.Send(message);
            }
            catch (Exception)
            {
                throw new Exception("Mail couldnt be sent");
            }
        }
    }
}