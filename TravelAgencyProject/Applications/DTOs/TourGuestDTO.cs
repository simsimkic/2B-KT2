using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Applications.DTOs
{
    public class TourGuestDTO
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsPresent { get; set; }

        public string CheckPointCoordinate { get; set; }

        public TourGuestDTO(string name, int age, bool isPresent)
        {
            Name = name;
            Age = age;
            IsPresent = isPresent;
        }

        public TourGuestDTO(TourGuest tourGuest)
        {
            Name = tourGuest.FirstName + " " + tourGuest.LastName;
            Age = tourGuest.Age;
            IsPresent = false;
            CheckPointCoordinate = "";
        }
    }
}
