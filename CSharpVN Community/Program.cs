var builder = WebApplication.CreateBuilder(args);

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