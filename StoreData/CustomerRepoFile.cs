using System.IO;
using System.Collections.Generic;
using StoreModel;
using System.Text.Json;
using System;

namespace StoreData
{
    public class CustomerRepoFile : ICustomerRepository
    {
        

        private string jsonString;
        private string filePath = "../CustomerRepoFile.json";

        public Customer AddCustomer(Customer newCustomer){

            List<Customer> customersFromFile = new List<Customer>();

            customersFromFile = GetCustomers();

            customersFromFile.Add(newCustomer);

            jsonString = JsonSerializer.Serialize(customersFromFile);
            File.WriteAllText(filePath, jsonString);

            return newCustomer;
        }

        public List<Customer> GetCustomers(){


            try{
                jsonString = File.ReadAllText(filePath);
            }
            catch(Exception){
                return new List<Customer>();
            }

            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }

        public List<Customer> GetSearchedCustomers()
        {
            throw new NotImplementedException();
        }
    }
}