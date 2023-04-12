using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;
using TravelAgencyProject.Service;

namespace TravelAgencyProject.Applications.Services
{
    public class RescheduleReservationRequestService
    {
        private RescheduleReservationRequestRepository rescheduleReservationRequestRepository;
        private readonly IAccommodationReservationService _accommodationReservationService;
 
        public RescheduleReservationRequestService(IAccommodationReservationService accommodationReservationService)
        {
            rescheduleReservationRequestRepository = new RescheduleReservationRequestRepository();
            _accommodationReservationService = accommodationReservationService;
        }

        public void Create(RescheduleReservationRequestDTO rescheduleReservationRequestDTO)
        {
            RescheduleReservationRequest rescheduleReservationRequest = new RescheduleReservationRequest(rescheduleReservationRequestDTO.ReservationId, rescheduleReservationRequestDTO.NewDate);

            _accommodationReservationService.ChangeStatusToRescheduled(rescheduleReservationRequestDTO.ReservationId);

            rescheduleReservationRequestRepository.Save(rescheduleReservationRequest);

        }

        public List<RescheduleReservationRequest> GetByAccommodationGuestId(int accommodationGuestId)
        {
            return rescheduleReservationRequestRepository.GetByAccommodationGuestId(accommodationGuestId);
        }

        public List<RescheduleReservationRequest> GetApprovedRequests(int accommodationGuestId)
        {
            return rescheduleReservationRequestRepository.GetApprovedRequests(accommodationGuestId);
        }

        public List<RescheduleReservationRequest> GetAll()
        {
            return rescheduleReservationRequestRepository.GetAll();
        }

        public void Update(RescheduleReservationRequest rescheduleReservationRequest)
        {
            rescheduleReservationRequestRepository.Update(rescheduleReservationRequest);
        }

        public bool IsAvailable(AccommodationReservation accommodationReservation, DateTime newDate)
        {
            AccommodationReservationRepository accommodationReservationRepository = new AccommodationReservationRepository();
            Accommodation accommodation = accommodationReservation.Accommodation;
            List<AccommodationReservation> accommodationReservations = accommodationReservationRepository.GetByAccommodationId(accommodation.Id);
            return CheckDateAvailability(accommodationReservations, newDate);
        }

        private bool CheckDateAvailability(List<AccommodationReservation> reservations, DateTime newDate)
        {
            bool isAvailable = true;
            foreach (AccommodationReservation reservation in reservations)
            {
                if (newDate <= reservation.Date && newDate.AddDays(reservation.ReservedDayNumber) >= reservation.Date || newDate <= reservation.Date.AddDays(reservation.ReservedDayNumber) && newDate >= reservation.Date)
                {
                    isAvailable = false;
                    break;
                }
            }
            return isAvailable;
        }

        public RescheduleReservationRequest GetById(int id)
        {
            return rescheduleReservationRequestRepository.GetById(id);
        }

        public List<RescheduleReservationRequest> GetByStatus(RescheduleReservationStatus status)
        {
            return rescheduleReservationRequestRepository.GetByStatus(status);
        }
    }
}
