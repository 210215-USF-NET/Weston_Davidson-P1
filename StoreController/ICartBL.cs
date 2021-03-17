using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{

    /// <summary>
    /// Interface Cart BL tracks Cart business logic changes
    /// </summary>
    public interface ICartBL
    {
        void AddCart(Cart newCart);

        List<Cart> GetCarts();

        Cart FindCart(int customerID, int locationID);

        void RemoveCartByLocation(string locationName, int customerID);
    }
}