using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Applications.DTOs
{
    public class TourGuestStatisticsDTO
    {
        public int AgeUnder18 { get; set; }

        public int AgeBetween18And50 { get; set; }

        public int AgeOver50 { get; set; }

        public string WithVouchers { get; set; }

        public string WithoutVouchers { get; set; }

        public TourGuestStatisticsDTO()
        {
            AgeUnder18 = 0;
            AgeBetween18And50 = 0;
            AgeOver50 = 0;
            WithVouchers = "";
            WithoutVouchers = "";
        }
    }
}
