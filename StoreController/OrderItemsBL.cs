using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public class OrderItemsBL : IOrderItemsBL
    {
        private IOrderItemRepoDB _repo;

        public OrderItemsBL(IOrderItemRepoDB repo){
            _repo = repo;
        }

        public void AddOrderItem(OrderItem newOrderItem)
        {
            _repo.AddOrderItem(newOrderItem);
        }

        public List<OrderItem> GetOrderItems(int orderID)
        {
            return _repo.GetOrderItems(orderID);
        }
    }
}