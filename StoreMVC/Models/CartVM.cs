using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class CartVM
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        public CustomerVM Customer { get; set; }
        public ICollection<CartProductsVM> CartProducts { get; set; }

        public int LocationID { get; set; }

        public LocationVM Location { get; set; }
    }
}
