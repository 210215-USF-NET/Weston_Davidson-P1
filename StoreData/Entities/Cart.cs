using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData.Entities
{
    public partial class Cart
    {
        public Cart()
        {
            Cartproducts = new HashSet<Cartproduct>();
            Orders = new HashSet<Order>();
        }

        public int CartId { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Cartproduct> Cartproducts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
