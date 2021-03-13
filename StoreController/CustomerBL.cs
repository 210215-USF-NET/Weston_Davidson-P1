using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public class CustomerBL : ICustomerBL
    {
        //private Random rand = new Random();

        private ICustomerRepoDB _repo;

        public CustomerBL(ICustomerRepoDB repo)
        {
            _repo = repo;
        }



        public Customer AddCustomer(Customer newCustomer)
        {
            return _repo.AddCustomer(newCustomer);

        }

        public Customer DeleteCustomer(Customer customer2BDeleted)
        {
            return _repo.DeleteCustomer(customer2BDeleted);
        }

        public Customer GetCustomerByFirstName(string name)
        {
            return _repo.GetCustomerByFirstName(name);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();

        }

        public Customer GetCustomerByID(int id)
        {
            return _repo.GetCustomerByID(id);
        }

        public Customer GetCustomerByFK(string fk)
        {
            return _repo.GetCustomerByFK(fk);
        }



    }
}