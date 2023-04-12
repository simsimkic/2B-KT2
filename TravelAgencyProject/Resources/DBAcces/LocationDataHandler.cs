using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;


namespace TravelAgencyProject.Resources.DBAcces
{
    public class LocationDataHandler : IDataHandler<Location>
    {
        private DataContext dataContext = new DataContext();
        public LocationDataHandler()
        {
        }

        public void Delete(Location entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetAll()
        {
            return dataContext.Locations.ToList();
        }

        public void Save(IEnumerable<Location> entities)
        {
            dataContext.Locations.AddRange(entities);

            dataContext.SaveChanges();
        }

        public Location SaveOneEntity(Location entity)
        {
            dataContext.Locations.Add(entity);

            dataContext.SaveChanges();

            return entity;
        }

        public void Update(Location entity)
        {
            throw new NotImplementedException();

        }


    }
}
