using System.Collections.Generic;

namespace ResturantManagment.Models
{
    public class Resturant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public virtual ICollection<ResturantFood> ResturantFoods { get; set; }


    }
}
