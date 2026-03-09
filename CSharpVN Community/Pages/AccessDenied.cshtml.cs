using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSharpVN_Community.Pages
{
    public class AccessDeniedModel : PageModel
    {
        public string ClientIP { get; set; } = "Unknown";
        public void OnGet()
        {
            // Ưu tiên lấy IP thật qua Header nếu chạy trên Render/Cloud
            ClientIP = Request.Headers["X-Forwarded-For"].FirstOrDefault()
                       ?? HttpContext.Connection.RemoteIpAddress?.ToString()
                       ?? "Unknown";
        }
    }
}
