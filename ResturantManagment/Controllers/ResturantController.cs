using Microsoft.AspNetCore.Mvc;
using ResturantManagment.Data;
using ResturantManagment.Models;
using ResturantManagment.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ResturantManagment.Controllers
{
    public class ResturantController : Controller
    {
        private readonly AppDbContext _db;

        public ResturantController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Resturant> ResturantList = _db.Resturats;
            return View(ResturantList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ResturantFoodViewModel vm = new ResturantFoodViewModel();
            vm.Resturants = _db.Resturats.ToList();
            vm.Foods = _db.Foods.ToList();
            return View(vm);

        }
        [HttpPost]
        public IActionResult Add(ResturantFoodViewModel VM)
        {
            Resturant resturant = new Resturant
            {
                Name = VM.ResturantName,
                Number = VM.ResturantNumber,

            };
            _db.Resturats.Add(resturant);
            _db.SaveChanges();

            foreach ( var food in VM.IntFoods)
            {
                ResturantFood RF = new ResturantFood
                {
                    FoodId = food,
                    ResturantId = resturant.Id,
                };
                _db.ResturantFoods.Add(RF);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            ResturantFoodDetailsViewModel obj = new ResturantFoodDetailsViewModel();

            var resturant = _db.Resturats.Find(id);
            obj.Resturant = resturant;

            var resturantFood = _db.ResturantFoods.Where(x => x.ResturantId == id);
            obj.Foods = new List<Food>();
            foreach ( var restFood in resturantFood)
            {
                var food = _db.Foods.Find(restFood.FoodId);
                obj.Foods.Add(food);
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Resturats.Find(id);
            ResturantFoodViewModel vm = new ResturantFoodViewModel()
            {
                ResturantName = obj.Name,
                ResturantNumber = obj.Number,
                Foods = _db.Foods.ToList(),
            };

            
            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(int? id, ResturantFoodViewModel VM)
        {
            var resturant = _db.Resturats.Where(x => x.Id == id).SingleOrDefault();
            resturant.Name = VM.ResturantName;
            resturant.Number = VM.ResturantNumber;
            _db.Resturats.Update(resturant);
            _db.SaveChanges();

            foreach (var food in VM.IntFoods)
            {
                ResturantFood RF = new ResturantFood
                {
                    FoodId = food,
                    ResturantId = resturant.Id,
                };
                _db.ResturantFoods.Update(RF);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Resturats.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Resturant obj)
        {
            _db.Resturats.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
