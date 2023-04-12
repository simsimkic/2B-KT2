using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Domain.Interfaces.Services
{
    public interface ITourArrangementService
    {
        public List<TourArrangement> GetAll();

        public TourArrangement GetById(int id);

        public void Update(TourArrangement tourArrangement);

        public List<TourArrangement> GetAllTodaysTour();

        public List<TourArrangement> GetFinishedTours();

        public void CancelTour(TourArrangement tourArrangement);


    }
}
