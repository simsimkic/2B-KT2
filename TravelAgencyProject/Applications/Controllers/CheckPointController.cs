using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Applications.Controller
{
    public class CheckPointController
    {
        private CheckPointService checkPointService = new CheckPointService();


        public List<CheckPoint> GetByTourId(int TourId)
        {
            return checkPointService.GetByTourId(TourId);
        }

        public void Save(CheckPoint checkPoint)
        {
            checkPointService.Save(checkPoint);
        }

        public void Update(CheckPoint checkPoint)
        {
            checkPointService.Update(checkPoint);
        }
    }
}
