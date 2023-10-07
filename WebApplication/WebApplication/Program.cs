using Application.Cache;
using Application.Services;
using Application.Events.Handlers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GenericRepositoryContext>(option => option.UseInMemoryDatabase("INMEMEORYDB"));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSingleton(typeof(CacheManager), typeof(CacheManager));
builder.Services.AddSingleton(typeof(FailedAttemptsEventHandler), typeof(FailedAttemptsEventHandler));
builder.Services.AddSingleton(typeof(TerminateSessionEventHandler), typeof(TerminateSessionEventHandler));

builder.Services.AddTransient(typeof(UserService), typeof(UserService));

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.HttpOnly = true; // OWASP-A01
    options.ExpireTimeSpan = TimeSpan.FromHours(60); // OWASP-A01
    options.SlidingExpiration = false; // OWASP-A01
});

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

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
