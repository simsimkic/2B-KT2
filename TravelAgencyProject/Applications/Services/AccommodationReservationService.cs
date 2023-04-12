using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Interfaces.Repositories;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Service;

namespace TravelAgencyProject.Applications.Services
{
    public class AccommodationReservationService : IAccommodationReservationService
    {
        private readonly IAccommodationReservationRepository _accommodationReservationRepository;
        private readonly AccommodationService accommodationService;
        public AccommodationReservationService(IAccommodationReservationRepository accommodationReservationRepository)
        {
            _accommodationReservationRepository = accommodationReservationRepository;
            accommodationService = new AccommodationService();
        }

        public List<AccommodationReservation> GetAll()
        {
            return _accommodationReservationRepository.GetAll();
        }

        public List<AccommodationReservation> GetByGuestId(int guestId)
        {
            return _accommodationReservationRepository.GetByGuestId(guestId);
        }

        public List<AccommodationReservation> GetByAccommodationId(int accommodationId)
        {
            return _accommodationReservationRepository.GetByAccommodationId(accommodationId);
        }


        public AccommodationReservation GetById(int id)
        {
            return _accommodationReservationRepository.GetById(id);
        }

        public void ChangeStatusToRescheduled(int reservationId)
        {
            AccommodationReservation reservation = GetById(reservationId);
            reservation.Status = AccommodationReservationStatus.Rescheduled;
            _accommodationReservationRepository.Update(reservation);
        }

        public bool Cancel(int reservationId)
        {
            AccommodationReservation reservation = GetById(reservationId);
            DateTime todaysDate = DateTime.Now;
            if (DateTime.Now.AddHours(24) < reservation.Date && DateTime.Now.AddDays(reservation.Accommodation.MinCancelationDays) < reservation.Date)
            {
                reservation.Status = AccommodationReservationStatus.Canceled;
                _accommodationReservationRepository.Update(reservation);
                return true;
            }

            return false;

        }

        public List<AccommodationReservation> GetReservationsForReviewing(int guestId)
        {
            List<AccommodationReservation> guestsReservations = GetByGuestId(guestId);
            List<AccommodationReservation> reservationsForReviewing = new List<AccommodationReservation>();

            for (int i = 0; i < guestsReservations.Count; i++)
            {
                if (guestsReservations[i].Date.AddDays(5) >= DateTime.Now && guestsReservations[i].Date < DateTime.Now)
                {
                    reservationsForReviewing.Add(guestsReservations[i]);
                }
            }

            return reservationsForReviewing;
        }

        public void Update(AccommodationReservation accommodationReservation)
        {
            _accommodationReservationRepository.Update(accommodationReservation);
        }

    }
}
