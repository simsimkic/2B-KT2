using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace TravelAgencyProject.Domain.Model
{
    [Table("Accommodation")]
    public class Accommodation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        [EnumDataType(typeof(AccommodationType))]
        [Required]
        public AccommodationType Type { get; set; }
        public int MaxGuestNumber { get; set; }
        public int MinDayNumber { get; set; }
        public int MinCancelationDays { get; set; }
        public string Images { get; set; }

        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual Owner Owner { get; set; }


        public Accommodation(string name, Location location, AccommodationType type, int maxGuestNumber, int minDayNumber, int minCancelationDays, string images, Owner owner)
        {
            Name = name;
            Location = location;
            Type = type;
            MaxGuestNumber = maxGuestNumber;
            MinDayNumber = minDayNumber;
            MinCancelationDays = minCancelationDays;
            Images = images;
            Owner = owner;
        }

        public Accommodation(string name, Location location, AccommodationType type, int maxGuestNumber, int minDayNumber, int minCancelationDays, string images, int ownerId)
        {
            Name = name;
            Location = location;
            Type = type;
            MaxGuestNumber = maxGuestNumber;
            MinDayNumber = minDayNumber;
            MinCancelationDays = minCancelationDays;
            Images = images;
            OwnerId = ownerId;
        }

        public Accommodation(string name, int locationId, AccommodationType type, int maxGuestNumber, int minDayNumber, int minCancelationDays, string images, Owner owner)
        {
            Name = name;
            LocationId = locationId;
            Type = type;
            MaxGuestNumber = maxGuestNumber;
            MinDayNumber = minDayNumber;
            MinCancelationDays = minCancelationDays;
            Images = images;
            Owner = owner;
        }

        public Accommodation(string name, int locationId, AccommodationType type, int maxGuestNumber, int minDayNumber, int minCancelationDays, string images, int ownerId)
        {
            Name = name;
            LocationId = locationId;
            Type = type;
            MaxGuestNumber = maxGuestNumber;
            MinDayNumber = minDayNumber;
            MinCancelationDays = minCancelationDays;
            Images = images;
            OwnerId = ownerId;
        }

        public Accommodation() { }

        public string PrintInfo()
        {
            return $"{Name} {Location.PrintInfo} {Type.ToString()} {MaxGuestNumber} {MinDayNumber} {MinCancelationDays}";
        }

        public bool Equals(int id)
        {
            return Id == id;
        }

    }
}