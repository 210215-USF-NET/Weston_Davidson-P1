using Microsoft.EntityFrameworkCore;
using StoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData
{
    public class CustomerRepoDB : ICustomerRepoDB
    {
        private readonly StoreDBContext _context;

        public CustomerRepoDB(StoreDBContext context)
        {
            _context = context;
        }

        public Customer AddCustomer(Customer newCustomer)
        {
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
            return newCustomer;
        }

        public Customer DeleteCustomer(Customer customer2BDeleted)
        {
            _context.Customers.Remove(customer2BDeleted);
            _context.SaveChanges();
            return customer2BDeleted;
        }
        public List<Customer> GetCustomers()
        {
            return _context.Customers
                    .Include(c => c.Carts)
                    .ThenInclude(carts => carts.CartProducts)
                    .Include(c => c.Orders)
                    .ThenInclude(orders => orders.OrderProducts)
                    .AsNoTracking()
                    .Select(customer => customer)
                    .ToList();
        }

        public Customer GetCustomerByFirstName(string name)
        {
            return _context.Customers
                    .Include(c => c.Carts)
                    .ThenInclude(carts => carts.CartProducts)
                    .Include(c => c.Orders)
                    .ThenInclude(orders => orders.OrderProducts)
                    .AsNoTracking()
                    .FirstOrDefault(c => c.FName == name);

        }

        public Customer GetCustomerByFK(string fk)
        {
            return _context.Customers
                    .Include(c => c.Carts)
                    .ThenInclude(carts => carts.CartProducts)
                    .Include(c => c.Orders)
                    .ThenInclude(orders => orders.OrderProducts)
                    .AsNoTracking()
                    .FirstOrDefault(c => c.AppUserFK == fk);
        }

        public Customer GetCustomerByID(int id)
        {
            return _context.Customers
                    .Include(c => c.Carts)
                    .ThenInclude(carts => carts.CartProducts)
                    .Include(c => c.Orders)
                    .ThenInclude(orders => orders.OrderProducts)
                    .AsNoTracking()
                    .FirstOrDefault(c => c.ID == id);
        }
    }
}
