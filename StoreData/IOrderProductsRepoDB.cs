using System.Collections.Generic;
using Model = StoreModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModel;
using System;

namespace StoreData
{
    public interface IOrderProductsRepoDB
    {
        void AddOrderItem(OrderProducts newOrderItem);

        List<OrderProducts> GetOrderProducts(int orderID);
    }
}