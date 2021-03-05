using System.Collections.Generic;

namespace StoreModel
{

    /// <summary>
    /// Models our product object in our database
    /// </summary>
    public class Product
    {
        public int ID { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }

        public string Manufacturer { get; set; }
        //by tracking product location in product, we can easily determine where inventory should be added
        // depending on how this POCO gets set

        public ICollection<CartProducts> CartProducts { get; set; }

        public ICollection<OrderProducts> OrderProducts { get; set; }


        public ICollection<LocationProduct> LocationProducts { get; set; }
    }
}