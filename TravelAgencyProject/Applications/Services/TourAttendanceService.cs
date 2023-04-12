using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Services
{
    public class TourAttendanceService
    {
        private TourAttendanceRepository tourAttendanceRepository = new TourAttendanceRepository();

        public void ChangeCheckPointCoordinate(TourAttendance tourAttendance)
        {
            tourAttendanceRepository.Update(tourAttendance);
        }





        public List<TourAttendance> GetAttendancesFromFinishedTours(int guestId)
        {
            List<TourAttendance> tourAttendances = tourAttendanceRepository.GetAll();
            List<TourAttendance> tourAttendancesFromFinishedTours = new List<TourAttendance>();

            foreach (TourAttendance tourAttendance in tourAttendances)
            {
                if (tourAttendance.TourArrangement.State.Equals(TourState.Finished) && tourAttendance.GuestId == guestId)
                    tourAttendancesFromFinishedTours.Add(tourAttendance);
            }


            return tourAttendancesFromFinishedTours;
        }

        public List<TourAttendance> GetAttendancesFromStartedTours(int guestId)
        {
            List<TourAttendance> tourAttendances = tourAttendanceRepository.GetAll();
            List<TourAttendance> tourAttendancesFromStartedTours = new List<TourAttendance>();

            foreach (TourAttendance tourAttendance in tourAttendances)
            {
                if (tourAttendance.TourArrangement.State.Equals(TourState.Started) && tourAttendance.GuestId == guestId)
                    tourAttendancesFromStartedTours.Add(tourAttendance);
            }


            return tourAttendancesFromStartedTours;
        }
    }
}
