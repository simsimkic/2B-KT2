using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Domain.Interfaces.Services
{
    public interface ITourArrangementStatisticsService
    {
        public TourArrangement GetMostVisitedTour(string chosenYear);

        public List<string> GetYearsFromTourDates();

        public TourGuestStatisticsDTO GetTourGuestStatistics(int tourArrangementId);
    }
}
