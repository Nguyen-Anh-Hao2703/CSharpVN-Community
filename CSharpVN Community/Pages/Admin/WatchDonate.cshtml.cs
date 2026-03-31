using CSharpVN_Community.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Formats.Tar;

namespace CSharpVN_Community
{
    public class DongGopItem
    {
        public string? ThoiGian { get; set; }
        public string? NoiDung { get; set; }
    }
    public class WatchDonateModel : PageModel
    {
        private readonly Code _codeService;

        public WatchDonateModel(Code codeService) // Inject Class Code vào đây
        {
            _codeService = codeService;
        }
        public string code_đóng_góp;
        public string cảnh_báo;
        public List<DongGopItem> DanhSachDongGop { get; set; } = new List<DongGopItem>();
        public async Task<IActionResult> OnGet(string key)
        {
            string filePath;
            // Kiểm tra xem trong bộ nhớ Session có chữ "true" không
            var isAdmin = HttpContext.Session.GetString("IsAdmin");

            if (isAdmin != "true" || key != "@nhhao2703")
            {
                // Lấy địa chỉ IP của kẻ truy cập
                string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";
                await _codeService.GhiDuLieuLenCloud("SecurityLogs.txt", ipAddress);

                // Đuổi về trang Login (nhớ dùng đúng tên file Login của Hào)
                return RedirectToPage("/AccessDenied");
            }
            if (key != "@nhhao2703") return Content("Sai mật mã!");

            code_đóng_góp = await _codeService.LayNoiDungFile("Domain.txt");
            cảnh_báo = await _codeService.LayNoiDungFile("SecurityLogs.txt");
            return Page();
        }
    }
}
