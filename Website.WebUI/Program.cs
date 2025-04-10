using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Website.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

//JWT Authentication Ayarları
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
}).AddCookie(options =>
{
    options.Cookie.Name = "KariyerWeb";
    options.Cookie.HttpOnly = true; // Güvenlik için sadece HTTP üzerinden erişilebilir
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Sadece HTTPS üzerinden erişilebilir
    options.Cookie.SameSite = SameSiteMode.Strict; // CSRF koruması için SameSite modunu ayarla
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Cookie'nin geçerlilik süresi
    options.SlidingExpiration = true; // Kullanıcı aktif kaldıkça süreyi yenile
    options.LoginPath = "/Login/Index"; // Giriş sayfası yolu
    options.LogoutPath = "/Logout/Index"; // Çıkış sayfası yolu
    options.AccessDeniedPath = "/Account/AccessDenied"; // Yetki reddedildiği durumda yönlendirme
});
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<Context>();
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();

