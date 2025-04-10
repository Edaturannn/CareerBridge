using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using Website.Business.Abstract;
using Website.Business.Concrete;
using Website.Business.JwtServices;
using Website.DataAccess.Abstract;
using Website.DataAccess.Concrete;
using Website.DataAccess.EntityFramework;
using Website.Dtos.AutoMapper;
using Website.WebAPI.OpenAI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Oluşan Giriş Token Buraya Yaz",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    x.OperationFilter<SecurityRequirementsOperationFilter>();
});

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


builder.Services.AddHttpClient<IOpenAIService, OpenAIService>();


builder.Services.AddDbContext<Context>();
builder.Services.AddAutoMapper(typeof(Mapping));


builder.Services.AddScoped<IContactDal, EFContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();


builder.Services.AddScoped<IUserDal, EFUserDal>();
builder.Services.AddScoped<UserManager>();

builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();

