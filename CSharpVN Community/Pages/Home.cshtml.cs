using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSharpVN_Community.Pages
{
    public class HomeModel : PageModel
    {
        public IActionResult OnGetXemDongGop(string key)
        {
            string secretKey = "@nhhao27O3"; // Mật khẩu của Hào

            if (key != secretKey)
            {
                return Content("Bạn không có quyền truy cập!");
            }

            // Đường dẫn này sẽ lấy file ngay tại thư mục gốc của ứng dụng trên Render
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DongGopCode.txt");

            if (!System.IO.File.Exists(filePath))
            {
                return Content("Chưa có ai đóng góp code cả.");
            }

            string content = System.IO.File.ReadAllText(filePath);
            return Content(content);
        }
    }
}
