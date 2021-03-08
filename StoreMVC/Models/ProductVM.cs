using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class ProductVM
    {
        public int ID { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }

        public string Manufacturer { get; set; }
        //by tracking product location in product, we can easily determine where inventory should be added
        // depending on how this POCO gets set

        public ICollection<CartProductsVM> CartProducts { get; set; }

        public ICollection<OrderProductsVM> OrderProducts { get; set; }


        public ICollection<LocationProductVM> LocationProducts { get; set; }
    }
}
