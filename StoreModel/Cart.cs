using System.Collections.Generic;

namespace StoreModel
{
    /// <summary>
    /// Models our cart object in our database
    /// </summary>
    public class Cart
    {

        public int ID { get; set; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }
        public ICollection<CartProducts> CartProducts { get; set; }

        public int LocationID { get; set; }

        public Location Location { get; set; }


    }
}