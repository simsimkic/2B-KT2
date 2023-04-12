using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Applications.Controller
{
    public class TourController
    {
        private TourService tourService = new TourService();

        public void Create(CreateTourDTO createTourDTO)
        {
            tourService.Create(createTourDTO);
        }

        public List<Tour> GetAll()
        {
            return tourService.GetAll();
        }

        public List<Tour> GetTodaysTours()
        {
            return tourService.GetTodaysTours();
        }

        public List<Tour> GetByName(string name)
        {
            return tourService.GetByName(name);
        }

        public List<Tour> GetByState(string state)
        {
            return tourService.GetByState(state);
        }

        public List<Tour> GetByCity(string city)
        {
            return tourService.GetByCity(city);
        }

        public List<Tour> GetByDuration(int duration)
        {
            return tourService.GetByDuration(duration);
        }

        public List<Tour> GetByGuestsNumber(int guestsNumber)
        {
            return tourService.GetByGuestsNumber(guestsNumber);
        }

        public List<Tour> GetByLanguage(string language)
        {
            return tourService.GetByLanguage(language);
        }
    }
}
