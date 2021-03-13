using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public class LocationProductBL : ILocationProductBL
    {


        private readonly ILocationProductRepoDB _repo;

        public LocationProductBL(ILocationProductRepoDB repo)
        {
            _repo = repo;
        }

        public void AddLocationProduct(LocationProduct newInventory)
        {
            _repo.AddLocationProduct(newInventory);
        }

        public List<LocationProduct> GetLocationProducts(int locationID)
        {
            return _repo.GetLocationProducts(locationID);
        }

        public void UpdateLocationProduct(LocationProduct inventoryForUpdating)
        {
            _repo.UpdateLocationProduct(inventoryForUpdating);
        }

        public void UpdateLocationProduct(int productID, int locationID, int productQuantity)
        {
            _repo.UpdateLocationProduct(productID, locationID, productQuantity);
        }
    }
}