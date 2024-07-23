using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesBook.Data;
using RazorPagesBook.Models;

// Create WebApplicationBuilder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorPagesBookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesBookContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesBookContext' not found.")));

var app = builder.Build();

// Seed Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Middlewares
// Redirects HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Enables static files, such as HTML, CSS, images, and JavaScript to be served.
app.UseStaticFiles();

// Adds route matching to the middleware pipeline.
app.UseRouting();

// Configures endpoint routing for Razor Pages.
app.MapRazorPages();

// Authorizes a user to access secure resources.
// This app doesn't use authorization, therefore this line could be removed.
//app.UseAuthorization();

// Runs the app.
app.Run();
