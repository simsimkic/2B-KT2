using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Services
{
    public class CheckPointService
    {
        private CheckPointRepository checkPointRepository = new CheckPointRepository();

        public List<CheckPoint> GetByTourId(int tourId)
        {
            return checkPointRepository.GetByTourId(tourId);
        }

        public void Save(CheckPoint checkPoint)
        {
            checkPointRepository.Save(checkPoint);
        }

        public void Update(CheckPoint checkPoint)
        {
            checkPointRepository.Update(checkPoint);
        }
    }
}
