using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public class CartBL : ICartBL
    {
        private ICartRepoDB _repo;
        private ILocationRepository _locationRepo;

        public CartBL(ICartRepoDB repo, ILocationRepository locationRepo)
        {
            _repo = repo;
            _locationRepo = locationRepo;
        }

        public void AddCart(Cart newCart)
        {
            _repo.AddCart(newCart);
        }

        public Cart FindCart(int customerID, int locationID)
        {
            //cart found is the db findcart method return
            try
            {
                return _repo.FindCart(customerID, locationID);
            }
            catch (NullReferenceException)
            {

                return _repo.AddCart(customerID, locationID);
            }
            catch (InvalidOperationException)
            {

                return _repo.AddCart(customerID, locationID);
            }





        }

        public void RemoveCartByLocation(string locationName, int customerID)
        {
            if (locationName == "Tampa")
            {
                _repo.RemoveCartByLocation("Orlando", customerID);
            }
            else
                _repo.RemoveCartByLocation("Tampa", customerID);

        }

        public List<Cart> GetCarts()
        {
            return _repo.GetCarts();
        }


    }
}