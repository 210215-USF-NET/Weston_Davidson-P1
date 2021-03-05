using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public interface ICartBL
    {
        void AddCart(Cart newCart);

        List<Cart> GetCarts();

        Cart FindCart(int customerID);
    }
}