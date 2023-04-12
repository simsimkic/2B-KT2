using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{

    [Table("TourGuest")]
    public class TourGuest : User
    {

        public virtual ICollection<Voucher> Vouchers { get; set; }
        public TourGuest() { }

        public TourGuest(int id, string username, string password, string firstName, string lastName, Gender gender, UserType userType, DateTime birthDate, int age, Status status) : base(id, username, password, firstName, lastName, gender, userType, birthDate, age, status)
        {
            Username = username;
            Password = password;
            Gender = gender;
            FirstName = firstName;
            LastName = lastName;
            Type = UserType.TourGuest;
            BirthDate = birthDate;
            Age = age;

        }
    }
}
