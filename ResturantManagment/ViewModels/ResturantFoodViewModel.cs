using ResturantManagment.Models;
using System.Collections.Generic;

namespace ResturantManagment.ViewModels
{
    public class ResturantFoodViewModel
    {

        public List<Resturant> Resturants { get; set; }
        public List<Food> Foods { get; set; }
        public List<int> IntFoods { get; set; }
        public string ResturantName { get; set; }
        public int ResturantNumber { get; set; }

    }
}
