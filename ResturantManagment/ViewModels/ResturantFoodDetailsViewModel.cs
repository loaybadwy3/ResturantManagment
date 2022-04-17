using ResturantManagment.Models;
using System.Collections.Generic;

namespace ResturantManagment.ViewModels
{
    public class ResturantFoodDetailsViewModel
    {
        public Resturant Resturant { get; set; }
        public Food Food { get; set; }
        public List<Food> Foods { get; set; }
    }
}
