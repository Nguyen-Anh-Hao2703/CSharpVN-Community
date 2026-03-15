using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSharpVN_Web.Pages
{
    public class IndexModel : PageModel
    {
        // Định nghĩa cấu trúc thông tin một Package
        public class PackageInfo
        {
            public string Ten { get; set; }
            public string MoTa { get; set; }
            public string LinkNuget { get; set; }
            public string Icon { get; set; } // Dùng Icon để nhìn cho đẹp
        }

        public List<PackageInfo> DanhSachPackages { get; set; }

        public void OnGet()
        {
            // Thêm các package của Hào vào đây
            DanhSachPackages = new List<PackageInfo>
            {
                new PackageInfo {
                    Ten = "CSharpVN.System",
                    MoTa = "Thư viện cốt lõi cho ngôn ngữ CSharpVN.",
                    LinkNuget = "https://www.nuget.org/packages/CSharpVN.System",
                    Icon = "📦"
                },
                new PackageInfo {
                    Ten = "CSharpVN.IO",
                    MoTa = "Hỗ trợ nhập xuất dữ liệu thuần Việt.",
                    LinkNuget = "https://www.nuget.org/packages/CSharpVN.IO",
                    Icon = "💾"
                },
                new PackageInfo {
                    Ten = "CSharpVN.System.Math",
                    MoTa = "Các hàm toán học: Số nguyên tố, lũy thừa, căn bậc hai...",
                    LinkNuget = "https://www.nuget.org/packages/CSharpVN.System.Math",
                    Icon = "📐"
                },
                new PackageInfo {
                    Ten = "CSharpVN.Language",
                    MoTa = "Các hàm xử lí Ngôn ngữ...",
                    LinkNuget = "https://www.nuget.org/packages/CSharpVN.Language",
                    Icon = "🔤"
                }
            };
        }
    }
}