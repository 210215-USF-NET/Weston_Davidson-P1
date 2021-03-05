using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData.Entities
{
    public partial class Cartproduct
    {
        public int CartProductsId { get; set; }
        public int? ProductCount { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int? InventoryId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Product Product { get; set; }
    }
}
