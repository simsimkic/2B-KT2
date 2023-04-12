using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{
    [Table("SeedTourAttendance")]
    public class TourAttendance
    {
        [Key, Column(Order = 0)]
        public int TourArrangementId { get; set; }

        [Key, Column(Order = 1)]
        public int GuestId { get; set; }

        [ForeignKey("GuestId")]
        public virtual TourGuest TourGuest { get; set; }

        [ForeignKey("TourArrangementId")]
        public virtual TourArrangement TourArrangement { get; set; }

        public string CheckPointCoordinate { get; set; }
        public bool IsPresent { get; set; }

        public bool IsConfirmed { get; set; }

        public TourAttendance(int tourGuestId, int tourArrangementId, string checkPointCoordinate)
        {
            GuestId = tourGuestId;
            TourArrangementId = tourArrangementId;
            CheckPointCoordinate = checkPointCoordinate;
            IsPresent = false;
            IsConfirmed = false;
        }

        public TourAttendance() { }
    }
}
