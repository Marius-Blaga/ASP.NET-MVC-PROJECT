using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class DrinksController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DrinksController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Drink> objDrinkList = _db.Drinks.ToList();
            return View(objDrinkList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Drink obj)
        {
            _db.Drinks.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Drink? drink = _db.Drinks.Find(id);

            if (drink == null)
            {
                return NotFound();
            }
            return View(drink);
        }

        [HttpPost]
        public IActionResult Edit(Drink obj)
        {
            if (ModelState.IsValid)
            {
                _db.Drinks.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            var obj = _db.Drinks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(Drink obj)
        {
            _db.Drinks.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult IndexUtilizator()
        {
            List<Drink> objDrinkList = _db.Drinks.ToList();
            return View(objDrinkList);
        }
    }
}
