using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Applications.DTOs
{
    public class AccommodationReservationDto
    {
        public AccommodationReservationDto()
        {
        }

        public int AccommodationId { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public int ReservedDaysNumber { get; set; }

        public AccommodationReservationDto(int accommodationId, DateTime startDate, DateTime endDate, int reservedDaysNumber)
        {
            AccommodationId = accommodationId;
            this.startDate = startDate;
            this.endDate = endDate;
            ReservedDaysNumber = reservedDaysNumber;
        }
    }
}
