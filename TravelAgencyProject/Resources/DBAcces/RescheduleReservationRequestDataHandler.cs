using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Resources.DBAcces
{
    public class RescheduleReservationRequestDataHandler : IDataHandler<RescheduleReservationRequest>
    {
        private DataContext dataContext = new DataContext();
        public RescheduleReservationRequestDataHandler()
        {
        }

        public IEnumerable<RescheduleReservationRequest> GetAll()
        {
            return dataContext.RescheduleReservationRequests.ToList();
        }

        public void Save(IEnumerable<RescheduleReservationRequest> entities)
        {
            dataContext.RescheduleReservationRequests.AddRange(entities);

            dataContext.SaveChanges();
        }

        public RescheduleReservationRequest SaveOneEntity(RescheduleReservationRequest entity)
        {
            dataContext.RescheduleReservationRequests.Add(entity);

            dataContext.SaveChanges();

            return entity;
        }

        public void Delete(RescheduleReservationRequest entity)
        {
            throw new NotImplementedException();
        }

        public void Update(RescheduleReservationRequest entity)
        {
            var existingRescheduleReservationRequest = dataContext.RescheduleReservationRequests.FirstOrDefault(rescheduleReservationRequest => rescheduleReservationRequest.Id == entity.Id);

            if (existingRescheduleReservationRequest != null)
            {
                existingRescheduleReservationRequest = entity;

                dataContext.SaveChanges();
            }
        }

    }

}
