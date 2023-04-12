using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Interfaces.RepositoryInterfaces;
using TravelAgencyProject.Domain.Interfaces.Services;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Services
{
    public class TourArrangementStatisticsService : ITourArrangementStatisticsService
    {
        private readonly ITourArrangementRepository _tourArrangementRepository;

        private readonly VoucherRepository voucherRepository;

        public TourArrangementStatisticsService(ITourArrangementRepository tourArrangementRepository)
        {
            _tourArrangementRepository = tourArrangementRepository;
            voucherRepository = new VoucherRepository();
        }

        public TourArrangement GetMostVisitedTour(string chosenYear)
        {
            List<TourArrangement> chosenTours = new List<TourArrangement>();

            if (chosenYear.Equals("All time"))
            {
                chosenTours = (from TourArrangement tour in _tourArrangementRepository.GetByTourGuideId(UserSession.User.Id)
                               where tour.State.Equals(TourState.Finished)
                               select tour).ToList();
            }
            else
            {
                chosenTours = (from TourArrangement tour in _tourArrangementRepository.GetByYear(chosenYear)
                               where tour.State.Equals(TourState.Finished)
                               select tour).ToList();
            }

            return chosenTours.OrderByDescending(tourArrangement => tourArrangement.GuestsNumber).FirstOrDefault(tour => tour.TourGuideId == UserSession.User.Id);
        }

        public List<string> GetYearsFromTourDates()
        {
            return _tourArrangementRepository.GetYearsFromTourDates();
        }

        public TourGuestStatisticsDTO GetTourGuestStatistics(int tourArrangementId)
        {
            TourArrangement tourArrangement = _tourArrangementRepository.GetById(tourArrangementId);

            TourGuestStatisticsDTO tourGuestStatisticsDTO = new TourGuestStatisticsDTO();

            AgeGroups(tourArrangement, tourGuestStatisticsDTO);

            CountVouchers(tourArrangementId, tourArrangement, tourGuestStatisticsDTO);

            return tourGuestStatisticsDTO;
        }

        private void CountVouchers(int tourArrangementId, TourArrangement tourArrangement, TourGuestStatisticsDTO tourGuestStatisticsDTO)
        {
            double voucherNumber = voucherRepository.GetByTourId(tourArrangementId).ToList().Count;
            int totalAttendancesNumber = tourArrangement.Attendances.Count;

            tourGuestStatisticsDTO.WithVouchers = Math.Round(voucherNumber / totalAttendancesNumber * 100, 2).ToString() + " %";
            tourGuestStatisticsDTO.WithoutVouchers = Math.Round((totalAttendancesNumber - voucherNumber) / totalAttendancesNumber * 100).ToString() + " %";
        }

        private void AgeGroups(TourArrangement tourArrangement, TourGuestStatisticsDTO tourGuestStatisticsDTO)
        {
            foreach (var tourAttendance in tourArrangement.Attendances)
            {
                if (tourAttendance.TourGuest.Age < 18)
                {
                    tourGuestStatisticsDTO.AgeUnder18++;
                }
                else if (tourAttendance.TourGuest.Age >= 18 && tourAttendance.TourGuest.Age <= 50)
                {
                    tourGuestStatisticsDTO.AgeBetween18And50++;
                }
                else
                {
                    tourGuestStatisticsDTO.AgeOver50++;
                }
            }
        }
    }
}
