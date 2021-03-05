using System.Collections.Generic;
using System;


namespace StoreModel
{

    /// <summary>
    /// Models our order object in our database
    /// </summary>
    public class Order
    {
        public int ID { get; set; }

        public DateTime OrderDate { get; set; }

        //an order has a location, a customer, and a list of products

        //public List<Product> ProductsPurchased {get; set;}

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public int LocationID { get; set; }
        public Location Location { get; set; }

        public ICollection<OrderProducts> OrderProducts { get; set; }


        public Decimal TotalCost { get; set; }

    }
}