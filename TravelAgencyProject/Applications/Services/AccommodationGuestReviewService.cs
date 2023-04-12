using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Services
{
    public class AccommodationGuestReviewService
    {
        private AccommodationGuestReviewRepository accommodationGuestReviewRepository;

        public AccommodationGuestReviewService()
        {
            accommodationGuestReviewRepository = new AccommodationGuestReviewRepository();
        }

        public void Save(AccommodationGuestReview accommodationGuestReview)
        {
            accommodationGuestReviewRepository.Save(accommodationGuestReview);
        }


        public List<AccommodationGuestReview> GetAll()
        {
            return accommodationGuestReviewRepository.GetAll();
        }



        public bool IsReviewed(int ownerId, int accommodationGuestId)
        {
            List<AccommodationGuestReview> accommodationGuestReviews = GetAll();
            foreach (AccommodationGuestReview accommodationGuestReview in accommodationGuestReviews)
            {
                if (accommodationGuestReview.OwnerId == ownerId && accommodationGuestReview.AccommodationGuestId == accommodationGuestId)
                    return true;
            }
            return false;
        }



        public List<AccommodationGuestReview> GetByOwnerId(int ownerId)
        {
            return accommodationGuestReviewRepository.GetByOwnerId(ownerId);
        }
    }
}
