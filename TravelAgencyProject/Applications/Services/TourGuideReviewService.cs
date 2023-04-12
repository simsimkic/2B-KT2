using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Services
{
    public class TourGuideReviewService
    {
        private TourGuideReviewRepository tourGuideReviewRepository;

        public TourGuideReviewService()
        {
            tourGuideReviewRepository = new TourGuideReviewRepository();
        }
        public void Save(TourGuideReview tourGuideReview)
        {
            tourGuideReviewRepository.Save(tourGuideReview);
        }
        public List<TourGuideReview> GetAll()
        {
            return tourGuideReviewRepository.GetAll();
        }

        public bool IsReviewed(int tourId, int tourGuestId)
        {
            List<TourGuideReview> tourGuideReviews = GetAll();
            foreach (TourGuideReview tourGuideReview in tourGuideReviews)
            {
                if (tourGuideReview.TourAttendance.GuestId == tourGuestId && tourGuideReview.TourAttendance.TourArrangement.TourId == tourId)
                    return true;
            }
            return false;
        }
    }
}
