using System.ComponentModel.DataAnnotations;

namespace wt_lab5_5razor_savostikova.Models;

public class Dish
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите название блюда")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    [Range(0.01, 1000000, ErrorMessage = "Цена должна быть от 0.01 до 1000000")]
    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }
    public string Description { get; set; } = string.Empty;
}