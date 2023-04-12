using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Resources.DBAcces
{
    public class TourArrangementDataHandler : SqliteException, IDataHandler<TourArrangement>
    {
        private DataContext dataContext = new DataContext();

        public TourArrangementDataHandler(string? message = "", int errorCode = 0) : base(message, errorCode) { }



        public IEnumerable<TourArrangement> GetAll()
        {
            return dataContext.TourArrangements.ToList();
        }

        public void Save(IEnumerable<TourArrangement> entities)
        {
            dataContext.TourArrangements.AddRange(entities);

            dataContext.SaveChanges();
        }

        public TourArrangement SaveOneEntity(TourArrangement entity)
        {
            dataContext.TourArrangements.Add(entity);

            dataContext.SaveChanges();

            return entity;
        }

        public void Update(TourArrangement entity)
        {
            var existingTourArrangement = dataContext.TourArrangements.FirstOrDefault(tourArrangement => tourArrangement.Id == entity.Id);

            if (existingTourArrangement != null)
            {
                existingTourArrangement = entity;

                dataContext.SaveChanges();
            }
        }

        public void Delete(TourArrangement entity)
        {
            dataContext.TourArrangements.Remove(entity);

            dataContext.SaveChanges();
        }
    }
}
