using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Resources.DBAcces
{
    public class TourGuideReviewDataHandler : IDataHandler<TourGuideReview>
    {
        DataContext dataContext = new DataContext();

        public void Delete(TourGuideReview entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TourGuideReview> GetAll()
        {
            return dataContext.TourGuideReviews.ToList();
        }

        public void Save(IEnumerable<TourGuideReview> entities)
        {
            dataContext.TourGuideReviews.AddRange(entities);

            dataContext.SaveChanges();
        }

        public TourGuideReview SaveOneEntity(TourGuideReview entity)
        {
            dataContext.TourGuideReviews.Add(entity);

            dataContext.SaveChanges();

            return entity;
        }

        public void Update(TourGuideReview entity)
        {
            throw new NotImplementedException();

        }
    }
}
