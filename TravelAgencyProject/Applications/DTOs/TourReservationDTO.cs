using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Applications.DTOs
{
    public class TourReservationDTO
    {
        public int TourId { get; set; }

        public int TourGuestsNumber { get; set; }

        public TourReservationDTO() { }

        public TourReservationDTO(int tourId, int tourGuestsNumber)
        {
            TourId = tourId;
            TourGuestsNumber = tourGuestsNumber;
        }

    }
}
