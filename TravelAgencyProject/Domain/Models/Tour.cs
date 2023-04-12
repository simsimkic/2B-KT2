using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.DTOs;

namespace TravelAgencyProject.Domain.Model
{
    [Table("Tour")]
    public class Tour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        public int MaxGuestNumber { get; set; }

        public virtual ICollection<CheckPoint> CheckPoints { get; set; }

        public DateTime DateTime { get; set; }

        public int Duration { get; set; }

        public string Images { get; set; }

        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        public Tour(int id, string name, string description, string language, int maxGuestNumber, ICollection<CheckPoint> checkPoints, DateTime tourDate, int duration, Location location)
        {
            Id = id;
            Name = name;
            Description = description;
            Language = language;
            MaxGuestNumber = maxGuestNumber;
            CheckPoints = checkPoints;
            DateTime = tourDate;
            Duration = duration;
            Location = location;
        }

        public Tour(int id, string name, string description, string language, int maxGuestNumber, int duration, int locationId)
        {
            Id = id;
            Name = name;
            Description = description;
            Language = language;
            MaxGuestNumber = maxGuestNumber;
            Duration = duration;
            LocationId = locationId;
        }

        public Tour() { }

        public override bool Equals(object? obj)
        {
            return obj is Tour tour &&
                   Id == tour.Id;
        }

        public bool Equals(int id)
        {
            return Id == id;
        }
    }
}
