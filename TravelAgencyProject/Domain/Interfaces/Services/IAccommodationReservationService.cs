using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Domain.Model;


namespace TravelAgencyProject.Service
{
    public interface IAccommodationReservationService
    {
        public List<AccommodationReservation> GetAll();
        public List<AccommodationReservation> GetByGuestId(int guestId);
        public List<AccommodationReservation> GetByAccommodationId(int accommodationId);
        public AccommodationReservation GetById(int id);
        public void ChangeStatusToRescheduled(int reservationId);
        public bool Cancel(int reservationId);
        public List<AccommodationReservation> GetReservationsForReviewing(int guestId);
        public void Update(AccommodationReservation accommodationReservation);

    }
}
