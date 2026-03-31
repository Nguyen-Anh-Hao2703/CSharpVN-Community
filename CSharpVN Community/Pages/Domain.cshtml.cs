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
        public async void OnPost(string Code)
        {
            if (!string.IsNullOrEmpty(Code))
            {
                string time = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
                await _codeService.GhiDuLieuLenCloud("Domain.txt", "------------------" + Environment.NewLine + time + Environment.NewLine + Code);

                // Thông báo cho người dùng biết đã gửi thành công
                ViewData["Message"] = "Chủ sở hữu đã nhận được code của bạn!";
            }
        }
    }
}
