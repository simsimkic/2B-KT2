using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Applications.DTOs
{
    public class RescheduleReservationRequestDTO
    {
        public int ReservationId { get; set; }
        public DateTime NewDate { get; set; }

        public RescheduleReservationRequestDTO() { }

        public RescheduleReservationRequestDTO(int reservationId, DateTime newDate)
        {
            ReservationId = reservationId;
            NewDate = newDate;
        }


    }
}
