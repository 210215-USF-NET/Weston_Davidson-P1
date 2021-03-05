using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;


namespace StoreController
{
    public interface IInventoryBL
    {
    void AddInventory(Inventory newInventory);

        List<Inventory> GetInventory();

        void UpdateInventory(Inventory inventoryForUpdating);
    }
}