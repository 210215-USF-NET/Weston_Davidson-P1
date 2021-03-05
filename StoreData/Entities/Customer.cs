using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerFname { get; set; }
        public string CustomerLname { get; set; }
        public string CustomerPasswordhash { get; set; }
        public string CustomerUsername { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
