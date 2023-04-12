using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Controller
{
    public class TourAttendanceController
    {

        private TourAttendanceService tourAttendanceService = new TourAttendanceService();

        public void ChangeCheckPointCoordinate(TourAttendance tourAttendance)
        {
            tourAttendanceService.ChangeCheckPointCoordinate(tourAttendance);
        }



        public List<TourAttendance> GetAttendancesFromFinishedTours(int guestId)
        {
            return tourAttendanceService.GetAttendancesFromFinishedTours(guestId);
        }

        public List<TourAttendance> GetAttendancesFromStartedTours(int guestId)
        {
            return tourAttendanceService.GetAttendancesFromStartedTours(guestId);
        }


    }
}
