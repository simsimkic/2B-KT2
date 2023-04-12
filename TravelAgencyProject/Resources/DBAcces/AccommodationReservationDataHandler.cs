using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Resources.DBAcces
{
    public class AccommodationReservationDataHandler : IDataHandler<AccommodationReservation>
    {
        private DataContext dataContext = new DataContext();

        public AccommodationReservationDataHandler()
        {
        }

        public void Delete(AccommodationReservation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccommodationReservation> GetAll()
        {
            return dataContext.AccommodationReservations.ToList();
        }

        public void Save(IEnumerable<AccommodationReservation> entities)
        {
            dataContext.AccommodationReservations.AddRange(entities);

            dataContext.SaveChanges();
        }

        public AccommodationReservation SaveOneEntity(AccommodationReservation entity)
        {
            dataContext.AccommodationReservations.Add(entity);
            dataContext.SaveChanges();
            return entity;
        }

        public void Update(AccommodationReservation entity)
        {
            var existingAccommodationReservation = dataContext.AccommodationReservations.FirstOrDefault(accommodationReservation => accommodationReservation.Id == entity.Id);

            if (existingAccommodationReservation != null)
            {
                existingAccommodationReservation.Status = entity.Status;

                dataContext.SaveChanges();
            }
        }

    }
}
