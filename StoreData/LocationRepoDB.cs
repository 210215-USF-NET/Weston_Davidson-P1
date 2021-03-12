using StoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData
{
    public class LocationRepoDB : ILocationRepository
    {
        private readonly StoreDBContext _context;

        public LocationRepoDB(StoreDBContext context)
        {
            _context = context;
        }

        public List<Location> GetLocations()
        {
            return _context.Locations.Select(l => l).ToList();

        }

        public Location GetSpecifiedLocation(int locationID)
        {
            return _context.Locations.Where(l => l.ID == locationID).FirstOrDefault();
        }

        public Location GetLocationByName(string locationName)
        {
            return _context.Locations.Where(l => l.LocationName == locationName).FirstOrDefault();
        }
    }
}
