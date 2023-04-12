using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Applications.DTOs
{
    public class TourStatisticsDTO
    {
        public string Name { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        public int GuestNumber { get; set; }

        public List<string> Images { get; set; }

        public TourStatisticsDTO(TourArrangement tourArrangement)
        {
            Name = tourArrangement.Tour.Name;
            State = tourArrangement.Tour.Location.State;
            City = tourArrangement.Tour.Location.City;
            Description = tourArrangement.Tour.Description;
            Language = tourArrangement.Tour.Language;
            GuestNumber = tourArrangement.GuestsNumber;
            Images = tourArrangement.Tour.Images.Split(' ').ToList();
        }
    }
}
