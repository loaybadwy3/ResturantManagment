namespace ResturantManagment.Models
{
    public class ResturantFood
    {
        public int ResturantId { get; set; }
        public int FoodId { get; set; }
        public Resturant Resturnat { get; set; }
        public Food Food { get; set; }


    }
}
