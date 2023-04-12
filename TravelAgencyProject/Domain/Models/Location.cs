using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{
    [Table("Location")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Location(string city, string state)
        {
            City = city;
            State = state;
        }
        public Location() { }


        public string PrintInfo => $"{City} {State}";

        public bool Equals(int id)
        {
            return Id == id;
        }

        public bool EqualsByCity(string city)
        {
            return City == city;
        }
    }
}
