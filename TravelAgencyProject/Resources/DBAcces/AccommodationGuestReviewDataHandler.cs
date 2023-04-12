using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Resources.DBAcces
{
    public class AccommodationGuestReviewDataHandler : IDataHandler<AccommodationGuestReview>
    {
        DataContext dataContext = new DataContext();

        public void Delete(AccommodationGuestReview entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccommodationGuestReview> GetAll()
        {
            return dataContext.AccommodationGuestReviews.ToList();
        }

        public void Save(IEnumerable<AccommodationGuestReview> entities)
        {
            dataContext.AccommodationGuestReviews.AddRange(entities);

            dataContext.SaveChanges();
        }

        public AccommodationGuestReview SaveOneEntity(AccommodationGuestReview entity)
        {
            dataContext.AccommodationGuestReviews.Add(entity);

            dataContext.SaveChanges();

            return entity;
        }

        public void Update(AccommodationGuestReview entity)
        {
            throw new NotImplementedException();

        }
    }
}
