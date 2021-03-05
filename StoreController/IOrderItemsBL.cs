using StoreModel;
using System;
using System.Collections.Generic;

namespace StoreController
{
    public interface IOrderItemsBL
    {
        void AddOrderItem(OrderItem newOrderItem);

        List<OrderItem> GetOrderItems(int orderID);
    }
}