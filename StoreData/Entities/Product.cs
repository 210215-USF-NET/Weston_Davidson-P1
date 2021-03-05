using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData.Entities
{
    public partial class Product
    {
        public Product()
        {
            Cartproducts = new HashSet<Cartproduct>();
            Inventories = new HashSet<Inventory>();
            Orderitems = new HashSet<Orderitem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }
        public string Manufacturer { get; set; }

        public virtual ICollection<Cartproduct> Cartproducts { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Orderitem> Orderitems { get; set; }
    }
}
