using System;
using System.Collections.Generic;

namespace StoreModel
{
    
    /// <summary>
    /// Models our customer object in our database
    /// </summary>
    public class Customer
    {

        public int CustomerID {get; set;}

        public Customer()
        {
            Carts = new List<Cart>();
            Orders = new List<Order>();
        }
        public string FName {get; set;}

        public string LName {get; set;}

        public string Username {get; set;}



        public string PasswordHash {get; set;}

        

        public override string ToString()
        {
            
            return $"| First Name: {FName} | Last Name: {LName} | Customer ID: {CustomerID} |";
        }

        public List<Cart> Carts {get; set;}

        public List<Order> Orders {get; set;}


    
    
    }

}
