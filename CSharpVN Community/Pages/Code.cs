using Supabase;
using System.Text;
using Supabase.Storage;

namespace CSharpVN_Community.Pages
{
    public class Code
    {
        // Khai báo supabase client ở đây
        private readonly Supabase.Client _supabase;

        public Code(Supabase.Client supabase)
        {
            _supabase = supabase;
        }

        public async Task GhiDuLieuLenCloud(string tenFile, string noiDung)
        {
            var storage = _supabase.Storage.From("files");

            string cu = "";
            try
            {
                var bytes = await storage.Download(tenFile, (EventHandler<float>?)null);
                cu = Encoding.UTF8.GetString(bytes);
            }
            catch { /* File mới */ }

            // Tách biệt nội dung rõ ràng để không bị dính chữ như ảnh 1
            string moi = cu + "\n\n[" + DateTime.Now.ToString("G") + "]\n" + noiDung + "\n" + new string('-', 30);

            // Sửa lại dòng Upload này
            await storage.Upload(Encoding.UTF8.GetBytes(moi), tenFile, new Supabase.Storage.FileOptions { Upsert = true });
        }
    }
}