using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Domain.Interfaces.Services
{
    public interface ITourArrangementCreationService
    {
        public int CreateArrangement(TourReservationDTO tourReservationDTO);

        public bool IsAvailable(int tourId, int tourGuestsNumber);

        public bool IsUserAlreadyAssigned(int tourGuestId, int tourId);
    }
}
