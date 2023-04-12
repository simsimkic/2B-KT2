using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Resources.DBAcces;

namespace TravelAgencyProject.Repository
{
    public class LocationRepository
    {
        private List<Location> locations;
        private readonly IDataHandler<Location> locationDataHandler;

        public LocationRepository()
        {
            locationDataHandler = new LocationDataHandler();
            locations = locationDataHandler.GetAll().ToList();
        }
        public List<Location> GetAll()
        {
            return locations;
        }

        public Location GetById(int id)
        {
            return locations.FirstOrDefault(location => location.Equals(id));
        }
        public Location Save(Location location)
        {
            locations.Add(location);
            return locationDataHandler.SaveOneEntity(location);
        }

        public Location GetByCity(string city)
        {
            return locations.FirstOrDefault(Location => Location.EqualsByCity(city));
        }
    }
}
