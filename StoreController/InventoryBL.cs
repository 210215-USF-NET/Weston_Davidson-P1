using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public class InventoryBL : IInventoryBL
    {

        
        private IInventoryRepoDB _repo;

        public InventoryBL(IInventoryRepoDB repo){
            _repo = repo;
        }

        public void AddInventory(Inventory newInventory)
        {
            _repo.AddInventory(newInventory);
        }

        public List<Inventory> GetInventory()
        {
            return _repo.GetInventory();
        }

        public void UpdateInventory(Inventory inventoryForUpdating)
        {
            _repo.UpdateInventory(inventoryForUpdating);
        }
    }
}