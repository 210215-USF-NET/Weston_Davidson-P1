using StoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData
{
    public class LocationProductRepoDB : ILocationProductRepoDB
    {
        private readonly StoreDBContext _context;

        public LocationProductRepoDB(StoreDBContext context)
        {
            _context = context;
        }
        public LocationProduct AddLocationProduct(LocationProduct newInventory)
        {
            throw new NotImplementedException();
        }

        public List<LocationProduct> GetLocationProducts(int locationID)
        {
            return _context.LocationProducts.Where(lp => lp.LocationID == locationID).ToList();
        }

        public void UpdateLocationProduct(LocationProduct inventoryForUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
