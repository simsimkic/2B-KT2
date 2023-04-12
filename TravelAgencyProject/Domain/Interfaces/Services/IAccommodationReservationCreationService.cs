using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Domain.Interfaces.Services
{
    public interface IAccommodationReservationCreationService
    {
        public bool AreAllReservedDaysAvailable(DateTime startDate, List<DateTime> freeDates, int reservedDays);

        public List<string> CheckAvailableDates(AccommodationReservationDto reservationRequest);


        public bool CheckGuestNumber(int accommodationId, int guestNumber);

        public bool CheckReservedDays(int accommodationId, int reservedDaysNumber);

        public List<string> ConvertDatesToRange(List<DateTime> freeDates, int reservedDays);

        public void Create(AccommodationReservationDto reservation, DateTime date, int guestNumber);
        public List<string> FindNewAvailableDates(AccommodationReservationDto reservationRequest);

        public bool IsDateAvailable(int accommodationId, DateTime date);
    }
}
