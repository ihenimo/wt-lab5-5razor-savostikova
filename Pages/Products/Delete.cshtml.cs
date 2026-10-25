using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_savostikova.Models;
using wt_lab5_5razor_savostikova.Data;

namespace wt_lab5_5razor_savostikova.Pages.Products;

public class DeleteModel : PageModel
{
    [BindProperty]
    public Dish? Dish { get; set; }

    public IActionResult OnGet(int id)
    {
        Dish = DishStore.Dishes.FirstOrDefault(x => x.Id == id);
        if (Dish == null) return NotFound();
        return Page();
    }

    public IActionResult OnPost()
    {
        if (Dish != null)
        {
            var itemToRemove = DishStore.Dishes.FirstOrDefault(x => x.Id == Dish.Id);
            if (itemToRemove != null)
            {
                DishStore.Dishes.Remove(itemToRemove);
            }
        }
        return RedirectToPage("./Index");
    }
}