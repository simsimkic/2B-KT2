using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{
    [Table("RescheduleReservationRequest")]

    public class RescheduleReservationRequest
    {
        public RescheduleReservationRequest()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ReservationId { get; set; }

        [ForeignKey("ReservationId")]

        public virtual AccommodationReservation Reservation { get; set; }

        public DateTime NewDate { get; set; }

        public RescheduleReservationStatus Status { get; set; }

        public string RejectionSummary { get; set; }

        public RescheduleReservationRequest(int reservationId, DateTime newDate)
        {
            ReservationId = reservationId;
            NewDate = newDate;
            Status = RescheduleReservationStatus.Pending;
            RejectionSummary = "";
        }


    }

}

