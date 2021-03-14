using Microsoft.EntityFrameworkCore;
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
            return _context.LocationProducts
                .Include(lp => lp.Product)
                .AsNoTracking()
                .Where(lp => lp.LocationID == locationID)
                .ToList();
        }

        public void UpdateLocationProduct(LocationProduct inventoryForUpdate)
        {
            throw new NotImplementedException();
        }

        public void UpdateLocationProduct(int productID, int locationID, int productQuantity)
        {
            LocationProduct oldlp = _context.LocationProducts.Where(lp => lp.LocationID == locationID && lp.ProductID == productID).FirstOrDefault();
            LocationProduct updatedlp = new LocationProduct();
            if (productQuantity < 0)
            {
                updatedlp.ID = oldlp.ID;
                updatedlp.ProductID = oldlp.ProductID;
                updatedlp.LocationID = oldlp.LocationID;
                updatedlp.ProductQuantity = oldlp.ProductQuantity + productQuantity;
                updatedlp.LocationProductName = oldlp.LocationProductName;
            }
            if (productQuantity >= 0)
            {
                updatedlp.ID = oldlp.ID;
                updatedlp.ProductID = oldlp.ProductID;
                updatedlp.LocationID = oldlp.LocationID;
                updatedlp.ProductQuantity = productQuantity;
                updatedlp.LocationProductName = oldlp.LocationProductName;
            }

            _context.Entry(oldlp).CurrentValues.SetValues(updatedlp);

            _context.SaveChanges();
            _context.ChangeTracker.Clear();

        }
    }
}
