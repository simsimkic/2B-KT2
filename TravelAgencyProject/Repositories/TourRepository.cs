using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Resources.DBAcces;

namespace TravelAgencyProject.Repository
{
    public class TourRepository
    {
        private List<Tour> tours;
        private readonly IDataHandler<Tour> tourDataHandler;
        private LocationRepository locationRepository;

        public TourRepository()
        {
            tourDataHandler = new TourDataHandler();
            locationRepository = new LocationRepository();
            tours = tourDataHandler.GetAll().ToList();
        }
        public List<Tour> GetAll()
        {
            return tours;
        }

        public Tour GetById(int id)
        {
            return tours.FirstOrDefault(tour => tour.Equals(id));
        }
        public Tour Save(Tour tour)
        {
            tours.Add(tour);
            return tourDataHandler.SaveOneEntity(tour);
        }

        public List<Tour> GetByName(string name)
        {
            List<Tour> filteredTours = new List<Tour>();
            foreach (Tour tour in tours)
            {
                if (tour.Name.Contains(name))
                    filteredTours.Add(tour);
            }
            return filteredTours;
        }

        public List<Tour> GetByState(string state)
        {

            List<Tour> filteredTours = new List<Tour>();
            foreach (Tour tour in tours)
            {
                if (locationRepository.GetById(tour.LocationId).State.Equals(state))
                    filteredTours.Add(tour);
            }
            return filteredTours;
        }

        public List<Tour> GetByCity(string city)
        {

            List<Tour> filteredTours = new List<Tour>();
            foreach (Tour tour in tours)
            {
                if (locationRepository.GetById(tour.LocationId).City.Equals(city))
                    filteredTours.Add(tour);
            }
            return filteredTours;
        }

        public List<Tour> GetByDuration(int duration)
        {

            List<Tour> filteredTours = new List<Tour>();
            foreach (Tour tour in tours)
            {
                if (tour.Duration == duration)
                    filteredTours.Add(tour);
            }
            return filteredTours;
        }

        public List<Tour> GetByLanguage(string language)
        {

            List<Tour> filteredTours = new List<Tour>();
            foreach (Tour tour in tours)
            {
                if (tour.Language.Contains(language))
                    filteredTours.Add(tour);
            }
            return filteredTours;
        }

        public List<Tour> GetByGuestsNumber(int guestsNumber)
        {

            List<Tour> filteredTours = new List<Tour>();
            foreach (Tour tour in tours)
            {
                if (tour.MaxGuestNumber >= guestsNumber)
                    filteredTours.Add(tour);
            }
            return filteredTours;
        }

        public List<Tour> GetByDate(DateTime dateTime)
        {

            List<Tour> filteredTours = new List<Tour>();
            foreach (Tour tour in tours)
            {
                if (tour.DateTime.Date.Equals(dateTime.Date))
                    filteredTours.Add(tour);
            }
            return filteredTours;
        }
    }
}
