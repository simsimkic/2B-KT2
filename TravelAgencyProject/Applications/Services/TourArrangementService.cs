using System;
using System.Collections.Generic;
using TravelAgencyProject.Repository;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Interfaces.RepositoryInterfaces;
using TravelAgencyProject.Domain.Interfaces.Services;

namespace TravelAgencyProject.Applications.Services
{
    public class TourArrangementService : ITourArrangementService
    {
        private readonly ITourArrangementRepository _tourArrangementRepository;

        private readonly VoucherRepository voucherRepository;


        public TourArrangementService(ITourArrangementRepository tourArrangementRepository)
        {
            _tourArrangementRepository = tourArrangementRepository;
            voucherRepository = new VoucherRepository();

        }

        public List<TourArrangement> GetAll()
        {
            return _tourArrangementRepository.GetAll();
        }

        public TourArrangement GetById(int id)
        {
            return _tourArrangementRepository.GetById(id);
        }

        public void Update(TourArrangement tourArrangement)
        {
            _tourArrangementRepository.Update(tourArrangement);
        }

        public List<TourArrangement> GetAllTodaysTour()
        {
            var todaysTourArangements = _tourArrangementRepository.GetAll().Where(tourArrangement => tourArrangement.Tour.DateTime.Date.Equals(DateTime.Today)).ToList();
            return todaysTourArangements;
        }

        public List<TourArrangement> GetFinishedTours()
        {
            var finishedTours = _tourArrangementRepository.GetAll().Where(tourArrangement => tourArrangement.State.Equals(TourState.Finished)).ToList();

            return finishedTours;
        }

        public void CancelTour(TourArrangement tourArrangement)
        {
            foreach (var tourAttendance in tourArrangement.Attendances)
            {
                string name = "Voucher for " + tourArrangement.Tour.Name;
                Voucher voucher = new Voucher(name, DateTime.Now.AddYears(1), tourAttendance.GuestId, 1);
                voucherRepository.Save(voucher);
            }

            _tourArrangementRepository.Delete(tourArrangement);  
        }

    }
}
