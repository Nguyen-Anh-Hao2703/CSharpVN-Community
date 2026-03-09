using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSharpVN_Community
{
    public class DongGopItem
    {
        public string? ThoiGian { get; set; }
        public string? NoiDung { get; set; }
    }
    public class WatchDonateModel : PageModel
    {
        public List<DongGopItem> DanhSachDongGop { get; set; } = new List<DongGopItem>();
        public IActionResult OnGet(string key)
        {
            string filePath;
            // Kiểm tra xem trong bộ nhớ Session có chữ "true" không
            var isAdmin = HttpContext.Session.GetString("IsAdmin");

            if (isAdmin != "true" || key != "@nhhao2703")
            {
                // Lấy địa chỉ IP của kẻ truy cập
                string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Nội dung ghi vào file nhật ký
                string warningContent = $"\n--- CẢNH BÁO XÂM NHẬP ---\n" +
                                        $"Thời gian: {time}\n" +
                                        $"IP: {ipAddress}\n" +
                                        $"Hành động: Truy cập trái phép trang WatchDonate\n" +
                                        $"--------------------------\n";

                // Ghi thẳng vào file DongGopCode.txt
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DongGopCode.txt");
                System.IO.File.AppendAllText(filePath, warningContent);

                // Đuổi về trang Login (nhớ dùng đúng tên file Login của Hào)
                return RedirectToPage("/AccessDenied");
            }
            if (key != "@nhhao2703") return Content("Sai mật mã!");

            filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DongGopCode.txt");

            if (System.IO.File.Exists(filePath))
            {
                var fullContent = System.IO.File.ReadAllText(filePath);

                // Tách file thành từng phần dựa trên dấu phân cách của Hào
                var entries = fullContent.Split(new[] { "--- Đóng góp mới" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var entry in entries)
                {
                    // Lấy dòng đầu tiên làm thời gian, phần còn lại là code
                    var lines = entry.Trim().Split('\n', 2);
                    if (lines.Length >= 1)
                    {
                        DanhSachDongGop.Add(new DongGopItem
                        {
                            ThoiGian = lines[0].Replace("---", "").Trim(),
                            NoiDung = lines.Length > 1 ? lines[1].Trim() : ""
                        });
                    }
                }
                // Đảo ngược danh sách để cái mới nhất hiện lên đầu
                DanhSachDongGop.Reverse();
            }
            return Page();
        }
    }
}
