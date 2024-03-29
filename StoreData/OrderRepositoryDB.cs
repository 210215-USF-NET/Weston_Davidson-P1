﻿using Microsoft.EntityFrameworkCore;
using StoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData
{
    /// <summary>
    /// Order repo tracks order data layer access for changes/requests
    /// </summary>
    public class OrderRepositoryDB : IOrderRepository
    {

        private readonly StoreDBContext _context;

        public OrderRepositoryDB(StoreDBContext context)
        {
            _context = context;
        }
        public Order AddOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return newOrder;
        }

        public Order GetOrderFromDateCustomer(int customerID, string orderDate)
        {
            return _context.Orders.AsNoTracking().Select(o => o).OrderBy(o => o.OrderDate).LastOrDefault();
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.AsNoTracking().Select(o => o).ToList();
        }

        public List<Order> GetOrdersWithCustomers()
        {
            return _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Location)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .AsNoTracking()
                .ToList();
        }

        public Order GetOrderByID(int id)
        {
            return _context.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.Location)
                    .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                    .AsNoTracking()
                    .Where(o => o.ID == id).FirstOrDefault();
        }

        public Order GetSpecifiedOrder(DateTime exactDateTime)
        {
            throw new NotImplementedException();
        }

        public Order GetRecentOrder()
        {
            return _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Location)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Select(o => o).OrderBy(o => o.OrderDate).LastOrDefault();
        }

        public List<Order> GetOrdersForCustomer(int customerID)
        {
            return _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Location)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .AsNoTracking()
                .Where(o => o.CustomerID == customerID).ToList();
        }
    }
}
