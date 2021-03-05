using System.Collections.Generic;
using StoreModel;

namespace StoreData
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();

        Customer AddCustomer(Customer newCustomer);


    }
}