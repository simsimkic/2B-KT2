using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Interfaces.Services;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Service;

namespace TravelAgencyProject.Applications.Controller
{
    public class AccommodationReservationController
    {
        
        private readonly IAccommodationReservationService _accommodationReservationService;
        private readonly IAccommodationReservationCreationService _accommodationReservationCreationService;

        public AccommodationReservationController(IAccommodationReservationService accommodationReservationService, IAccommodationReservationCreationService accommodationReservationCreationService)
        {
            _accommodationReservationService = accommodationReservationService;
            _accommodationReservationCreationService = accommodationReservationCreationService;
        }

        public bool CheckReservedDays(int accommodationId, int reservedDaysNumber)
        {
            return _accommodationReservationCreationService.CheckReservedDays(accommodationId, reservedDaysNumber);
        }

        public List<string> CheckAvalibleDates(AccommodationReservationDto reservationRequest)
        {
            return _accommodationReservationCreationService.CheckAvailableDates(reservationRequest);
        }
        public List<string> FindNewAvalibleDates(AccommodationReservationDto reservationRequest)
        {
            return _accommodationReservationCreationService.FindNewAvailableDates(reservationRequest);
        }

        public bool CheckGuestNumber(int accommodationId, int guestNumber)
        {
            return _accommodationReservationCreationService.CheckGuestNumber(accommodationId, guestNumber);
        }

        public void Create(AccommodationReservationDto reservation, DateTime date, int guestNumber)
        { 
            _accommodationReservationCreationService.Create(reservation, date, guestNumber);
        }

        public List<AccommodationReservation> GetAll()
        {
            return _accommodationReservationService.GetAll();
        }

        public List<AccommodationReservation> GetByGuestId(int guestId)
        {
            return _accommodationReservationService.GetByGuestId(guestId);
        }

        public bool Cancel(int reservationId)
        {
            return _accommodationReservationService.Cancel(reservationId);
        }

        public List<AccommodationReservation> GetReservationsForReviewing(int guestId)
        {
            return _accommodationReservationService.GetReservationsForReviewing(guestId);
        }

        public void Update(AccommodationReservation accommodationReservation)
        {
            _accommodationReservationService.Update(accommodationReservation);
        }

        public List<AccommodationReservation> GetByAccommodationId(int accommodationId)
        {
            return _accommodationReservationService.GetByAccommodationId(accommodationId);
        }
    }
}
