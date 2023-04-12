using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Services
{
    public class LocationService
    {
        private LocationRepository locationRepository = new LocationRepository();

        public void Save(Location location)
        {
            locationRepository.Save(location);
        }


    }
}
