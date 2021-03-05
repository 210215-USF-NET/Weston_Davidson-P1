using System.IO;
using System.Collections.Generic;
using StoreModel;
using System.Text.Json;
using System;


namespace StoreData
{
    public class OrderRepoFile : IOrderRepository
    {



        private string jsonString;
        private string filePath = "../OrderRepoFile.json";

        public Order AddOrder(Order newOrder){

            List<Order> ordersFromFile = new List<Order>();

            ordersFromFile = GetOrders();

            ordersFromFile.Add(newOrder);

            jsonString = JsonSerializer.Serialize(ordersFromFile);
            File.WriteAllText(filePath, jsonString);

            return newOrder;
        }

        public List<Order> GetOrders(){


            try{
                jsonString = File.ReadAllText(filePath);
            }
            catch(Exception){
                return new List<Order>();
            }

            return JsonSerializer.Deserialize<List<Order>>(jsonString);
        }

        public List<Order> GetOrdersWithCustomers()
        {
            throw new NotImplementedException();
        }

        public Order GetSpecifiedOrder()
        {
            throw new NotImplementedException();
        }

        public Order GetSpecifiedOrder(DateTime exactDateTime)
        {
            throw new NotImplementedException();
        }
    }
}