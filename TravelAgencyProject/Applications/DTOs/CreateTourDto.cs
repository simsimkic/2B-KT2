using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Applications.DTOs
{
    public class CreateTourDTO
    {
        public string TourName { get; set; }

        public string CityName { get; set; }

        public string StateName { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        public int MaxGuestNumber { get; set; }

        public List<string> CheckPointCoordinates { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int Duration { get; set; }

        public List<string> ImageUrls { get; set; }

        public CreateTourDTO(string tourName, string cityName, string stateName, string description, string language, int maxGuestNumber, List<string> checkPointCoordinates, string date, string time, int duration, List<string> imageUrls)
        {
            TourName = tourName;
            CityName = cityName;
            StateName = stateName;
            Description = description;
            Language = language;
            MaxGuestNumber = maxGuestNumber;
            CheckPointCoordinates = checkPointCoordinates;
            Date = date;
            Time = time;
            Duration = duration;
            ImageUrls = imageUrls;
        }

        public CreateTourDTO()
        {
            CheckPointCoordinates = new List<string>();
            ImageUrls = new List<string>();
        }
    }
}
