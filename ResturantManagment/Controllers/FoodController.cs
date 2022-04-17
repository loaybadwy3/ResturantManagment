using Microsoft.AspNetCore.Mvc;
using ResturantManagment.Data;
using ResturantManagment.Models;
using ResturantManagment.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ResturantManagment.Controllers
{
    public class FoodController : Controller
    {
        private readonly AppDbContext _db;

        public FoodController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Food> FoodList = _db.Foods;
            return View(FoodList);
        }
        public IActionResult Details(int? id)
        {
            FoodIngredientViewModel obj = new FoodIngredientViewModel(); 
            var food = _db.Foods.Find(id);
            var foodIngrediants = _db.FoodIngredients.Where(x => x.FoodId == id).ToList();//solusion i
            obj.Ingredients = new List<Ingredient>();
            foreach (var foodIng in foodIngrediants)
            {
                var ingredient = _db.Ingredients.Find(foodIng.IngredientId);

                obj.Ingredients.Add(ingredient);
            }
            obj.Food = food;
            return View(obj);

        }
        [HttpGet]
        public IActionResult Add()
        {
            FoodIngredientViewModel vm = new FoodIngredientViewModel();
            vm.Foods = _db.Foods.ToList();
            vm.Ingredients = _db.Ingredients.ToList();
            return View(vm);
            
        }
        [HttpPost]
        public IActionResult Add(FoodIngredientViewModel VM)
        {
            Food food = new Food()
            {
                Name = VM.FoodName,
                Price = VM.FoodPrice,
                Description = VM.FoodDescription,  
            };
            _db.Foods.Add(food);
            _db.SaveChanges();
            foreach (var ingredient in VM.IntIngredients)
            {
                FoodIngredient FI = new FoodIngredient()
                {
                    IngredientId = ingredient,
                    FoodId = food.Id,
                };
                _db.FoodIngredients.Add(FI);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Foods.Find(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Food obj)
        {
            _db.Foods.Update(obj);
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
            var obj = _db.Foods.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Food obj)
        {
            _db.Foods.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
