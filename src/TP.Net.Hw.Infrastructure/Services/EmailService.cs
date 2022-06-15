using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using TP.Net.Hw.Application.Interfaces.Services;

namespace TP.Net.Hw.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _path = new DirectoryInfo(@"C:\TPReports").GetFiles().OrderByDescending(d => d.CreationTime).FirstOrDefault().ToString();

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmailReport()
        {
            //Creating mail configurations
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["MailBox:From"]));
            email.To.Add(MailboxAddress.Parse(_configuration["MailBox:To"]));
            email.Subject = "Daily Report";

            //Creating a mail body
            var builder = new BodyBuilder();

            //adding an HTML Template to mail..
            string mailBodyPath = Directory.GetParent(Directory.GetCurrentDirectory()) + "\\TP.Net.Hw.Infrastructure\\Common\\Templates\\mailbody.html";
            StreamReader str = new StreamReader(mailBodyPath);
            string mailText = str.ReadToEnd();
            str.Close();
            mailText = mailText.Replace("[username]", "").Replace("[email]", "");


            //Adding this template to builder body.
            builder.HtmlBody = mailText;
            builder.Attachments.Add(_path);
            email.Body = builder.ToMessageBody();

            //Sending mail configurations
            using var smtp = new SmtpClient();
            smtp.Connect(_configuration["Smtp:Host"], 
                Convert.ToInt32(_configuration["Smtp:Port"]), 
                SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration["Smtp:Email"], _configuration["Smtp:Password"]);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
