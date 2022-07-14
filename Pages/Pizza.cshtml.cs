using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EazyPizza.Models;
using EazyPizza.Services;

namespace EazyPizza.Pages
{
    public class PizzaModel : PageModel
    {
        public void OnGet()
        {
            pizzas = PizzaService.GetAll();
        }
        public List<Pizza> pizzas = new();

        public string GlutenFreeText(Pizza pizza)
        {
            if (pizza.IsGlutenFree)
                return "Gluten Free";
            return "Not Gluten Free";
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }
        [BindProperty]
        public Pizza NewPizza { get; set; } = new();

        public IActionResult OnPostDelete(int id)
        {
            PizzaService.Delete(id);
            return RedirectToAction("Get");
        }
    }

}
