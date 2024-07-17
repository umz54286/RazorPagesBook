// Create WebApplicationBuilder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Middlewares
// 將 HTTP 要求重新導向至 HTTPS。
app.UseHttpsRedirection();

// 允許提供靜態檔案，例如 HTML、CSS、影像和 JavaScript。
app.UseStaticFiles();

// 將 Route 比對新增至 middleware pipeline。
app.UseRouting();

// 設定 Razor Pages 的  endpoint routing。
app.MapRazorPages();

// 授權給使用者存取安全資源。 此應用程式不使用授權。
//app.UseAuthorization();

// 執行應用程式。
app.Run();
