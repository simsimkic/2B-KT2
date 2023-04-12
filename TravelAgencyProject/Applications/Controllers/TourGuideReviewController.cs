using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Controller
{
    public class TourGuideReviewController
    {
        private TourGuideReviewService tourGuideReviewService;


        public TourGuideReviewController()
        {
            tourGuideReviewService = new TourGuideReviewService();
        }
        public void Save(TourGuideReview tourGuideReview)
        {
            tourGuideReviewService.Save(tourGuideReview);
        }
        public List<TourGuideReviewDTO> GetAllDTOs()
        {
            List<TourGuideReview> tourGuideReviews = tourGuideReviewService.GetAll();

            return tourGuideReviews.Select(tgr => new TourGuideReviewDTO(tgr)).ToList();
        }

        public List<TourGuideReview> GetAll()
        {
            return tourGuideReviewService.GetAll();
        }

        public bool IsReviewed(int tourId, int tourGuestId)
        {
            return tourGuideReviewService.IsReviewed(tourId, tourGuestId);
        }
    }
}
