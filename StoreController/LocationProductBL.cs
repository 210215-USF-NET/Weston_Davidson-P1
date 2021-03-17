using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    /// <summary>
    /// Location BL tracks locationproduct business logic changes/requests
    /// LocationProducts are the same thing as a store inventory. These are products which belong to locations
    /// </summary>
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

        public List<LocationProduct> GetAllLP()
        {
            return _repo.GetAllLP();
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

        public void UpdateLocationProductManager(int id, int productQuantity)
        {
            _repo.UpdateLocationProduct(id, productQuantity);

        }
    }
}