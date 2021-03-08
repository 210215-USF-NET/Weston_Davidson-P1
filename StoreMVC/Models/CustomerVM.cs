using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class CustomerVM
    {

        public int ID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string Username { get; set; }



        public string PasswordHash { get; set; }





        public ICollection<CartVM> Carts { get; set; }

        public ICollection<OrderVM> Orders { get; set; }



    }
}
