using wt_lab5_5razor_savostikova.Models;
using wt_lab5_5razor_savostikova.Data;

var builder = WebApplication.CreateBuilder(args);

// НАСТРОЙКА ПОРТА ДЛЯ RENDER
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// Добавляем сервисы для Razor Pages
builder.Services.AddRazorPages();

// РЕГИСТРАЦИЯ ХРАНИЛИЩА ДАННЫХ (Singleton), чтобы данные были общими для всех страниц.
// ЕСЛИ ВАШ КЛАСС НАЗЫВАЕТСЯ НЕ DishStore, А ПО-ДРУГОМУ, ЗАМЕНИТЕ ЗДЕСЬ!
builder.Services.AddSingleton<DishStore>();

var app = builder.Build();

// Настройка конвейера обработки запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // Строка ниже включает HSTS (HTTP Strict Transport Security) в продакшене (на Render)
    app.UseHsts();
}

// Отключаем редирект на HTTPS, так как Render сам управляет HTTPS-трафиком,
// а внутри контейнера приложение работает по HTTP.
// app.UseHttpsRedirection(); 
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();