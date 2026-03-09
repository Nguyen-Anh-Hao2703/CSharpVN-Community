using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSharpVN_Community.Admin
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string? AdminPassword { get; set; }
        public string? ErrorMessage { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            // Kiểm tra mật khẩu của Hào
            if (AdminPassword == "@nhhao19O3")
            {
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToPage("/Admin/WatchDonate", new { key = "@nhhao2703" });
            }

            ErrorMessage = "Mật mã sai! Truy cập bị từ chối.";
            return Page();
        }
    }
}
