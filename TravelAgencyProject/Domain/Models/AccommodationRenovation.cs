using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyProject.Domain.Model
{
    [Table("AccommodationRenovation")]
    public class AccommodationRenovation
    {
        [Key]
        public int Id { get; set; }

        public int AccommodationId { get; set; }

        [ForeignKey("AccommodationId")]
        public virtual Accommodation Accommodation { get; set; }

        public DateTime StartDate { get; set; }

        public int ExpectedDuration { get; set; }

        public AccommodationRenovation(int id, Accommodation accommodation, DateTime startDate, int expectedDuration)
        {
            Id = id;
            Accommodation = accommodation;
            StartDate = startDate;
            ExpectedDuration = expectedDuration;
        }

        public AccommodationRenovation()
        {
        }

        public bool Equals(int id)
        {
            return Id == id;
        }
    }
}
