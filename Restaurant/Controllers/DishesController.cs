using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class DishesController : Controller
    {

        private readonly ApplicationDbContext _db;

        public DishesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Dish> objDishList = _db.Dishes.ToList();
            return View(objDishList);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Dish obj)
        {
            _db.Dishes.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }

            Dish? dish = _db.Dishes.Find(id);

            if(dish == null)
            {
                return NotFound();
            }
            return View(dish); 
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Dish obj)
        {
            if (ModelState.IsValid)
            {
                _db.Dishes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var obj = _db.Dishes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(Dish obj)
        {
            _db.Dishes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult IndexUtilizator()
        {
            List<Dish> objDishList = _db.Dishes.ToList();
            return View(objDishList);
        }
        public async Task<IActionResult> Details(int id)
        {
            var dish = await _db.Dishes.FirstOrDefaultAsync(d => d.Id == id);

            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

    }
}
