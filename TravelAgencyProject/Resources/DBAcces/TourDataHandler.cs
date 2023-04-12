using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;


namespace TravelAgencyProject.Resources.DBAcces
{
    public class TourDataHandler : IDataHandler<Tour>
    {
        private DataContext dataContext = new DataContext();

        public void Delete(Tour entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tour> GetAll()
        {
            return dataContext.Tours.ToList();
        }


        public void Save(IEnumerable<Tour> entities)
        {
            dataContext.Tours.AddRange(entities);

            dataContext.SaveChanges();
        }

        public Tour SaveOneEntity(Tour entity)
        {
            dataContext.Tours.Add(entity);

            dataContext.SaveChanges();

            return entity;
        }

        public void Update(Tour entity)
        {
            throw new NotImplementedException();

        }

    }
}
