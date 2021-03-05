using System;

namespace StoreModel
{

    /// <summary>
    /// Models our orderproducts object in our database
    /// </summary>
    public class OrderProducts
    {
        public int ID { get; set; }

        public int? OrderItemsQuantity { get; set; }

        public int OrderID { get; set; }

        public Order Order { get; set; }



        public int ProductID { get; set; }

        public Product Product { get; set; }


    }
}