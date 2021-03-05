using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData.Entities
{
    public partial class Orderitem
    {
        public int OrderItemsId { get; set; }
        public int? OrderItemQuantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
