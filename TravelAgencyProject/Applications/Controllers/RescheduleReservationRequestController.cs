using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Service;

namespace TravelAgencyProject.Applications.Controller
{
    public class RescheduleReservationRequestController
    {
        private readonly IAccommodationReservationService _accommodationReservationService;
        private RescheduleReservationRequestService rescheduleReservationRequestService;

        public RescheduleReservationRequestController(IAccommodationReservationService accommodationReservationService) 
        { 
            
            _accommodationReservationService = accommodationReservationService;
            rescheduleReservationRequestService = new RescheduleReservationRequestService(accommodationReservationService);
        }

        public void Create(RescheduleReservationRequestDTO rescheduleReservationRequestDTO)
        {
            rescheduleReservationRequestService.Create(rescheduleReservationRequestDTO);
        }

        public List<RescheduleReservationRequest> GetByAccommodationGuestId(int accommodationGuestId)
        {
            return rescheduleReservationRequestService.GetByAccommodationGuestId(accommodationGuestId);
        }

        public List<RescheduleReservationRequest> GetApprovedRequests(int accommodationGuestId)
        {
            return rescheduleReservationRequestService.GetApprovedRequests(accommodationGuestId);
        }

        public List<RescheduleReservationRequest> GetAll()
        {
            return rescheduleReservationRequestService.GetAll();
        }

        public void Update(RescheduleReservationRequest rescheduleReservationRequest)
        {
            rescheduleReservationRequestService.Update(rescheduleReservationRequest);
        }

        public bool isAvailable(AccommodationReservation accommodationReservation, DateTime newDate)
        {
            return rescheduleReservationRequestService.IsAvailable(accommodationReservation, newDate);
        }

        public RescheduleReservationRequest GetById(int id)
        {
            return rescheduleReservationRequestService.GetById(id);
        }

        public List<RescheduleReservationRequest> GetByStatus(RescheduleReservationStatus status)
        {
            return rescheduleReservationRequestService.GetByStatus(status);
        }
    }
}
