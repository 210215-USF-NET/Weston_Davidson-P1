using System.Collections.Generic;
using Model = StoreModel;
using Entity = StoreData.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModel;

namespace StoreData
{
    public class InventoryRepoDB : IInventoryRepoDB
    {

        private Entity.P0Context _context;
        private IMapper _mapper;

        public InventoryRepoDB(Entity.P0Context context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public Inventory AddInventory(Inventory newInventory)
        {
            _context.Inventories.Add(_mapper.ParseInventory(newInventory));
            _context.SaveChanges();
            return newInventory;
        }

        public List<Inventory> GetInventory()
        {
            //retrieve all inventories
            List<Inventory> inventorys = _context.Inventories.Select(x => _mapper.ParseInventory(x)).ToList();
            //for each inventory
            foreach(Inventory inventory in inventorys){
            //assign a location object to it (one inventory can only have one location)
                Entity.Location location = _context.Locations.Find(inventory.InventoryLocation);
                Entity.Product product = _context.Products.Find(inventory.ProductID);
                inventory.Location = _mapper.ParseLocation(location);
                inventory.Product = _mapper.ParseProduct(product);
            }

            return inventorys;
        
        }

        public void UpdateInventory(Inventory inventoryForUpdate)
        {
            //find details for old inventory
            Entity.Inventory oldInventory = _context.Inventories.Find(inventoryForUpdate.InventoryID);
            oldInventory.ProductQuantity = inventoryForUpdate.ProductQuantity;
            
            _context.Inventories.Update(oldInventory);

            //_context.Entry(oldInventory).CurrentValues.SetValues(_mapper.ParseInventory(inventoryForUpdate).ProductQuantity);
            
            _context.SaveChanges();

            _context.ChangeTracker.Clear();
        }
    }
}