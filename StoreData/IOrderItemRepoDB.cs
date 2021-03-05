using System.Collections.Generic;
using Model = StoreModel;
using Entity = StoreData.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModel;
using System;

namespace StoreData
{
    public interface IOrderItemRepoDB
    {
        void AddOrderItem(OrderItem newOrderItem);

        List<OrderItem> GetOrderItems(int orderID);
    }
}