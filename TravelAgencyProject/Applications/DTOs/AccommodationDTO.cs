using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Applications.DTOs
{
    public class AccommodationDTO
    {
        public AccommodationDTO() { }

        public string Name { get; set; }
        public Location Location { get; set; }
        public Owner Owner { get; set; }
        public string OwnerStatus { get; set; }

        public AccommodationDTO(string name, Location location, Owner owner)
        {
            Location = location;
            Name = name;
            Owner = owner;
            OwnerStatus = Owner.Status.Equals(Status.Super) ? "*" : "";
        }
    }
}
