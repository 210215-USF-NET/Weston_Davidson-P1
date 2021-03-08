using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class OrderProductsVM
    {

        public int ID { get; set; }

        public int? OrderItemsQuantity { get; set; }

        public int OrderID { get; set; }

        public OrderVM Order { get; set; }



        public int ProductID { get; set; }

        public ProductVM Product { get; set; }
    }
}
