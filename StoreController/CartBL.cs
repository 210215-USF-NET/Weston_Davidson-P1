using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public class CartBL : ICartBL
    {
        private ICartRepoDB _repo;

        public CartBL(ICartRepoDB repo)
        {
            _repo = repo;
        }

        public void AddCart(Cart newCart)
        {
            _repo.AddCart(newCart);
        }

        public Cart FindCart(int customerID)
        {
            //cart found is the db findcart method return
            return _repo.FindCart(customerID);




        }

        public List<Cart> GetCarts()
        {
            return _repo.GetCarts();
        }


    }
}