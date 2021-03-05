using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;


namespace StoreController
{
    public interface ILocationProductBL
    {
        void AddLocationProduct(LocationProduct newLocationProduct);

        List<LocationProduct> GetLocationProducts();

        void UpdateLocationProduct(LocationProduct locationProductForupdating);
    }
}