using System.Collections.Generic;
using System.Linq;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Interfaces.RepositoryInterfaces;
using TravelAgencyProject.Domain.Interfaces.Services;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Services
{
    public class TourArrangementCreationService : ITourArrangementCreationService
    {
        private readonly ITourArrangementRepository _tourArrangementRepository;
        private TourService tourService;

        public TourArrangementCreationService(ITourArrangementRepository tourArrangementRepository)
        {
            tourService = new TourService();
            _tourArrangementRepository = tourArrangementRepository;
        }


        public int CreateArrangement(TourReservationDTO tourReservationDTO)
        {
            int tourId = tourReservationDTO.TourId;
            int tourGuestsNumber = tourReservationDTO.TourGuestsNumber;


            List<TourArrangement> tourReservations = _tourArrangementRepository.GetAll();

            TourArrangement tourArrangement = tourReservations.Find(r => r.TourId == tourId);


            if (IsAvailable(tourId, tourGuestsNumber))
            {
                TourAttendance tourAttendance = new TourAttendance(UserSession.User.Id, tourArrangement.Id, "");

                tourArrangement.GuestsNumber += tourGuestsNumber;
                tourArrangement.Attendances.Add(tourAttendance);
                _tourArrangementRepository.Update(tourArrangement);
                return tourService.GetById(tourId).MaxGuestNumber - tourArrangement.GuestsNumber;
            }

            return -1;
        }

        public bool IsAvailable(int tourId, int tourGuestsNumber)
        {
            return tourService.GetById(tourId).MaxGuestNumber >= _tourArrangementRepository.GetByTourId(tourId).GuestsNumber + tourGuestsNumber;
        }

        public bool IsUserAlreadyAssigned(int tourGuestId, int tourId)
        {
            TourArrangement tourReservation = _tourArrangementRepository.GetByTourId(tourId);

            foreach (TourAttendance tourAttendance in tourReservation.Attendances.ToList())
            {
                if (tourAttendance.GuestId == tourGuestId)
                {
                    return true;
                }
            }

            return false;

        }
    }
}