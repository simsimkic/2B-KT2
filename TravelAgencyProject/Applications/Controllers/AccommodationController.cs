using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Controller
{
    public class AccommodationController
    {
        private AccommodationService accommodationService;

        public AccommodationController()
        {
            accommodationService = new AccommodationService();
        }
        public void Save(Accommodation accommodation)
        {
            accommodationService.Save(accommodation);
        }

        public List<Accommodation> GetAll()
        {
            return accommodationService.GetAll();
        }

        public List<Accommodation> GetByCity(string city)
        {
            return accommodationService.GetByCity(city);
        }
        public List<Accommodation> GetByState(string state)
        {
            return accommodationService.GetByState(state);
        }

        public List<Accommodation> GetByName(string name)
        {
            return accommodationService.GetByName(name);
        }
        public List<Accommodation> GetByGuestsNumber(int guestsNumber)
        {
            return accommodationService.GetByGuestsNumber(guestsNumber);
        }

        public List<Accommodation> GetByReservedDaysNumber(int reservedDaysNumber)
        {
            return accommodationService.GetByReservedDaysNumber(reservedDaysNumber);
        }

        public List<Accommodation> GetByType(AccommodationType type)
        {
            return accommodationService.GetByType(type);
        }

        public List<Accommodation> GetByOwnerId(int ownerId)
        {
            return accommodationService.GetByOwnerId(ownerId);
        }

    }
}
