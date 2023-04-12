using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Applications.DTOs
{
    public class TourGuideReviewDTO
    {
        public string TourName { get; set; }
        public string GuestUsername { get; set; }
        public double AverageGrade { get; set; }
        public string Comment { get; set; }
        public string Images { get; set; }
        public string CheckPointCoordinate { get; set; }

        public TourGuideReviewDTO(TourGuideReview tourGuideReview)
        {
            TourName = tourGuideReview.TourAttendance.TourArrangement.Tour.Name;
            GuestUsername = tourGuideReview.TourAttendance.TourGuest.Username + " on " + TourName;
            AverageGrade = (tourGuideReview.Knowledge + tourGuideReview.Language + tourGuideReview.Interestingness) / 3;
            Comment = tourGuideReview.Comment;
            Images = tourGuideReview.Images;
            CheckPointCoordinate = tourGuideReview.TourAttendance.CheckPointCoordinate;
        }
    }
}
