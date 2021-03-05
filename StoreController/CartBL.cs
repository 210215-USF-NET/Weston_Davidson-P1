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
            Cart cartFound = _repo.FindCart(customerID);

            //if no cart is found with that customer ID,
            //add a new cart to the database with the customer ID
            if (cartFound.CartID == 0){
                Cart cartToGenerate = new Cart();
                cartToGenerate.customerID = customerID;
                Cart generatedCart = _repo.AddCart(cartToGenerate);
                return generatedCart;
            }
            //otherwise, return the found cart
            else return cartFound;



        }

        public List<Cart> GetCarts()
        {
            return _repo.GetCarts();
        }

        
    }
}