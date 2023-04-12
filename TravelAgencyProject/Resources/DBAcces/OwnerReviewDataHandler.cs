using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Resources.DBAcces
{
    public class OwnerReviewDataHandler : IDataHandler<OwnerReview>
    {
        DataContext dataContext = new DataContext();

        public void Delete(OwnerReview entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OwnerReview> GetAll()
        {
            return dataContext.OwnerReviews.ToList();
        }

        public void Save(IEnumerable<OwnerReview> entities)
        {
            dataContext.OwnerReviews.AddRange(entities);

            dataContext.SaveChanges();
        }

        public OwnerReview SaveOneEntity(OwnerReview entity)
        {
            dataContext.OwnerReviews.Add(entity);

            dataContext.SaveChanges();

            return entity;
        }

        public void Update(OwnerReview entity)
        {
            var existingOwnerReviews = dataContext.OwnerReviews.FirstOrDefault(ownerReview => ownerReview.Id == entity.Id);

            if (existingOwnerReviews != null)
            {
                existingOwnerReviews = entity;

                dataContext.SaveChanges();
            }
        }
    }
}
