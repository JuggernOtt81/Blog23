using Blog23.Data;
using Blog23.Models;
using Blog23.Services;
using Blog23.Services.Interfaces;
//using Blog23.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Blog23.ViewModels;

var builder = WebApplication.CreateBuilder(args);
//localhost db
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var mailsettings = builder.Configuration.GetSection("MailSettings").Get<MailSettings>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.

//production db
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(ConnectionService.GetConnectionString(builder.Configuration)));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<BlogUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<DataService>();
builder.Services.AddScoped<BlogSearchService>();
builder.Services.AddScoped<MailSettings>();
builder.Services.AddScoped<IBlogEmailSender, EmailService>();
builder.Services.AddScoped<IImageService, BasicImageService>();
builder.Services.AddScoped<ISlugService, BasicSlugService>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();



var app = builder.Build();
//var mailService = app.Services
//                     .CreateScope()
//                     .ServiceProvider
//                     .GetRequiredService<IBlogEmailSender>();

var dataService = app.Services
                     .CreateScope()
                     .ServiceProvider
                     .GetRequiredService<DataService>();

await dataService.ManageDataAsync();



if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();