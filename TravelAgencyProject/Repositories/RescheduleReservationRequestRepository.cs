using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Resources.DBAcces;

namespace TravelAgencyProject.Repository
{
    public class RescheduleReservationRequestRepository
    {
        private RescheduleReservationRequestDataHandler rescheduleReservationRequestDataHandler;
        List<RescheduleReservationRequest> rescheduleReservationRequests;

        public RescheduleReservationRequestRepository()
        {
            rescheduleReservationRequestDataHandler = new RescheduleReservationRequestDataHandler();
            rescheduleReservationRequests = rescheduleReservationRequestDataHandler.GetAll().ToList();

        }

        public List<RescheduleReservationRequest> GetAll()
        {
            return rescheduleReservationRequests;
        }

        public List<RescheduleReservationRequest> GetByAccommodationGuestId(int accommodationGuestId)
        {
            List<RescheduleReservationRequest> filteredRequests = new List<RescheduleReservationRequest>();

            foreach(RescheduleReservationRequest rescheduleReservationRequest in rescheduleReservationRequests) 
            {
                if(rescheduleReservationRequest.Reservation.AccommodationGuestId == accommodationGuestId)
                {
                    filteredRequests.Add(rescheduleReservationRequest);
                }
            }

            return filteredRequests;
        }

        public void Save(RescheduleReservationRequest rescheduleReservationRequest)
        {
            rescheduleReservationRequests.Add(rescheduleReservationRequest);
            rescheduleReservationRequestDataHandler.SaveOneEntity(rescheduleReservationRequest);
        }

        public List<RescheduleReservationRequest> GetApprovedRequests(int accommodationGuestId)
        {
            List<RescheduleReservationRequest> filteredRequestsByAccommodationId = new List<RescheduleReservationRequest>();
            filteredRequestsByAccommodationId = GetByAccommodationGuestId(accommodationGuestId);

            List<RescheduleReservationRequest> finalFilteredRequests = new List<RescheduleReservationRequest>();


            foreach (RescheduleReservationRequest rescheduleReservationRequest in filteredRequestsByAccommodationId)
            {
                if (rescheduleReservationRequest.Status == RescheduleReservationStatus.Approved)
                {
                    finalFilteredRequests.Add(rescheduleReservationRequest);
                }
            }

            return finalFilteredRequests;

        }

        public void Update(RescheduleReservationRequest rescheduleReservationRequest)
        {
            rescheduleReservationRequestDataHandler.Update(rescheduleReservationRequest);
        }

        public RescheduleReservationRequest GetById(int id)
        {
            return rescheduleReservationRequests.FirstOrDefault(rescheduleReservationRequest => rescheduleReservationRequest.Id == id);
        }

        public List<RescheduleReservationRequest> GetByStatus(RescheduleReservationStatus status)
        {
            List<RescheduleReservationRequest> filteredRequests = new List<RescheduleReservationRequest>();

            foreach (RescheduleReservationRequest rescheduleReservationRequest in rescheduleReservationRequests)
            {
                if (rescheduleReservationRequest.Status.Equals(status))
                {
                    filteredRequests.Add(rescheduleReservationRequest);
                }
            }

            return filteredRequests;
        }
    }
}
