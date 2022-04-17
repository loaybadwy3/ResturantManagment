using Microsoft.AspNetCore.Mvc;
using ResturantManagment.Data;
using ResturantManagment.Models;
using System.Collections.Generic;

namespace ResturantManagment.Controllers
{
    public class IngredientController : Controller
    {
        private readonly AppDbContext _db;

        public IngredientController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Ingredient> IngredientList = _db.Ingredients;
            return View(IngredientList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Ingredient obj)
        {
            _db.Ingredients.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Ingredients.Find(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Ingredient obj)
        {
            _db.Ingredients.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Ingredients.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Ingredient obj)
        {
            _db.Ingredients.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
