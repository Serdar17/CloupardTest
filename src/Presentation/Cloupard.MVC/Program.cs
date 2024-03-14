using Cloupard.Common.Settings;
using Cloupard.MVC;
using Cloupard.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var logSettings = Settings.Load<LogSettings>(LogSettings.SectionName);

builder.AddAppLogger(logSettings);

services.AddControllersWithViews();
services.AddRazorPages();

services.RegisterServices();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseAppCors();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();