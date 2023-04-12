using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Applications.Controller
{
    public class OwnerReviewController
    {

        private OwnerReviewService ownerReviewService;
        public OwnerReviewController()
        {
            ownerReviewService = new OwnerReviewService();
        }

        public void Create(int ownerId, int accommodationId, int guestId, int cleanness, int ownerFairness, string comment, string images)
        {
            ownerReviewService.Create(ownerId, accommodationId, guestId, cleanness, ownerFairness, comment, images);
        }

        public List<OwnerReview> GetAll()
        {
            return ownerReviewService.GetAll();
        }

        public List<OwnerReview> GetByOwnerId(int ownerId)
        {
            return ownerReviewService.GetByOwnerId(ownerId);
        }
    }
}
