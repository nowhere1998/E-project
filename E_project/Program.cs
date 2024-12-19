using E_project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EProjectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddDistributedMemoryCache();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSession(option =>
{
    option.Cookie.Name = "c2208i2.session";
    option.Cookie.HttpOnly = true;
    option.IdleTimeout = TimeSpan.FromHours(1);
});
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});
builder.Services.AddAuthentication("EProjectSecurityScheme").AddCookie("EProjectSecurityScheme", options =>
{
    options.AccessDeniedPath = new PathString("/Admin/");
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = ".EProject.Security.Cookie",
        Path = "/",
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.SameAsRequest
    };
    options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
    {

    };
    options.LoginPath = new PathString("/Admin/Home/Login");
    options.ReturnUrlParameter = "redirectPath";
    options.SlidingExpiration = true;
}
);

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

app.UseSession();
app.UseCookiePolicy();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
