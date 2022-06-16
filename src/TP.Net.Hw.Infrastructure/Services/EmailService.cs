using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using TP.Net.Hw.Application.Interfaces.Services;

namespace TP.Net.Hw.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IReportService _reportService;

        public EmailService(IConfiguration configuration, IReportService reportService)
        {
            _configuration = configuration;
            _reportService = reportService;
        }
        public async Task SendEmailReport()
        {
            //Calling the excel report export service!
            await _reportService.GetUsersExcelReport();

            //Creating mail configurations
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["MailBox:From"]));
            email.To.Add(MailboxAddress.Parse(_configuration["MailBox:To"]));
            email.Subject = "Daily Report";

            //Creating a mail body
            var builder = new BodyBuilder();

            //adding an HTML Template to mail..
            var mailBodyPath = Directory.GetParent(Directory.GetCurrentDirectory()) + "\\TP.Net.Hw.Infrastructure\\Common\\Templates\\mailbody.html";
            var str = new StreamReader(mailBodyPath);
            var mailText = str.ReadToEnd();
            str.Close();
            mailText = mailText.Replace("[username]", "").Replace("[email]", "");

            //Adding this template to builder body.
            builder.HtmlBody = mailText;

            //Adding excel file into attachment to builder body.
            var path = new DirectoryInfo(@"C:\TPReports").GetFiles().OrderByDescending(d => d.CreationTime).FirstOrDefault().ToString();
            builder.Attachments.Add(path);
            email.Body = builder.ToMessageBody();

            //Sending mail configurations
            using var smtp = new SmtpClient();
            smtp.Connect(
                host: _configuration["Smtp:Host"],
                port: Convert.ToInt32(_configuration["Smtp:Port"]),
                options: SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration["Smtp:Email"], _configuration["Smtp:Password"]);

            //Send the mail and disconnect from smtp server!..
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
