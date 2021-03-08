using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreModel
{

    /// <summary>
    /// Models our customer object in our database
    /// </summary>
    public class Customer
    {

        public int ID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string Username { get; set; }



        public string PasswordHash { get; set; }

        [ForeignKey("AppUserFK")]
        public ApplicationUser AppUser { get; set; }

        public string AppUserFK { get; set; }


        public ICollection<Cart> Carts { get; set; }

        public ICollection<Order> Orders { get; set; }




    }

}
