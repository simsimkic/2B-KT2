using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Controller
{
    public class AccommodationGuestReviewController
    {
        private AccommodationGuestReviewService accommodationGuestReviewService;


        public AccommodationGuestReviewController()
        {
            accommodationGuestReviewService = new AccommodationGuestReviewService();
        }
        public void Save(AccommodationGuestReview accommodationGuestReview)
        {
            accommodationGuestReviewService.Save(accommodationGuestReview);
        }

        public List<AccommodationGuestReview> GetAll()
        {
            return accommodationGuestReviewService.GetAll();
        }

        public List<AccommodationGuestReview> GetByOwnerId(int ownerId)
        {
            return accommodationGuestReviewService.GetByOwnerId(ownerId);
        }
    }
}
