using System.Collections.Generic;
using StoreModel;

namespace StoreData
{
    public interface ICartRepoDB
    {
        List<Cart> GetCarts();

        Cart AddCart(Cart newCart);
        Cart AddCart(int customerID, int locationID);

        Cart FindCart(int customerID);
        Cart FindCart(int customerID, int locationID);

    }
}