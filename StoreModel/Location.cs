using System.Collections.Generic;

namespace StoreModel
{

    /// <summary>
    /// Models our location object in our database
    /// </summary>
    public class Location
    {

        public int ID { get; set; }

        public string LocationName { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Cart> Cart { get; set; }

        public ICollection<LocationProduct> LocationProducts { get; set; }


        public string Address { get; set; }


    }
}