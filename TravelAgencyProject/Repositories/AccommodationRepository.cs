using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Resources.DBAcces;

namespace TravelAgencyProject.Repository
{
    public class AccommodationRepository
    {
        private List<Accommodation> accommodations;
        private IDataHandler<Accommodation> accommodationDataHandler;
        private LocationRepository locationRepository;


        public AccommodationRepository()
        {
            accommodationDataHandler = new AccommodationDataHandler();
            accommodations = accommodationDataHandler.GetAll().ToList();
            locationRepository = new LocationRepository();
        }
        public List<Accommodation> GetAll()
        {
            return accommodations;
        }

        public List<Accommodation> GetByName(string name)
        {
            List<Accommodation> filteredAccommodations = new List<Accommodation>();
            foreach (Accommodation accommodation in accommodations){
                if(accommodation.Name.Contains(name))
                    filteredAccommodations.Add(accommodation);
            }
            return filteredAccommodations;
        }

        public List<Accommodation> GetByState(string state) 
        {

            List<Accommodation> filteredAccommodations = new List<Accommodation>();
            foreach (Accommodation accommodation in accommodations)
            {
                if (locationRepository.GetById(accommodation.LocationId).State.Equals(state))
                    filteredAccommodations.Add(accommodation);
            }
            return filteredAccommodations;
        }

        public List<Accommodation> GetByCity(string city)
        {

            List<Accommodation> filteredAccommodations = new List<Accommodation>();
            foreach (Accommodation accommodation in accommodations)
            {
                if (locationRepository.GetById(accommodation.LocationId).City.Equals(city))
                    filteredAccommodations.Add(accommodation);
            }
            return filteredAccommodations;
        }

        public List<Accommodation> GetByType(AccommodationType type)
        {

            List<Accommodation> filteredAccommodations = new List<Accommodation>();
            foreach (Accommodation accommodation in accommodations)
            {
                if (accommodation.Type == type)
                    filteredAccommodations.Add(accommodation);
            }
            return filteredAccommodations;
        }

        public List<Accommodation> GetByGuestsNumber(int guestsNumber)
        {

             List<Accommodation> filteredAccommodations = new List<Accommodation>();
             foreach (Accommodation accommodation in accommodations)
             {
                 if (accommodation.MaxGuestNumber >= guestsNumber)
                     filteredAccommodations.Add(accommodation);
             }
             return filteredAccommodations;
        }

        public List<Accommodation> GetByReservedDaysNumber(int reservedDaysNumber)
        {

            List<Accommodation> filteredAccommodations = new List<Accommodation>();
            foreach (Accommodation accommodation in accommodations)
            {
                if (accommodation.MinDayNumber <= reservedDaysNumber)
                    filteredAccommodations.Add(accommodation);
            }
            return filteredAccommodations;
        }

        
        public void Save(Accommodation accommodation)
        {
            accommodations.Add(accommodation);
            accommodationDataHandler.SaveOneEntity(accommodation);
        }

        public Accommodation GetById(int id)
        {
            return accommodations.FirstOrDefault(accommodation => accommodation.Equals(id));
        }

        public List<Accommodation> GetByOwnerId(int ownerId)
        {
            List<Accommodation> filteredAccommodations = new List<Accommodation>();
            foreach (Accommodation accommodation in accommodations)
            {
                if (accommodation.OwnerId <= ownerId)
                    filteredAccommodations.Add(accommodation);
            }
            return filteredAccommodations;
        }
    }
}
