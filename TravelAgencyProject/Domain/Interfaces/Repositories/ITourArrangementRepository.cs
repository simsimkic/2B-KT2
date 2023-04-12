using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Domain.Interfaces.RepositoryInterfaces
{
    public interface ITourArrangementRepository
    {
        public List<TourArrangement> GetAll();

        public TourArrangement GetById(int id);

        public TourArrangement GetByTourId(int tourId);

        public List<TourArrangement> GetByTourGuideId(int tourGuideId);
        public List<TourArrangement> GetByYear(string year);

        public TourArrangement Save(TourArrangement tourArrangement);

        public void Update(TourArrangement tourArrangement);

        public void Delete(TourArrangement tourArrangement);

        public List<string> GetYearsFromTourDates();
    }
}
