using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Interfaces.RepositoryInterfaces;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Resources.DBAcces;

namespace TravelAgencyProject.Repository
{
    public class TourArrangementRepository : ITourArrangementRepository
    {
        private List<TourArrangement> tourArrangements;
        private readonly IDataHandler<TourArrangement> tourArrangementDataHandler;
        
        public TourArrangementRepository()
        {
            tourArrangementDataHandler = new TourArrangementDataHandler();
            tourArrangements = tourArrangementDataHandler.GetAll().ToList();
        }

        public List<TourArrangement> GetAll()
        {
            return tourArrangements;
        }

        public TourArrangement GetById(int id)
        {
            return tourArrangements.FirstOrDefault(tourReservation => tourReservation.Id == id);
        }

        public TourArrangement GetByTourId(int tourId)
        {
            return tourArrangements.FirstOrDefault(tourArrangement => tourArrangement.TourId == tourId);
        }

        public List<TourArrangement> GetByTourGuideId(int tourGuideId)
        {
            return tourArrangements.Where(tourArrangement => tourArrangement.TourGuideId == tourGuideId).ToList();
        }
        public List<TourArrangement> GetByYear(string year)
        {
            return tourArrangements.Where(tourArrangement => tourArrangement.Tour.DateTime.Year == int.Parse(year)).ToList();
        }

        public TourArrangement Save(TourArrangement tourArrangement)
        {
            tourArrangements.Add(tourArrangement);
            return tourArrangementDataHandler.SaveOneEntity(tourArrangement);
        }

        public void Update(TourArrangement tourArrangement)
        {
            tourArrangementDataHandler.Update(tourArrangement);
        }

        public void Delete(TourArrangement tourArrangement)
        {
            tourArrangementDataHandler.Delete(tourArrangement);
        }

        public List<string> GetYearsFromTourDates()
        {
            return (from TourArrangement tour in this.GetByTourGuideId(UserSession.User.Id)
                    where tour.State.Equals(TourState.Finished)
                    select tour).Select(tourArrangement => tourArrangement.Tour.DateTime.Year.ToString()).Distinct().ToList();
        }
    }
}
