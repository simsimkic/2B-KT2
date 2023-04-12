using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Resources.DBAcces;

namespace TravelAgencyProject.Repository
{
    public class CheckPointRepository
    {
        private List<CheckPoint> checkPoints;
        private readonly IDataHandler<CheckPoint> checkPointDataHandler;

        public CheckPointRepository()
        {
            checkPointDataHandler = new CheckPointDataHandler();
            checkPoints = checkPointDataHandler.GetAll().ToList();
        }
        public List<CheckPoint> GetAll()
        {
            return checkPoints;
        }

        public CheckPoint GetById(int id)
        {
            return checkPoints.FirstOrDefault(checkPoint => checkPoint.Equals(id));
        }

        public List<CheckPoint> GetByTourId(int tourId)
        {
           List<CheckPoint> filteredCheckPoints = new List<CheckPoint> ();
           foreach(CheckPoint checkPoint in checkPoints)
            {
                if(checkPoint.TourId == tourId)
                {
                    filteredCheckPoints.Add(checkPoint);
                }
            }
            return filteredCheckPoints;
        }

        public CheckPoint Save(CheckPoint checkPoint)
        {

            checkPoints.Add(checkPoint);
            return checkPointDataHandler.SaveOneEntity(checkPoint);
        }

        public void Update(CheckPoint checkPoint)
        {
            checkPointDataHandler.Update(checkPoint);
        }
    }
}
