using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.Controller;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Applications.DTOs
{
    public class ApprovedReservationRequestDTO
    {
        public ApprovedReservationRequestDTO()
        {
        }

        public AccommodationReservation Reservation { get; set; }
        public DateTime NewDate { get; set; }
        public string AvailabilityMessage { get; set; }

        public int RescheduleReservationRequestId { get; set; }

        public ApprovedReservationRequestDTO(AccommodationReservation reservation, DateTime newDate)
        {
            RescheduleReservationRequestController rescheduleReservationRequestController =  (RescheduleReservationRequestController)App.Services.GetService(typeof(RescheduleReservationRequestController));

            Reservation = reservation;
            NewDate = newDate;
            AvailabilityMessage = rescheduleReservationRequestController.isAvailable(reservation, newDate) ? "Date is Available." : "Date is already taken.";
        }

        public ApprovedReservationRequestDTO(AccommodationReservation reservation, DateTime newDate, int id)
        {
            RescheduleReservationRequestController rescheduleReservationRequestController =  (RescheduleReservationRequestController)App.Services.GetService(typeof(RescheduleReservationRequestController));

            Reservation = reservation;
            NewDate = newDate;
            RescheduleReservationRequestId = id;
            AvailabilityMessage = rescheduleReservationRequestController.isAvailable(reservation, newDate) ? "Date is available." : "Date is already taken.";
        }


    }
}
