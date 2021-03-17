using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    /// <summary>
    /// OrderProduct BL tracks location business logic changes/requests
    /// These are the products that are stored in an order area
    /// </summary>
    public class OrderProductsBL : IOrderProductsBL
    {
        private IOrderProductsRepoDB _repo;

        public OrderProductsBL(IOrderProductsRepoDB repo)
        {
            _repo = repo;
        }

        public void AddOrderProduct(OrderProducts newOrderItem)
        {
            _repo.AddOrderItem(newOrderItem);
        }

        public List<OrderProducts> GetOrderProducts(int orderID)
        {
            return _repo.GetOrderProducts(orderID);
        }

        public List<OrderProducts> ProcessProducts(int cartId, int orderID)
        {
            return _repo.ProcessProducts(cartId, orderID);
        }
    }
}