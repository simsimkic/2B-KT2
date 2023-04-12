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
    [Table("YearlyAccommodationStatistic")]
    public class YearlyAccommodationStatistic
    {

        [Key]
        public int Id { get; set; }

        public int AccommodationId { get; set; }
        [ForeignKey("AccommodationId")]
        public virtual Accommodation Accommodation { get; set; }
        public int Year { get; set; }

        public int ReservationNumber { get; set; }

        public int CanceledReservations { get; set; }

        public int RescheduledReservations { get; set; }

        public int RenovationRecommendations { get; set; }

        public string Images { get; set; }

        public int busyness { get; set; }

        public YearlyAccommodationStatistic(int id, Accommodation accommodation, int year, int reservationNumber, int canceledReservations, int rescheduledReservations, int renovationRecommendations, string images, int busyness)
        {
            Id = id;
            Accommodation = accommodation;
            Year = year;
            ReservationNumber = reservationNumber;
            CanceledReservations = canceledReservations;
            RescheduledReservations = rescheduledReservations;
            RenovationRecommendations = renovationRecommendations;
            Images = images;
            this.busyness = busyness;
        }

        public YearlyAccommodationStatistic()
        {
        }
    }

}
