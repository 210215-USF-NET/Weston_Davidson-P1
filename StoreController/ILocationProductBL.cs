using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;


namespace StoreController
{
    public interface ILocationProductBL
    {
        void AddLocationProduct(LocationProduct newLocationProduct);

        List<LocationProduct> GetLocationProducts(int locationID);

        void UpdateLocationProduct(LocationProduct locationProductForupdating);

        void UpdateLocationProduct(int productID, int locationID, int productQuantity);
    }
}