using Eticaret.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>();

// Add Authentication (sadece bir kez ve doðru yapýlandýrma ile)
builder.Services.AddAuthentication("Cookies")
    .AddCookie(x=>
    {
        x.LoginPath = "/Account/SignIn"; // Giriþ sayfasý
        x.AccessDeniedPath = "/AccessDenied"; // Yetkisiz eriþim sayfasý
        x.Cookie.Name = "Account"; // Çerez adý
        x.Cookie.MaxAge = TimeSpan.FromDays(30); // Çerez ömrü
        x.Cookie.IsEssential = true; // Çerez zorunlu

    });
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    x.AddPolicy("UserPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "User", "Customer"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication ve Authorization middleware'lerini ekleyin
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
