using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class OrderVM
    {


        public int ID { get; set; }

        public DateTime OrderDate { get; set; }

        //an order has a location, a customer, and a list of products

        //public List<Product> ProductsPurchased {get; set;}

        public int CustomerID { get; set; }

        public CustomerVM Customer { get; set; }

        public int LocationID { get; set; }
        public LocationVM Location { get; set; }

        public ICollection<OrderProductsVM> OrderProducts { get; set; }


        public Decimal TotalCost { get; set; }
    }
}
