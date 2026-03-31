using Microsoft.AspNetCore.Mvc.RazorPages;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace CSharpVN_Community.Pages
{
    public class AccessDeniedModel : PageModel
    {
        private readonly Code _codeService;

        public AccessDeniedModel(Code codeService) // Inject Class Code vào đây
        {
            _codeService = codeService;
        }
        public string ClientIP { get; set; } = "Unknown";
        public async void OnGet()
        {
            // Ưu tiên lấy IP thật qua Header nếu chạy trên Render/Cloud
            ClientIP = Request.Headers["X-Forwarded-For"].FirstOrDefault()
                       ?? HttpContext.Connection.RemoteIpAddress?.ToString()
                       ?? "Unknown";
            await _codeService.GhiDuLieuLenCloud("SecurityLogs.txt", ClientIP);
        }
    }
}
