using Microsoft.AspNetCore.Mvc.RazorPages;
using MailKit.Net.Smtp;
using MimeKit;

namespace CSharpVN_Community.Pages
{
    public class AccessDeniedModel : PageModel
    {
        public string ClientIP { get; set; } = "Unknown";
        public async Task OnGet()
        {
            // Ưu tiên lấy IP thật qua Header nếu chạy trên Render/Cloud
            ClientIP = Request.Headers["X-Forwarded-For"].FirstOrDefault()
                       ?? HttpContext.Connection.RemoteIpAddress?.ToString()
                       ?? "Unknown";
            try
            {
                await SendSecurityAlert(ClientIP);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi gửi mail: " + ex.Message);
            }
        }
        public async Task SendSecurityAlert(string hackerIP)
        {
            string password = Environment.GetEnvironmentVariable("OUTLOOK_PASS");
            string email = Environment.GetEnvironmentVariable("OUTLOOK");
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("CSharpVN System", email));
            message.To.Add(new MailboxAddress("Admin Hào", email));
            message.Subject = "⚠️ CẢNH BÁO BẢO MẬT - TRUY CẬP TRÁI PHÉP";

            message.Body = new TextPart("html")
            {
                Text = $@"
                <div style='font-family: sans-serif; border: 2px solid red; padding: 20px;'>
                    <h2 style='color: red;'>Phát hiện xâm nhập!</h2>
                    <p>Hệ thống CSharpVN vừa chặn một truy cập trái phép.</p>
                    <p><b>Địa chỉ IP:</b> {hackerIP}</p>
                    <p><b>Thời gian:</b> {DateTime.Now:dd/MM/yyyy HH:mm:ss}</p>
                    <hr>
                    <p style='font-size: 12px;'>Đây là thông báo tự động từ CSharpVN Community Server.</p>
                </div>"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp-mail.outlook.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(email, password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
