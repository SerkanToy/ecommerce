using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(_ =>
{
    _.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    _.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(opt =>
{
    opt.Cookie.Name = "CookieAuth";
    opt.LoginPath = "/login";
    opt.LogoutPath = "/login";
    opt.AccessDeniedPath = "/access-denied";
    opt.ExpireTimeSpan = TimeSpan.FromSeconds(20);
});


builder.Services.AddAuthorization(_ =>
{
    _.AddPolicy("Invoice", policy =>
    {
        policy.RequireClaim("Invoice");
    });
    _.AddPolicy("UserName", policy =>
    {
        policy.RequireUserName("admin@admin.com");
        policy.RequireUserName("stoy@admin.com");
    });
});

builder.Services.AddHttpClient("admin.ecommerce.api", client =>
{
    client.BaseAddress = new Uri("https://localhost:7075");
    client.Timeout = TimeSpan.FromSeconds(30);
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
