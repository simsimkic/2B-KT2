using System;
using System.Collections.Generic;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Interfaces.Repositories;
using TravelAgencyProject.Domain.Interfaces.Services;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;
using TravelAgencyProject.Service;

namespace TravelAgencyProject.Applications.Services
{
    public class AccommodationReservationCreationService : IAccommodationReservationCreationService
    {

        private readonly IAccommodationReservationRepository _accommodationReservationRepository;
        private IAccommodationReservationService _accommodationReservationService;
        private AccommodationService accommodationService;

        public AccommodationReservationCreationService(IAccommodationReservationService accommodationReservationService, IAccommodationReservationRepository accommodationReservationRepository)
        {
            _accommodationReservationRepository = accommodationReservationRepository;
            _accommodationReservationService = accommodationReservationService;
            accommodationService = new AccommodationService();
        }

        public bool AreAllReservedDaysAvailable(DateTime startDate, List<DateTime> freeDates, int reservedDays)
        {
            for (DateTime date = startDate.AddDays(1); date <= startDate.AddDays(reservedDays); date = date.AddDays(1))
            {
                if (!freeDates.Contains(date))
                    return false;
            }
            return true;
        }

        public List<string> CheckAvailableDates(AccommodationReservationDto reservationRequest)

        {

            List<DateTime> availbaleDates = new List<DateTime>();

            for (DateTime date = reservationRequest.startDate; date <= reservationRequest.endDate.AddDays(1); date = date.AddDays(1))
            {
                if (IsDateAvailable(reservationRequest.AccommodationId, date))
                {
                    availbaleDates.Add(date);
                }

            }

            return ConvertDatesToRange(availbaleDates, reservationRequest.ReservedDaysNumber);

        }


        public bool CheckGuestNumber(int accommodationId, int guestNumber)
        {
            return accommodationService.GetById(accommodationId).MaxGuestNumber >= guestNumber;
        }

        public bool CheckReservedDays(int accommodationId, int reservedDaysNumber)
        {
            return accommodationService.GetById(accommodationId).MinDayNumber <= reservedDaysNumber;

        }

        public List<string> ConvertDatesToRange(List<DateTime> freeDates, int reservedDays)
        {
            List<string> freeDatesRanges = new List<string>();

            foreach (DateTime date in freeDates)
            {
                if (AreAllReservedDaysAvailable(date, freeDates, reservedDays))
                {
                    string range = date.Date.ToShortDateString() + '-' + date.AddDays(reservedDays - 1).Date.ToShortDateString();
                    freeDatesRanges.Add(range);
                }
            }


            return freeDatesRanges;
        }

        public void Create(AccommodationReservationDto reservation, DateTime date, int guestNumber)
        {
            AccommodationReservation accommodationReservation = new AccommodationReservation(((AccommodationGuest)UserSession.User).Id, date, accommodationService.GetById(reservation.AccommodationId).Id, guestNumber, reservation.ReservedDaysNumber);

            _accommodationReservationRepository.Save(accommodationReservation);
        }

        public List<string> FindNewAvailableDates(AccommodationReservationDto reservationRequest)
        {
            List<DateTime> freeDates = new List<DateTime>();

            for (DateTime date = reservationRequest.endDate.AddDays(1); date <= reservationRequest.endDate.AddDays(90); date = date.AddDays(1))
            {
                if (IsDateAvailable(reservationRequest.AccommodationId, date))
                {
                    freeDates.Add(date);
                }

            }

            return ConvertDatesToRange(freeDates, reservationRequest.ReservedDaysNumber);
        }

        public bool IsDateAvailable(int accommodationId, DateTime date)
        {
            List<AccommodationReservation> accommodationReservations = _accommodationReservationService.GetByAccommodationId(accommodationId);

            foreach (AccommodationReservation reservation in accommodationReservations)
            {

                if (date >= reservation.Date && date <= reservation.Date.AddDays(reservation.ReservedDayNumber - 1))
                {
                    return false;
                }

            }
            return true;
        }
    }
}