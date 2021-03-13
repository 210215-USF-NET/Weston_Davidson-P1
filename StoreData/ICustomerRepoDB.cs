using StoreModel;
using System.Collections.Generic;

namespace StoreData
{
    public interface ICustomerRepoDB
    {
        Customer AddCustomer(Customer newCustomer);
        Customer DeleteCustomer(Customer customer2BDeleted);
        Customer GetCustomerByFirstName(string name);
        List<Customer> GetCustomers();
        public Customer GetCustomerByID(int id);
        Customer GetCustomerByFK(string fk);
    }
}