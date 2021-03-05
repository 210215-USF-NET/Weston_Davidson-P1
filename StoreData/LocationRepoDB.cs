using System.Collections.Generic;
using Model = StoreModel;
using Entity = StoreData.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModel;

namespace StoreData
{
    public class LocationRepoDB : ILocationRepository
    {
        private Entity.P0Context _context;
        private IMapper _mapper;

        public LocationRepoDB(Entity.P0Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Location> GetLocations()
        {

            return _context.Locations.Select(x => _mapper.ParseLocation(x)).ToList();

        
        }

        public Location GetSpecifiedLocation(int locationID)
        {
            
            Entities.Location location = _context.Locations.Find(locationID);
            return _mapper.ParseLocation(location);
        }
    }
}