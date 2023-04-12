using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Services
{
    public class TourService
    {
        private TourRepository tourRepository = new TourRepository();
        private LocationRepository locationRepository = new LocationRepository();
        private TourArrangementRepository tourArrangementRepository = new TourArrangementRepository();

        public TourService()
        {
            tourRepository = new TourRepository();
            locationRepository = new LocationRepository();
            tourArrangementRepository = new TourArrangementRepository();
        }


        public List<Tour> GetAll()
        {
            return tourRepository.GetAll();
        }

        public Tour GetById(int id)
        {
            return tourRepository.GetById(id);
        }

        public List<Tour> GetTodaysTours()
        {
            return tourRepository.GetByDate(DateTime.Today);
        }

        public void Create(CreateTourDTO tourDTO)
        {
            List<CheckPoint> checkPoints = CreateCheckPoints(tourDTO);

            DateTime dateTime = Convert.ToDateTime(tourDTO.Date + " " + tourDTO.Time);

            string imageUrls = "";
            foreach (string url in tourDTO.ImageUrls)
            {
                imageUrls += url + " ";
            }

            Tour newTour = new Tour
            {
                Name = tourDTO.TourName,
                Description = tourDTO.Description,
                Language = tourDTO.Language,
                MaxGuestNumber = tourDTO.MaxGuestNumber,
                CheckPoints = checkPoints,
                DateTime = dateTime,
                Duration = tourDTO.Duration,
                Images = imageUrls
            };


            //We have to check if the given location already exists
            Location existingLocation;

            if ((existingLocation = locationRepository.GetByCity(tourDTO.CityName)) != null)
            {
                newTour.LocationId = existingLocation.Id;
            }
            else
            {
                newTour.Location = new Location(tourDTO.CityName, tourDTO.StateName);
            }

            tourArrangementRepository.Save(new TourArrangement
            {
                Tour = newTour,
                State = TourState.None,
                TourGuideId = UserSession.User.Id
            });
        }

        private CheckPoint SetCheckPointType(CreateTourDTO tourDTO, int i)
        {
            CheckPoint checkPoint;
            if (i == 0)
            {
                checkPoint = new CheckPoint(tourDTO.CheckPointCoordinates[i], CheckPointType.Start);

            }
            else if (i < tourDTO.CheckPointCoordinates.Count - 1)
            {
                checkPoint = new CheckPoint(tourDTO.CheckPointCoordinates[i], CheckPointType.Other);
            }
            else
            {
                checkPoint = new CheckPoint(tourDTO.CheckPointCoordinates[i], CheckPointType.End);
            }

            return checkPoint;
        }

        private List<CheckPoint> CreateCheckPoints(CreateTourDTO tourDTO)
        {
            List<CheckPoint> checkPoints = new List<CheckPoint>();
            for (int i = 0; i < tourDTO.CheckPointCoordinates.Count; i++)
            {
                CheckPoint checkPoint = SetCheckPointType(tourDTO, i);
                checkPoints.Add(checkPoint);
            }
            return checkPoints;
        }

        public List<Tour> GetByName(string name)
        {
            return tourRepository.GetByName(name);
        }

        public List<Tour> GetByState(string state)
        {
            return tourRepository.GetByState(state);
        }

        public List<Tour> GetByCity(string city)
        {
            return tourRepository.GetByCity(city);
        }

        public List<Tour> GetByDuration(int duration)
        {
            return tourRepository.GetByDuration(duration);
        }

        public List<Tour> GetByGuestsNumber(int guestsNumber)
        {
            return tourRepository.GetByGuestsNumber(guestsNumber);
        }

        public List<Tour> GetByLanguage(string language)
        {
            return tourRepository.GetByLanguage(language);
        }




    }
}
