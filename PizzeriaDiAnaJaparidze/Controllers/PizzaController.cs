using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Server;
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

        public IActionResult Details(int id)
        {
           using (PizzeriaContext db = new PizzeriaContext()){
                Pizza pizzaRichiesta = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();
                if (pizzaRichiesta != null)
                {
                    return View(pizzaRichiesta);
                }

                return NotFound("la pizza con l'id cercato non esiste!");
            }

        }
      

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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



        [HttpGet]

        public IActionResult Update(int id)
        {
            using(PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaToUpdate = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();

                if (pizzaToUpdate == null)
                {
                    return NotFound("la pizza non è stato trovato");
                }

                return View("Update", pizzaToUpdate);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(Pizza formPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", formPizza);
            }
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaToUpdate = db.Pizzas.Where(p=>p.Id == formPizza.Id).FirstOrDefault();

                if (pizzaToUpdate != null)
                {
                    pizzaToUpdate.Title = formPizza.Title;
                    pizzaToUpdate.Description = formPizza.Description;
                    pizzaToUpdate.Image = formPizza.Image;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Il post che volevi modificare non è stato trovato!");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaToDelete = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();

                if (pizzaToDelete != null)
                {
                    db.Pizzas.Remove(pizzaToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Il post da eliminare non è stato trovato!");
                }
            }
        }

    }
}
