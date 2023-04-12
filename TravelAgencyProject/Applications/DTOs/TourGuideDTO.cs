using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Applications.DTOs
{
    public class TourGuideDTO
    {
        public string Username { get; set; }

        public string FullName { get; set; }

        public string DateOfBirth { get; set; }

        public int Age { get; set; }

        public TourGuideDTO(User user)
        {
            Username = user.Username;
            FullName = user.FirstName + " " + user.LastName;
            DateOfBirth = user.BirthDate.ToString("dd/MM/yyyy");
            Age = user.Age;
        }
    }
}
