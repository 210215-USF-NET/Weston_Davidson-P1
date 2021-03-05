using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public class LocationProductBL : ILocationProductBL
    {


        private ILocationProductRepoDB _repo;

        public LocationProductBL(ILocationProductRepoDB repo)
        {
            _repo = repo;
        }

        public void AddLocationProduct(LocationProduct newInventory)
        {
            _repo.AddLocationProduct(newInventory);
        }

        public List<LocationProduct> GetLocationProducts()
        {
            return _repo.GetLocationProducts();
        }

        public void UpdateLocationProduct(LocationProduct inventoryForUpdating)
        {
            _repo.UpdateLocationProduct(inventoryForUpdating);
        }
    }
}