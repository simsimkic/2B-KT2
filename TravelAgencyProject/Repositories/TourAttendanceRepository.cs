using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Resources.DBAcces;

namespace TravelAgencyProject.Repository
{
    public class TourAttendanceRepository
    {
        private List<TourAttendance> tourAttendances;
        private readonly IDataHandler<TourAttendance> tourAttendanceDataHandler;

        public TourAttendanceRepository()
        {
            tourAttendanceDataHandler = new TourAttendanceDataHandler();
            tourAttendances = tourAttendanceDataHandler.GetAll().ToList();
        }
        public List<TourAttendance> GetAll()
        {
            return tourAttendances;
        }

        /*public SeedTourArrangement GetByTourId(int tourId)
        {
            SeedTourArrangement filteredTourArrangement = new SeedTourArrangement();

            foreach (SeedTourArrangement tourArrangement in tourArrangements)
            {
                if (tourArrangement.TourId == tourId)
                    return filteredTourArrangement;
            }

            return filteredTourArrangement;
        }*/

        public TourAttendance GetByTourGuestId(int tourGuestId)
        {
            TourAttendance filteredTourAttendance = new TourAttendance();

            foreach(TourAttendance tourAttendance in tourAttendances)
            {
                if (tourAttendance.GuestId == tourGuestId)
                    return filteredTourAttendance;
            }

            return filteredTourAttendance;
        }

        public void Update(TourAttendance tourAttendance)
        {
            tourAttendanceDataHandler.Update(tourAttendance);
        }

        public TourAttendance Save(TourAttendance tourAttendance)
        {
            tourAttendances.Add(tourAttendance);
            return tourAttendanceDataHandler.SaveOneEntity(tourAttendance);
        }
    }
}
