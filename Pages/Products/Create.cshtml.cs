using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_savostikova.Models;
using wt_lab5_5razor_savostikova.Data;

namespace wt_lab5_5razor_savostikova.Pages.Products;

public class CreateModel : PageModel
{
    [BindProperty]
    public Dish Dish { get; set; } = new();

    public void OnGet()
    {
        // Просто возвращаем страницу с пустой формой
    }

    public IActionResult OnPost()
    {
        // Если данные не прошли валидацию (пустое имя или неверная цена)
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Генерируем новый ID (максимальный + 1)
        Dish.Id = DishStore.Dishes.Any() ? DishStore.Dishes.Max(x => x.Id) + 1 : 1;
        
        // По умолчанию блюдо в наличии
        Dish.IsAvailable = true;

        // Сохраняем в общее хранилище
        DishStore.Dishes.Add(Dish);

        // Перенаправляем на список (./Index означает текущую папку)
        return RedirectToPage("./Index");
    }
}