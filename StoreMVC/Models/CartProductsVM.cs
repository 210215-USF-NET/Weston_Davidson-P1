using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class CartProductsVM
    {

        public int ID { get; set; }
        //cartproducts are the combination of the cart ID they are held in
        //and the product ID being added



        public int CartID { get; set; }

        public CartVM Cart { get; set; }

        public int ProductID { get; set; }
        public ProductVM Product { get; set; }




        public int? ProductCount { get; set; }
    }
}
