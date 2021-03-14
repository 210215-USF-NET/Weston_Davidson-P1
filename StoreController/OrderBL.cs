using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public class OrderBL : IOrderBL
    {
        private IOrderRepository _repo;

        public OrderBL(IOrderRepository repo)
        {
            _repo = repo;
        }

        public Order AddOrder(Order newOrder)
        {
            return _repo.AddOrder(newOrder);
        }

        public List<Order> GetOrders()
        {
            return _repo.GetOrdersWithCustomers();
        }

        public Order GetSpecifiedOrder(DateTime exactDateTime)
        {
            return _repo.GetSpecifiedOrder(exactDateTime);
        }

        public Order GetOrderFromDateCustomer(int customerID, string orderDate)
        {
            return _repo.GetOrderFromDateCustomer(customerID, orderDate);
        }

        public Order GetRecentOrder()
        {
            return _repo.GetRecentOrder();
        }

        public List<Order> GetOrdersForCustomer(int customerID)
        {
            return _repo.GetOrdersForCustomer(customerID);
        }
    }
}