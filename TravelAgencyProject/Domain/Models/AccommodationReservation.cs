using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TravelAgencyProject.Domain.Model
{
    [Table("AccommodationReservation")]
    public class AccommodationReservation
    {
        public AccommodationReservation() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AccommodationGuestId { get; set; }

        [ForeignKey("AccommodationGuestId")]
        public virtual AccommodationGuest Guest { get; set; }
        public DateTime Date { get; set; }

        public int AccommodationId { get; set; }

        [ForeignKey("AccommodationId")]
        public virtual Accommodation Accommodation { get; set; }

        public int GuestsNumber { get; set; }

        public int ReservedDayNumber { get; set; }

        public AccommodationReservationStatus Status { get; set; }

        public AccommodationReservation(AccommodationGuest guest, DateTime date, Accommodation accommodation, int guestsNumber, int reservedDayNumber)
        {
            Guest = guest;
            Date = date;
            Accommodation = accommodation;
            GuestsNumber = guestsNumber;
            ReservedDayNumber = reservedDayNumber;
            Status = AccommodationReservationStatus.Active;
        }

        public AccommodationReservation(int guestId, DateTime date, int accommodationId, int guestsNumber, int reservedDayNumber)
        {
            AccommodationGuestId = guestId;
            Date = date;
            AccommodationId = accommodationId;
            GuestsNumber = guestsNumber;
            ReservedDayNumber = reservedDayNumber;
            Status = AccommodationReservationStatus.Active;

        }

        public bool EqualsByAccommodationId(int accommodationId)
        {
            return AccommodationId == accommodationId;
        }

        public bool EqualsByGuestId(int accommodationGuestId)
        {
            return AccommodationGuestId == accommodationGuestId;
        }

        public bool Equals(int id)
        {
            return Id == id;
        }
    }
}
