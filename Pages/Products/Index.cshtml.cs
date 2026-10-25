using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_savostikova.Models;
using wt_lab5_5razor_savostikova.Data;

namespace wt_lab5_5razor_savostikova.Pages.Products;

public class IndexModel : PageModel
{
    public List<Dish> Dishes { get; set; } = new();

    public void OnGet()
    {
        Dishes = DishStore.Dishes;
    }
}