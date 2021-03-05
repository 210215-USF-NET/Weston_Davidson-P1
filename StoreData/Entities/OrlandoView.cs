using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData.Entities
{
    public partial class OrlandoView
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public int? ProductQuantity { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
    }
}
