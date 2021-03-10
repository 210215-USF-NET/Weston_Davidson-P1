using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public interface ICustomerBL
    {



        Customer AddCustomer(Customer newCustomer);

        List<Customer> GetCustomers();

        Customer DeleteCustomer(Customer customer2BDeleted);

        Customer GetCustomerByFirstName(string name);

        Customer GetCustomerByFK(string fk);
    }
}