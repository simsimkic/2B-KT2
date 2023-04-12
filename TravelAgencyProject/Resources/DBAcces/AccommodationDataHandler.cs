using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Resources.DBAcces
{
    public class AccommodationDataHandler : IDataHandler<Accommodation>
    {
        private DataContext dataContext = new DataContext();

        public void Delete(Accommodation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Accommodation> GetAll()
        {
            return dataContext.Accommodations.ToList();

        }

        public void Save(IEnumerable<Accommodation> entities)
        {
            dataContext.Accommodations.AddRange(entities);

            dataContext.SaveChanges();
        }

        public Accommodation SaveOneEntity(Accommodation entity)
        {
            dataContext.Accommodations.Add(entity);

            dataContext.SaveChanges();

            return entity;
        }

        public void Update(Accommodation entity)
        {
            throw new NotImplementedException();
        }
    }
}
