using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CSharpVN_Community.Pages
{
    public class DomainModel : PageModel
    {
        private readonly Code _codeService;

        public DomainModel(Code codeService) // Inject Class Code vào đây
        {
            _codeService = codeService;
        }
        // Hàm này sẽ chạy khi người dùng nhấn nút "Gửi"
        public async Task<IActionResult> OnPostAsync(string Code) // Đổi tên thành OnPostAsync cho chuẩn
        {
            if (!string.IsNullOrEmpty(Code))
            {
                string time = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");

                // Dùng await ở đây để chắc chắn dữ liệu đã lên tới Cloud
                await _codeService.GhiDuLieuLenCloud("Domain.txt", "------------------" + Environment.NewLine + time + Environment.NewLine + Code);

                ViewData["Message"] = "Chủ sở hữu đã nhận được code của bạn!";
            }

            // Trả về chính trang hiện tại sau khi xử lý xong
            return Page();
        }
    }
}
