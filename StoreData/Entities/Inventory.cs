using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData.Entities
{
    public partial class Inventory
    {
        public Inventory()
        {
            Cartproducts = new HashSet<Cartproduct>();
        }

        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public int? ProductQuantity { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Cartproduct> Cartproducts { get; set; }
    }
}
