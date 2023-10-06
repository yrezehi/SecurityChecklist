using Application.Cache;
using Application.Services;
using Application.Events.Handlers;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSingleton(typeof(CacheManager), typeof(CacheManager));
builder.Services.AddSingleton(typeof(FailedAttemptsEventHandler), typeof(FailedAttemptsEventHandler));
builder.Services.AddSingleton(typeof(TerminateSessionEventHandler), typeof(TerminateSessionEventHandler));

builder.Services.AddTransient(typeof(UserService), typeof(UserService));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
