using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Resources.DBAcces;

namespace TravelAgencyProject.Repository
{
    public class TourGuideReviewRepository
    {
        private List<TourGuideReview> tourGuideReviews;
        private readonly IDataHandler<TourGuideReview> tourGuideReviewDataHandler;

        public TourGuideReviewRepository()
        {
            tourGuideReviewDataHandler = new TourGuideReviewDataHandler();
            tourGuideReviews = tourGuideReviewDataHandler.GetAll().ToList();
        }

        public void Save(TourGuideReview tourGuideReview)
        {
            tourGuideReviews.Add(tourGuideReview);
            tourGuideReviewDataHandler.SaveOneEntity(tourGuideReview);
        }

        public List<TourGuideReview> GetAll()
        {
            return tourGuideReviews;
        }

    }
}
