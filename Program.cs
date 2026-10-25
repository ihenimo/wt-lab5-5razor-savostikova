using wt_lab5_5razor_savostikova.Models;
using wt_lab5_5razor_savostikova.Data;

var builder = WebApplication.CreateBuilder(args);

// НАСТРОЙКА ПОРТА ДЛЯ RENDER
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// Добавляем сервисы для Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Настройка конвейера обработки запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();