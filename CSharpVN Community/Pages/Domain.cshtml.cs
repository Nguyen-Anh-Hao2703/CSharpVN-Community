using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSharpVN_Community.Pages
{
    public class DomainModel : PageModel
    {
        // Hàm này sẽ chạy khi người dùng nhấn nút "Gửi"
        public void OnPost(string CodeHao)
        {
            if (!string.IsNullOrEmpty(CodeHao))
            {
                // Cách 1: Lưu tạm vào một file .txt trên máy chủ của bạn
                // Code này sẽ chạy được ở cả máy Hào và máy chủ bên Mỹ
                string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                string filePath = Path.Combine(rootPath, "DongGopCode.txt");
                System.IO.File.AppendAllText(filePath, CodeHao + Environment.NewLine);
                System.IO.File.AppendAllText(filePath, $"\n--- Đóng góp mới ({DateTime.Now}) ---\n" + CodeHao);

                // Thông báo cho người dùng biết đã gửi thành công
                ViewData["Message"] = "Chủ sở hữu đã nhận được code của bạn!";
            }
        }
    }
}
