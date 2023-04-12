using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{
    public class MonthlyAccommodationStatistics : YearlyAccommodationStatistic
    {

        public int Month { get; set; }
        public MonthlyAccommodationStatistics(int id, Accommodation accommodatioId, int year, int reservationNumber, int canceledReservations, int rescheduledReservations, int renovationRecommendations, string images, int busyness, int month) : base(id, accommodatioId, year, reservationNumber, canceledReservations, rescheduledReservations, renovationRecommendations, images, busyness)
        {
            Month = month;
        }

        public MonthlyAccommodationStatistics()
        {
        }
    }
}
