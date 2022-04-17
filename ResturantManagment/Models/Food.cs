using System.Collections.Generic;

namespace ResturantManagment.Models
{
    public class Food
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ResturantFood> ResturantFoods { get; set; }
        public virtual ICollection<FoodIngredient> FoodIngredients { get; set; }

    }
}
