using ResturantManagment.Models;
using System.Collections.Generic;

namespace ResturantManagment.ViewModels
{
    public class FoodIngredientViewModel
    {
        public Food Food { get; set; }
        public List<Food> Foods { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<int> IntIngredients { get; set; }
        public  string FoodName { get; set; }
        public int FoodPrice { get; set; }
        public string FoodDescription { get; set; }

    }
}
