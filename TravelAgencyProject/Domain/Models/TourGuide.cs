using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{
    [Table("TourGuide")]
    public class TourGuide : User
    {
        public virtual ICollection<TourArrangement> GuidedTours { get; set; }
        public TourGuide(int id, string username, string password, string firstName, string lastName, Gender gender, UserType userType, DateTime birthDate, int age, Status status) : base(id, username, password, firstName, lastName, gender, userType, birthDate, age, status)
        {
            GuidedTours = new List<TourArrangement>();
            Status = Status.Regular;
        }
        public TourGuide() { }
    }
}
