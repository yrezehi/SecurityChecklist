using Application.Cache;
using Application.Services;
using Application.Events.Handlers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.Extensions;
using Application.Repositories.Interfaces;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GenericRepositoryContext>(option => option.UseInMemoryDatabase("INMEMEORYDB"));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork<GenericRepositoryContext>>();

builder.Services.AddSingleton(typeof(CacheManager), typeof(CacheManager));
builder.Services.AddSingleton(typeof(FailedAttemptsEventHandler), typeof(FailedAttemptsEventHandler));
builder.Services.AddSingleton(typeof(TerminateSessionEventHandler), typeof(TerminateSessionEventHandler));

builder.Services.AddTransient(typeof(UserService), typeof(UserService));
builder.Services.AddTransient(typeof(AuthenticationService), typeof(AuthenticationService));

builder.RegisterSecurityLayer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    using (var context = scope.ServiceProvider.GetService<GenericRepositoryContext>())
        context!.Database.EnsureCreated();
}

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
