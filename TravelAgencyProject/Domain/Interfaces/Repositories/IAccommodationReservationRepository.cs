using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Domain.Interfaces.Repositories
{
    public interface IAccommodationReservationRepository
    {
        public AccommodationReservation GetById(int id);
        public List<AccommodationReservation> GetAll();
        public List<AccommodationReservation> GetByGuestId(int guestId);
        public List<AccommodationReservation> GetByAccommodationId(int accommodationId);
        public void Save(AccommodationReservation accommodationReservation);
        public void Update(AccommodationReservation accommodationReservation);
    }
}
