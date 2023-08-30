using ElgrosWeb.Server.Facades.Interfaces;
using System.Net;
using System.Net.Mail;

namespace ElgrosWeb.Server.Facades
{
    public class NotificationFacade : INotificationFacade
    {
        public async Task SendEmail(string content, string recipientEmail)
        {
            var smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("####", "####"),
                EnableSsl = true,
            };

            await smtpClient.SendMailAsync("benjaminroesdal@hotmail.com", recipientEmail, "Elgros ordrebekræftelse", content);
        }
    }
}
