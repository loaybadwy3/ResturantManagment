using System.Collections.Generic;

namespace ResturantManagment.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<FoodIngredient> FoodIngredients { get; set; }
    }
}
