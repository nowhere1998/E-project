using MimeKit.Utils;
using MimeKit;
using MailKit.Net.Smtp;

namespace E_project.Models
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailWithImageAsync(string toEmail, string subject, string body, string imagePath)
        {
            // Tạo email message
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Your Name", _configuration["EmailSettings:SenderEmail"]));
            email.To.Add(new MailboxAddress("", toEmail));
            email.Subject = subject;

            // Tạo body chính và thêm ảnh
            var bodyBuilder = new BodyBuilder();

            // Chèn ảnh vào email
            var image = bodyBuilder.LinkedResources.Add(imagePath);
            image.ContentId = MimeUtils.GenerateMessageId(); // Tạo Content-ID để nhúng hình ảnh

            // Định nghĩa nội dung email
            bodyBuilder.HtmlBody = $@"
            <p>{body}</p>
            <img src=""cid:{image.ContentId}"" />
        ";
            email.Body = bodyBuilder.ToMessageBody();

            // Kết nối tới SMTP và gửi email
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_configuration["EmailSettings:SmtpServer"], int.Parse(_configuration["EmailSettings:SmtpPort"]), MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_configuration["EmailSettings:SenderEmail"], _configuration["EmailSettings:SenderPassword"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
