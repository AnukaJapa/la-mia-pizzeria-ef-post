using Microsoft.AspNetCore.Mvc;
using PizzeriaDiAnaJaparidze.Database;
using PizzeriaDiAnaJaparidze.Models;

namespace PizzeriaDiAnaJaparidze.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza> pizzaList = db.Pizzas.OrderBy(x=>x.Id).ToList<Pizza>();
             
                return View("Index", pizzaList);
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pizza formData)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", formData);

                } else
                {
                    db.Pizzas.Add(formData);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");

            }
        }

        
    }
}
