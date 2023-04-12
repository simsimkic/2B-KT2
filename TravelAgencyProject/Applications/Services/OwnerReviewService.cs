using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Services
{
    public class OwnerReviewService
    {
        private OwnerReviewRepository ownerReviewRepository;
        public OwnerReviewService()
        {
            ownerReviewRepository = new OwnerReviewRepository();
        }

        public void Create(int ownerId, int accommodationId, int guestId, int cleanness, int ownerFairness, string comment, string images)
        {
            ownerReviewRepository.Save(new OwnerReview(cleanness, ownerFairness, comment, ownerId, accommodationId, guestId, images));
        }


        public List<OwnerReview> GetAll()
        {
            return ownerReviewRepository.GetAll();
        }

        public List<OwnerReview> GetByOwnerId(int ownerId)
        {
            return ownerReviewRepository.GetByOwnerId(ownerId);
        }
    }
}
