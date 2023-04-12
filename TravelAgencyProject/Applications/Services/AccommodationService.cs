using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Services
{
    public class AccommodationService
    {
        private AccommodationRepository accommodationRepository = new AccommodationRepository();

        public AccommodationService()
        {
            accommodationRepository = new AccommodationRepository();
        }

        public List<Accommodation> GetAll()
        {
            return accommodationRepository.GetAll();
        }

        public List<Accommodation> GetByName(string name)
        {
            return accommodationRepository.GetByName(name);
        }

        public List<Accommodation> GetByState(string state)
        {
            return accommodationRepository.GetByState(state);
        }

        public List<Accommodation> GetByCity(string city)
        {
            return accommodationRepository.GetByCity(city);
        }

        public List<Accommodation> GetByType(AccommodationType type)
        {
            return accommodationRepository.GetByType(type);
        }

        public List<Accommodation> GetByGuestsNumber(int guestsNumber)
        {
            return accommodationRepository.GetByGuestsNumber(guestsNumber);
        }

        public List<Accommodation> GetByReservedDaysNumber(int reservedDaysNumber)
        {
            return accommodationRepository.GetByReservedDaysNumber(reservedDaysNumber);
        }


        public void Save(Accommodation accommodation)
        {
            accommodationRepository.Save(accommodation);
        }

        public Accommodation GetById(int id)
        {
            return accommodationRepository.GetById(id);
        }

        public List<Accommodation> GetByOwnerId(int ownerId)
        {
            return accommodationRepository.GetByOwnerId(ownerId);
        }
    }
}
