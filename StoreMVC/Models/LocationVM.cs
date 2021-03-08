using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class LocationVM
    {
        public int ID { get; set; }

        public string LocationName { get; set; }

        public ICollection<OrderVM> Orders { get; set; }

        public ICollection<CartVM> Cart { get; set; }

        public ICollection<LocationProductVM> LocationProducts { get; set; }


        public string Address { get; set; }
    }
}
