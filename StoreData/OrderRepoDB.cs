using System.Collections.Generic;
using Model = StoreModel;
using Entity = StoreData.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModel;
using System;

namespace StoreData
{
    public class OrderRepoDB : IOrderRepository
    {

        private Entity.P0Context _context;

        private IMapper _mapper;

        public OrderRepoDB(Entity.P0Context context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }


        public Order AddOrder(Order newOrder)
        {
            _context.Orders.Add(_mapper.ParseOrder(newOrder));
            _context.SaveChanges();
            return newOrder;
        }

        public List<Order> GetOrders()
        {
            
            return _context.Orders.Select(x => _mapper.ParseOrder(x)).ToList();

        }

        public List<Order> GetOrdersWithCustomers()
        {
            //retrieve all orders from DB
            List <Order> orders = _context.Orders.Select(x => _mapper.ParseOrder(x)).ToList();
            // for each order in the new list
            foreach(Order order in orders){
                //find the customer in the db that made said order
                Entity.Customer customer = _context.Customers.Find(order.CustomerID);
                //assign customer to order object
                order.Customer = _mapper.ParseCustomer(customer);
            }
            //return list of orders, now populated with customers who made them
            return orders;


        }


        public Order GetSpecifiedOrder(DateTime exactDateTime){
            Entity.Order order = _context.Orders.Where(x => x.OrderDate == exactDateTime).First();

            return _mapper.ParseOrder(order);
        }
    }
}