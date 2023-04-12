using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Resources.DBAcces;

namespace TravelAgencyProject.Repository
{
    public class AccommodationGuestReviewRepository
    {
        private List<AccommodationGuestReview> accommodationGuestReviews;
        private AccommodationGuestReviewDataHandler accommodationGuestReviewDataHandler;

        public AccommodationGuestReviewRepository()
        {
            accommodationGuestReviewDataHandler = new AccommodationGuestReviewDataHandler();
            accommodationGuestReviews = accommodationGuestReviewDataHandler.GetAll().ToList();
        }

        public void Save(AccommodationGuestReview accommodationGuestReview)
        {
            accommodationGuestReviews.Add(accommodationGuestReview);
            accommodationGuestReviewDataHandler.SaveOneEntity(accommodationGuestReview);
        }

        public List<AccommodationGuestReview> GetAll()
        {
            return accommodationGuestReviews;
        }

        public List<AccommodationGuestReview> GetByOwnerId(int ownerId)
        {
            List<AccommodationGuestReview> filteredAccommodationGuestReviews = new List<AccommodationGuestReview>();
            foreach (AccommodationGuestReview accommodationGuestReview in accommodationGuestReviews)
            {
                if (accommodationGuestReview.OwnerId == ownerId)
                    filteredAccommodationGuestReviews.Add(accommodationGuestReview);
            }
            return filteredAccommodationGuestReviews;
        }
        
    }
}
