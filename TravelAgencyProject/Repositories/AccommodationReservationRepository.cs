using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelAgencyProject.Domain.Interfaces.Repositories;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Resources.DBAcces;

namespace TravelAgencyProject.Repository
{
    public class AccommodationReservationRepository : IAccommodationReservationRepository
    {
        private List<AccommodationReservation> accommodationReservations;
        private readonly IDataHandler<AccommodationReservation> accommodationReservationDataHandler;

        public AccommodationReservationRepository()
        {
            accommodationReservationDataHandler = new AccommodationReservationDataHandler();
            accommodationReservations = accommodationReservationDataHandler.GetAll().ToList();

            for(int i = 0; i < accommodationReservations.Count; i++)
            {
                if (accommodationReservations[i].Status == AccommodationReservationStatus.Canceled)
                {
                    accommodationReservations.Remove(accommodationReservations[i]);
                }
            }
        }

        public AccommodationReservation GetById(int id)
        {
            return accommodationReservations.FirstOrDefault(accommodationReservation => accommodationReservation.Equals(id));

        }

        public List<AccommodationReservation> GetAll()
        {
            accommodationReservations = accommodationReservationDataHandler.GetAll().ToList();

            for (int i = 0; i < accommodationReservations.Count; i++)
            {
                if (accommodationReservations[i].Status == AccommodationReservationStatus.Canceled)
                {
                    accommodationReservations.Remove(accommodationReservations[i]);
                }
            }

            return accommodationReservations;
        }

        public List<AccommodationReservation> GetByGuestId(int guestId)
        {
            accommodationReservations = GetAll();
            List<AccommodationReservation> filteredReservations = new List<AccommodationReservation>();
            foreach (AccommodationReservation reservation in accommodationReservations)
            {
                if (reservation.AccommodationGuestId == guestId)
                    filteredReservations.Add(reservation);
            }
            return filteredReservations;
        }         

        public List<AccommodationReservation> GetByAccommodationId(int accommodationId)
        {
            List<AccommodationReservation> filteredReservations = new List<AccommodationReservation>();
            foreach (AccommodationReservation reservation in accommodationReservations)
            {
                if(reservation.AccommodationId == accommodationId)
                    filteredReservations.Add(reservation);
            }
            return filteredReservations;
        }

        public void Save(AccommodationReservation accommodationReservation)
        {
            accommodationReservations.Add(accommodationReservation);
            accommodationReservationDataHandler.SaveOneEntity(accommodationReservation);
        }

        public void Update(AccommodationReservation accommodationReservation)
        {
            accommodationReservationDataHandler.Update(accommodationReservation);
        }
    }
}
