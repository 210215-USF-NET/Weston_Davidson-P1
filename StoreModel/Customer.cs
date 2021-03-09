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



        public ApplicationUser ApplicationUser { get; set; }
#nullable enable
        public string? AppUserFK { get; set; }

#nullable disable
        public ICollection<Cart> Carts { get; set; }

        public ICollection<Order> Orders { get; set; }




    }

}
