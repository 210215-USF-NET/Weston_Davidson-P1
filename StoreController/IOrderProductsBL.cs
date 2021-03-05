using StoreModel;
using System;
using System.Collections.Generic;

namespace StoreController
{
    public interface IOrderProductsBL
    {
        void AddOrderProduct(OrderProducts newOrderItem);

        List<OrderProducts> GetOrderProducts(int orderID);
    }
}