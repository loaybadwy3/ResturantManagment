namespace ResturantManagment.Models
{
    public class FoodIngredient
    {
        public int IngredientId { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}
