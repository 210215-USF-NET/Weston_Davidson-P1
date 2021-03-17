using Microsoft.EntityFrameworkCore;
using StoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData
{
    public class OrderProductsRepoDB : IOrderProductsRepoDB
    {

        private readonly StoreDBContext _context;

        public OrderProductsRepoDB(StoreDBContext context)
        {
            _context = context;
        }

        public void AddOrderItem(OrderProducts newOrderItem)
        {
            throw new NotImplementedException();
        }

        public List<OrderProducts> GetOrderProducts(int orderID)
        {
            return _context.OrderProducts.Where(op => op.OrderID == orderID).ToList();
        }

        public List<OrderProducts> ProcessProducts(int cartId, int orderID)
        {
            Cart cart = _context.Carts.AsNoTracking().Where(c => c.ID == cartId).FirstOrDefault();
            Order order = _context.Orders.AsNoTracking().Where(o => o.ID == orderID).FirstOrDefault();
            List<CartProducts> productsToProcess = _context.CartProducts.AsNoTracking().Where(cp => cp.CartID == cartId).ToList();
            List<OrderProducts> processedOrderProducts = new List<OrderProducts>();
            foreach (CartProducts cp in productsToProcess)
            {
                OrderProducts orderproduct = new OrderProducts();
                orderproduct.OrderID = orderID;
                orderproduct.ProductID = cp.ProductID;
                orderproduct.OrderItemsQuantity = cp.ProductCount;
                _context.OrderProducts.Add(orderproduct);
                _context.SaveChanges();
                processedOrderProducts.Add(orderproduct);
            }
            return processedOrderProducts;
        }
    }
}
