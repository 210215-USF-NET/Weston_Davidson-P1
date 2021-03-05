using System;

namespace StoreModel
{
    
    /// <summary>
    /// Models our orderItem object in our database
    /// </summary>
    public class OrderItem
    {
        public int OrderItemsID {get; set;}

        public int? OrderItemsQuantity {get; set;}

        public int OrderID {get; set;}

        public int productID {get; set;}

        public override string ToString()
        {
            return $"|Product ID: {productID} | Product Quantity: {OrderItemsQuantity}|";
        }
    }
}