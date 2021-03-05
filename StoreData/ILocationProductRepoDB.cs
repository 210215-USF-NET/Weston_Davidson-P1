using System.Collections.Generic;
using StoreModel;

namespace StoreData
{
    public interface ILocationProductRepoDB
    {
        List<LocationProduct> GetLocationProducts();

        LocationProduct AddLocationProduct(LocationProduct newInventory);

        void UpdateLocationProduct(LocationProduct inventoryForUpdate);
    }
}