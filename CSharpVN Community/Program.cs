var builder = WebApplication.CreateBuilder(args);

// Đăng ký Supabase Client (nếu Hào chưa làm)
// Đăng ký Supabase Client với kiểm tra an toàn
builder.Services.AddScoped(provider =>
{
    var url = builder.Configuration["SupabaseUrl"];
    var key = builder.Configuration["SupabaseKey"];

    if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(key))
    {
        // Thay vì để nó văng lỗi hệ thống, mình chủ động báo lỗi rõ ràng
        throw new InvalidOperationException("Hào ơi, chưa có SupabaseUrl hoặc SupabaseKey trong cấu hình Render kìa!");
    }

    return new Supabase.Client(url, key, new Supabase.SupabaseOptions { AutoConnectRealtime = true });
});

// Đăng ký Class Code của Hào
builder.Services.AddScoped<CSharpVN_Community.Pages.Code>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // Hsts giúp bảo mật HTTPS mạnh mẽ hơn khi chạy thực tế
    app.UseHsts();
}

// --- THÊM DÒNG NÀY VÀO ĐÂY ---
app.UseHttpsRedirection();
// -----------------------------

app.UseStaticFiles(); // Đảm bảo các file ảnh, css trong wwwroot chạy được

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.UseSession();
app.MapRazorPages()
   .WithStaticAssets();
app.MapGet("/", context => {
    context.Response.Redirect("/Home");
    return Task.CompletedTask;
});
app.Run();