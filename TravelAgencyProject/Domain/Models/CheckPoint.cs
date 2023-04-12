using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{
    [Table("CheckPoint")]
    public class CheckPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Coordinates { get; set; }

        [EnumDataType(typeof(CheckPointType))]
        [Required]
        public CheckPointType Type { get; set; }

        public bool IsTagged { get; set; }

        public int TourId { get; set; }

        [ForeignKey("TourId")]
        public virtual Tour Tour { get; set; }

        public CheckPoint(string coordinates, CheckPointType type)
        {
            Coordinates = coordinates;
            Type = type;
            IsTagged = false;
        }
        public CheckPoint() { }

        public bool Equals(int id)
        {
            return Id == id;
        }

        public bool EqualsTourId(int tourId)
        {
            return TourId == tourId;
        }
    }
}
