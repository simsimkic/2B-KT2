using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Applications.Controller
{
    public class LocationController
    {
        private LocationService locationService = new LocationService();

        public void Save(Location location)
        {
            locationService.Save(location);
        }
    }
}
