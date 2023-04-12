using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{

    [Table("AccommodationGuest")]
    public class AccommodationGuest : User

    {
        public int Credits { get; set; }
        public AccommodationGuest() { }
        public AccommodationGuest(string username, string password, string firstName, string lastName, Gender gender, UserType userType, DateTime birthDate, int age)
        {

            Username = username;
            Password = password;
            Gender = gender;
            FirstName = firstName;
            LastName = lastName;
            Type = UserType.AccommodationGuest;
            BirthDate = birthDate;
            Age = age;
            Credits = 0;
            Status = Status.Regular;
        }

        public AccommodationGuest(User user)
        {
            Username = user.Username;
            Password = user.Password;
            Gender = user.Gender;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Type = user.Type;
            BirthDate = user.BirthDate;
            Age = user.Age;
            Credits = 0;
            Status = Status.Regular;

        }
    }
}
