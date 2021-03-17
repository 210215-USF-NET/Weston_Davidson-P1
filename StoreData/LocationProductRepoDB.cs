using Microsoft.EntityFrameworkCore;
using StoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData
{
    /// <summary>
    /// LocationProductsRepo tracks LocationProducts data layer access for changes/requests
    /// </summary>
    public class LocationProductRepoDB : ILocationProductRepoDB
    {
        private readonly StoreDBContext _context;

        public LocationProductRepoDB(StoreDBContext context)
        {
            _context = context;
        }

        public List<LocationProduct> GetAllLP()
        {
            return _context.LocationProducts
                .Include(lp => lp.Product)
                .Include(lp => lp.Location)
                .AsNoTracking()
                .Select(o => o).ToList();
        }

        public LocationProduct AddLocationProduct(LocationProduct newInventory)
        {
            throw new NotImplementedException();
        }

        public List<LocationProduct> GetLocationProducts(int locationID)
        {
            return _context.LocationProducts
                .Include(lp => lp.Product)
                .Include(lp => lp.Location)
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


        public void UpdateLocationProduct(int id, int productQuantity)
        {
            LocationProduct oldlp = _context.LocationProducts.Where(lp => lp.ID == id).FirstOrDefault();
            LocationProduct updatedlp = new LocationProduct();

            updatedlp.ID = oldlp.ID;
            updatedlp.ProductID = oldlp.ProductID;
            updatedlp.LocationID = oldlp.LocationID;
            updatedlp.ProductQuantity = productQuantity;
            updatedlp.LocationProductName = oldlp.LocationProductName;


            _context.Entry(oldlp).CurrentValues.SetValues(updatedlp);

            _context.SaveChanges();
            _context.ChangeTracker.Clear();

        }



    }
}
