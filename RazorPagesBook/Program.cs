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
// �N HTTP �n�D���s�ɦV�� HTTPS�C
app.UseHttpsRedirection();

// ���\�����R�A�ɮסA�Ҧp HTML�BCSS�B�v���M JavaScript�C
app.UseStaticFiles();

// �N Route ���s�W�� middleware pipeline�C
app.UseRouting();

// �]�w Razor Pages ��  endpoint routing�C
app.MapRazorPages();

// ���v���ϥΪ̦s���w���귽�C �����ε{�����ϥα��v�C
//app.UseAuthorization();

// �������ε{���C
app.Run();
