using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Interfaces.Services;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Controller
{
    public class TourArrangementController
    {
        private readonly ITourArrangementService _tourArrangementService;

        private readonly ITourArrangementCreationService _tourArrangementCreationService;

        private readonly ITourArrangementStatisticsService _tourArrangementStatisticsService;

        public TourArrangementController(ITourArrangementService tourArrangementService, ITourArrangementCreationService tourArrangementCreationService,  ITourArrangementStatisticsService tourArrangementStatisticsService)
        {
            _tourArrangementService = tourArrangementService;
            _tourArrangementStatisticsService = tourArrangementStatisticsService;
            _tourArrangementCreationService = tourArrangementCreationService;
        }
        public void Update(TourArrangement tourArrangement)
        {
            _tourArrangementService.Update(tourArrangement);
        }

        public int CreateArrangement(TourReservationDTO tourReservationDTO)
        {
            return _tourArrangementCreationService.CreateArrangement(tourReservationDTO);
        }

        public bool IsUserAlreadyAssigned(int tourGuestId, int tourId)
        {
            return _tourArrangementCreationService.IsUserAlreadyAssigned(tourGuestId, tourId);
        }

        public bool IsAvailable(int tourId, int tourGuestsNumber)
        {
            return _tourArrangementCreationService.IsAvailable(tourId, tourGuestsNumber);
        }

        public TourArrangement GetById(int id)
        {
            return _tourArrangementService.GetById(id);
        }

        public List<TourArrangement> GetAll()
        {
            return _tourArrangementService.GetAll();
        }
        public List<TourArrangement> GetTodaysTours()
        {
            return _tourArrangementService.GetAllTodaysTour();
        }

        public List<TourArrangement> GetFinishedTours()
        {
            return _tourArrangementService.GetFinishedTours();
        }

        public void CancelTour(TourArrangement tourArrangement)
        {
            _tourArrangementService.CancelTour(tourArrangement);
        }

        public TourArrangement GetMostVisitedTour(string chosenYear)
        {
            return _tourArrangementStatisticsService.GetMostVisitedTour(chosenYear);
        }

        public List<string> GetYearsFromTourDates()
        {
            return _tourArrangementStatisticsService.GetYearsFromTourDates();
        }

        public TourGuestStatisticsDTO GetTourGuestStatistics(int tourArrangementId)
        {
            return _tourArrangementStatisticsService.GetTourGuestStatistics(tourArrangementId);
        }

    }
}
