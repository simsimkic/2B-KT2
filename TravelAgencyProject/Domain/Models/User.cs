using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace TravelAgencyProject.Domain.Model
{

    [Table("User")]
    public class User
    {
        public User()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [EnumDataType(typeof(UserType))]
        [Required]
        public UserType Type { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        [EnumDataType(typeof(Status))]
        [Required]
        public Status Status { get; set; }

        public User(int id, string username, string password, string firstName, string lastName, Gender gender, UserType userType, DateTime birthDate, int age, Status status)
        {
            Id = id;
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Type = userType;
            BirthDate = birthDate;
            Age = age;
            Status = status;
        }


        public bool EqualsUsername(string username)
        {
            return Username == username;
        }

        public bool EqualsPassword(string password)
        {
            return Password == password;
        }
        public string PrintInfo
        {
            get
            {
                return $"{Id} {Username} {FirstName} {LastName} {Gender} {Type} {BirthDate} {Age}";
            }
        }
    }
}