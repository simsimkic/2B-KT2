using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Resources.DBAcces
{
    public class TourAttendanceDataHandler : IDataHandler<TourAttendance>
    {
        private DataContext dataContext = new DataContext();

        public void Delete(TourAttendance entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TourAttendance> GetAll()
        {
            return dataContext.TourAttendances.ToList();
        }

        public void Save(IEnumerable<TourAttendance> entities)
        {
            dataContext.TourAttendances.AddRange(entities);

            dataContext.SaveChanges();
        }

        public TourAttendance SaveOneEntity(TourAttendance entity)
        {
            dataContext.TourAttendances.Add(entity);

            dataContext.SaveChanges();

            return entity;
        }

        public void Update(TourAttendance entity)
        {
            var existingTourAttendance = dataContext.TourAttendances.FirstOrDefault(tourAttendance
                => tourAttendance.GuestId == entity.GuestId && tourAttendance.TourArrangementId == entity.TourArrangementId);

            if (existingTourAttendance != null)
            {
                existingTourAttendance.CheckPointCoordinate = entity.CheckPointCoordinate;
                existingTourAttendance.IsPresent = entity.IsPresent;
                existingTourAttendance.IsConfirmed = entity.IsConfirmed;
                dataContext.SaveChanges();
            }
        }
    }
}
