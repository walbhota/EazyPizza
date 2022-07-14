using System.ComponentModel.DataAnnotations;

namespace EazyPizza.Models;

public class Pizza
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public PizzaSize Size { get; set; }
    public bool IsGlutenFree { get; set; }
    [Range(0.01, 9999.99)]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
}

public enum PizzaSize
{
    Small, Meduim, Large
}