using System.Collections.Generic;
using System;
using StoreModel;

namespace StoreController
{
    public interface IOrderBL
    {
        List<Order> GetOrders();

        Order GetSpecifiedOrder(DateTime exactDateTime);

        Order AddOrder(Order newOrder);

        Order GetOrderFromDateCustomer(int customerID, string orderDate);
    }
}