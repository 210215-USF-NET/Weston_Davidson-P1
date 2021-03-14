using StoreModel;
using System.Collections.Generic;
using System;

namespace StoreData
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();

        List<Order> GetOrdersWithCustomers();

        Order GetSpecifiedOrder(DateTime exactDateTime);

        Order AddOrder(Order newOrder);

        public Order GetOrderFromDateCustomer(int customerID, string orderDate);

    }
}