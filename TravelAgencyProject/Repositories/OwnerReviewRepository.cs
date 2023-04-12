using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Resources.DBAcces;
using TravelAgencyProject.Applications.Util;

namespace TravelAgencyProject.Repository
{
    public class OwnerReviewRepository
    {
        private List<OwnerReview> reviews;
        private IDataHandler<OwnerReview> ownerReviewDataHandler;
        public OwnerReviewRepository()
        {
            ownerReviewDataHandler = new OwnerReviewDataHandler();
            reviews = ownerReviewDataHandler.GetAll().ToList();
        }

        public void Save(OwnerReview review)
        {
            reviews.Add(review);
            ownerReviewDataHandler.SaveOneEntity(review);
        }

        public List<OwnerReview> GetAll()
        {
            return reviews;
        }

        public List<OwnerReview> GetByOwnerId(int ownerId)
        {
            List<OwnerReview> filteredOwnerReviews = new List<OwnerReview>();
            foreach (OwnerReview ownerReview in reviews)
            {
                if (ownerReview.OwnerId == ownerId)
                    filteredOwnerReviews.Add(ownerReview);
            }
            return filteredOwnerReviews;
        }
    }
}
