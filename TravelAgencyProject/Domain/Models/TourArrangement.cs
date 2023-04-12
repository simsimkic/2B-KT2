using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{
    [Table("SeedTourArrangement")]
    public class TourArrangement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TourId { get; set; }

        [ForeignKey("TourId")]
        public virtual Tour Tour { get; set; }

        public int TourGuideId { get; set; }

        [ForeignKey("TourGuideId")]
        public virtual TourGuide TourGuide { get; set; }

        public virtual ICollection<TourAttendance> Attendances { get; set; }

        public int GuestsNumber { get; set; }

        public TourState State { get; set; }

        public TourArrangement() { }

        public TourArrangement(int tourGuestId, int tourId, Tour tour, int guestsNumber)
        {
            TourId = tourId;
            Tour = tour;
            GuestsNumber = guestsNumber;
        }

    }
}
