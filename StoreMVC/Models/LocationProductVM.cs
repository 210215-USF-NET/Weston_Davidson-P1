using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class LocationProductVM
    {

        public int ID { get; set; }

        // each inventory has a product, and a store
        public int ProductID { get; set; }
        public ProductVM Product { get; set; }


        // inventory has a store
        public int LocationID { get; set; }

        public LocationVM Location { get; set; }




        //the inventory name should probably basically be the singluar product
        //that is contained in that inventory
        public string LocationProductName { get; set; }
        public int ProductQuantity { get; set; }
    }
}
