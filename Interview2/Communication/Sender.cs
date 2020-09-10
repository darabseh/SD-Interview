using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Interview2.Communication
{
    public static class Sender
    {
        public static void Send(object communication)
        {
            if (communication is Email)
            {

                Email email = (Email)communication;

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress(email.From);
                message.To.Add(new MailAddress(email.To));
                message.Subject = email.Subject;
                message.IsBodyHtml = email.IsBodyHtml;
                message.Body = email.Body;

                smtp.Host = "GVAEXHUB02.EU.IOM.NET";
                smtp.UseDefaultCredentials = false;
               
                Console.WriteLine($"Send email to {email.To}");
                smtp.Send(message);
            }
            else if (communication is SMS)
            {
                SMS sms = (SMS)communication;
               
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:64195/");
                var json = JsonConvert.SerializeObject(sms);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                Console.WriteLine($"Send SMS to {sms.To}");
                client.PostAsync("api/sms", data);
            }
        }
    }
}
