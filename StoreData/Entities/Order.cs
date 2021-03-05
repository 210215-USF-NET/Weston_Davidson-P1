using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData.Entities
{
    public partial class Order
    {
        public Order()
        {
            Orderitems = new HashSet<Orderitem>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public int CartId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Orderitem> Orderitems { get; set; }
    }
}
