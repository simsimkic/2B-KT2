using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Resources.DBAcces
{

    public class CheckPointDataHandler : IDataHandler<CheckPoint>
    {
        private DataContext dataContext = new DataContext();

        public void Delete(CheckPoint entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CheckPoint> GetAll()
        {
            return dataContext.CheckPoints.ToList();
        }

        public void Save(IEnumerable<CheckPoint> entities)
        {
            dataContext.CheckPoints.AddRange(entities);

            dataContext.SaveChanges();
        }

        public CheckPoint SaveOneEntity(CheckPoint entity)
        {
            dataContext.CheckPoints.Add(entity);

            dataContext.SaveChanges();

            return entity;
        }

        public void Update(CheckPoint entity)
        {
            var existingCheckPoint = dataContext.CheckPoints.FirstOrDefault(checkPoint => checkPoint.Id == entity.Id);

            if (existingCheckPoint != null)
            {
                existingCheckPoint.IsTagged = entity.IsTagged;

                dataContext.SaveChanges();
            }
        }
    }
}
