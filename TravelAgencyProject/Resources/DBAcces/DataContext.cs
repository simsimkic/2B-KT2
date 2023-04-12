using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Proxies;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;
using Castle.Core.Resource;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Resources.Database;

namespace TravelAgencyProject.Resources.DBAcces
{
    public class DataContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourGuide> TourGuide { get; set; }
        public DbSet<CheckPoint> CheckPoints { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<AccommodationRenovation> AccommodationRenovations { get; set; }
        public DbSet<AccommodationReservation> AccommodationReservations { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<ForumGuestComment> ForumGuestComments { get; set; }
        public DbSet<YearlyAccommodationStatistic> YearlyAccommodationStatistics { get; set; }
        public DbSet<MonthlyAccommodationStatistics> MonthlyAccommodationStatistics { get; set; }
        public DbSet<TourGuest> TourGuest { get; set; }
        public DbSet<TourArrangement> TourArrangements { get; set; }
        public DbSet<TourAttendance> TourAttendances { get; set; }
        public DbSet<RescheduleReservationRequest> RescheduleReservationRequests { get; set; }
        public DbSet<TourGuideReview> TourGuideReviews { get; set; }
        public DbSet<AccommodationGuestReview> AccommodationGuestReviews { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<OwnerReview> OwnerReviews { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(GlobalConfig.CnnVal("sims.db"));
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedAccomodationGuest(modelBuilder);

            SeedOwner(modelBuilder);

            SeedTourGuide(modelBuilder);

            SeedLocation(modelBuilder);

            SeedAccomodation(modelBuilder);

            SeedAccomodationReservation(modelBuilder);

            SeedTourGuest(modelBuilder);

            SeedTour(modelBuilder);

            SeedCheckPoint(modelBuilder);

            SeedTourArrangement(modelBuilder);

            RescheduleReservationRequest(modelBuilder);

            SeedTourAttendance(modelBuilder);

            SeedTourGuideReview(modelBuilder);

            SeedVoucher(modelBuilder);

            SeedOwnerReview(modelBuilder);

            SeedAccommodationGuestReview(modelBuilder);
        }



        private static void SeedTourAttendance(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TourAttendance>()
                            .HasKey(ta => new { ta.TourArrangementId, ta.GuestId });
            modelBuilder.Entity<TourAttendance>().HasData(
                new TourAttendance
                {
                    GuestId = 600,
                    IsPresent = false,
                    IsConfirmed = false,
                    TourArrangementId = 1,
                    CheckPointCoordinate = ""

                },
                new TourAttendance
                {
                    GuestId = 601,
                    IsPresent = false,
                    IsConfirmed = false,
                    TourArrangementId = 1,
                    CheckPointCoordinate = ""
                },
                new TourAttendance
                {
                    GuestId = 602,
                    IsPresent = false,
                    IsConfirmed = false,
                    TourArrangementId = 1,
                    CheckPointCoordinate = ""
                },
                new TourAttendance
                {
                    GuestId = 600,
                    IsPresent = true,
                    IsConfirmed = false,
                    TourArrangementId = 5,
                    CheckPointCoordinate = ""
                },
                new TourAttendance
                {
                    GuestId = 601,
                    IsPresent = false,
                    IsConfirmed = false,
                    TourArrangementId = 5,
                    CheckPointCoordinate = ""
                },
                new TourAttendance
                {
                    GuestId = 603,
                    IsPresent = false,
                    TourArrangementId = 1,
                    CheckPointCoordinate = ""
                },
                new TourAttendance
                {
                    GuestId = 604,
                    IsPresent = false,
                    TourArrangementId = 5,
                    CheckPointCoordinate = ""
                });
            modelBuilder.Entity<TourAttendance>().ToTable("TourAttendance");
        }

        private static void SeedTourArrangement(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TourArrangement>().HasData(
                           new TourArrangement
                           {
                               Id = 1,
                               TourId = 1,
                               GuestsNumber = 10,
                               State = TourState.None,
                               TourGuideId = 5
                           },
                           new TourArrangement
                           {
                               Id = 2,
                               TourId = 2,
                               GuestsNumber = 5,
                               State = TourState.None,
                               TourGuideId = 5
                           },
                           new TourArrangement
                           {
                               Id = 3,
                               TourId = 3,
                               GuestsNumber = 5,
                               State = TourState.None,
                               TourGuideId = 5
                           },
                           new TourArrangement
                           {
                               Id = 4,
                               TourId = 4,
                               GuestsNumber = 15,
                               State = TourState.None,
                               TourGuideId = 5
                           },
                           new TourArrangement
                           {
                               Id = 5,
                               TourId = 5,
                               GuestsNumber = 30,
                               State = TourState.Finished,
                               TourGuideId = 5
                           });
            modelBuilder.Entity<TourArrangement>().ToTable("TourArrangement");
        }



        private static void SeedCheckPoint(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckPoint>().HasKey(e => e.Id);
            modelBuilder.Entity<CheckPoint>().HasData(
                 new CheckPoint
                 {
                     Id = 1,
                     Coordinates = "12N 21W",
                     Type = CheckPointType.Start,
                     IsTagged = false,
                     TourId = 1
                 },
                 new CheckPoint
                 {
                     Id = 2,
                     Coordinates = "15N 788W",
                     Type = CheckPointType.Start,
                     IsTagged = false,
                     TourId = 2
                 },
                 new CheckPoint
                 {
                     Id = 3,
                     Coordinates = "81N 11W",
                     Type = CheckPointType.Start,
                     IsTagged = false,
                     TourId = 3
                 },
                 new CheckPoint
                 {
                     Id = 4,
                     Coordinates = "122N 211W",
                     Type = CheckPointType.End,
                     IsTagged = false,
                     TourId = 1
                 },
                 new CheckPoint
                 {
                     Id = 5,
                     Coordinates = "514N 787W",
                     Type = CheckPointType.End,
                     IsTagged = false,
                     TourId = 2
                 },
                 new CheckPoint
                 {
                     Id = 6,
                     Coordinates = "841N 191W",
                     Type = CheckPointType.End,
                     IsTagged = false,
                     TourId = 3
                 },
                 new CheckPoint
                 {
                     Id = 7,
                     Coordinates = "300.5N 191W",
                     Type = CheckPointType.Start,
                     IsTagged = true,
                     TourId = 4
                 },
                 new CheckPoint
                 {
                     Id = 8,
                     Coordinates = "841N 191W",
                     Type = CheckPointType.Other,
                     IsTagged = false,
                     TourId = 4
                 },
                 new CheckPoint
                 {
                     Id = 9,
                     Coordinates = "500N 191W",
                     Type = CheckPointType.End,
                     IsTagged = false,
                     TourId = 4
                 }

            );
            modelBuilder.Entity<CheckPoint>().ToTable("CheckPoint");
        }

        private static void SeedTour(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tour>().HasKey(e => e.Id);
            modelBuilder.Entity<Tour>().HasData(
                 new Tour
                 {
                     Id = 1,
                     Name = "Majska tura",
                     Description = "Poseta muzejima",
                     DateTime = DateTime.Today,
                     Language = "Srpski",
                     MaxGuestNumber = 20,
                     Duration = 7,
                     Images = "https://aqualab.rs/aqlab_new/wp-content/uploads/2022/06/Vrnjacka_Banja.jpg https://www.srbijapodlupom.com/wp-content/uploads/2021/02/20200721191257_611778.jpg",
                     LocationId = 1

                 },
                 new Tour
                 {
                     Id = 2,
                     Name = "Put u Beč",
                     Description = "Obilazak zamkova",
                     DateTime = DateTime.ParseExact("29-04-2023 13:00:00", "dd-MM-yyyy HH:mm:ss", null),
                     Language = "Nemački",
                     MaxGuestNumber = 20,
                     Duration = 48,
                     Images = "https://historiceuropeancastles.com/wp-content/uploads/2019/12/Scho%CC%88nbrunn-Palace-1024x683.jpg",
                     LocationId = 2
                 },
                 new Tour
                 {
                     Id = 3,
                     Name = "Milano tura",
                     Description = "Obilazak Duomo di Milano",
                     DateTime = DateTime.ParseExact("29-04-2023 13:00:00", "dd-MM-yyyy HH:mm:ss", null),
                     Language = "Italijanski",
                     MaxGuestNumber = 30,
                     Duration = 72,
                     Images = "https://en.wikiarquitectura.com/wp-content/uploads/2017/01/Duomo_de_Milano_-_Foto_entorno_2-1024x768.jpg",
                     LocationId = 3
                 },
                 new Tour
                 {
                     Id = 4,
                     Name = "London Tour",
                     Description = "Big Ben",
                     DateTime = DateTime.ParseExact("21-04-2024 13:00:00", "dd-MM-yyyy HH:mm:ss", null),
                     Language = "English",
                     MaxGuestNumber = 20,
                     Duration = 3,
                     Images = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/0d/63/f8/bb/big-ben.jpg?w=1200&h=1200&s=1&pcx=1033&pcy=310&pchk=v1_bf93e1170e1f1f8d4cea",
                     LocationId = 4
                 },
                 new Tour
                 {
                     Id = 5,
                     Name = "Paris Tour",
                     Description = "Eiffel tower, Notre Dame tour",
                     DateTime = DateTime.ParseExact("13-06-2024 13:00:00", "dd-MM-yyyy HH:mm:ss", null),
                     Language = "English",
                     MaxGuestNumber = 20,
                     Duration = 72,
                     Images = "https://upload.wikimedia.org/wikipedia/commons/4/4b/La_Tour_Eiffel_vue_de_la_Tour_Saint-Jacques%2C_Paris_ao%C3%BBt_2014_%282%29.jpg",
                     LocationId = 5
                 }
            );
            modelBuilder.Entity<Tour>().ToTable("Tour");
        }

        private static void SeedTourGuest(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            //TourGuest
            modelBuilder.Entity<TourGuest>().HasData(
                new TourGuest
                {
                    Id = 600,
                    FirstName = "Imenko",
                    LastName = "Prezimenic",
                    Username = "imenko",
                    Password = "imenko",
                    Gender = Gender.Male,
                    Type = UserType.TourGuest,
                    BirthDate = DateTime.ParseExact("21-01-2001 21:00:00", "dd-MM-yyyy HH:mm:ss", null),
                    Age = 21
                },
                 new TourGuest
                 {
                     Id = 601,
                     FirstName = "Milena",
                     LastName = "Milenic",
                     Username = "milena",
                     Password = "milena",
                     Gender = Gender.Female,
                     Type = UserType.TourGuest,
                     BirthDate = DateTime.ParseExact("21-01-2001 21:00:00", "dd-MM-yyyy HH:mm:ss", null),
                     Age = 21

                 },
                 new TourGuest
                 {
                     Id = 602,
                     FirstName = "Aleksandar",
                     LastName = "Aleksandrovic",
                     Username = "aca",
                     Password = "aca",
                     Gender = Gender.Male,
                     Type = UserType.TourGuest,
                     BirthDate = DateTime.ParseExact("21-01-2001 21:00:00", "dd-MM-yyyy HH:mm:ss", null),
                     Age = 21
                 },
                 new TourGuest
                 {
                     Id = 603,
                     FirstName = "Miha",
                     LastName = "Mihic",
                     Username = "miha",
                     Password = "miha",
                     Gender = Gender.Male,
                     Type = UserType.TourGuest,
                     BirthDate = DateTime.ParseExact("21-01-1972 21:00:00", "dd-MM-yyyy HH:mm:ss", null),
                     Age = 51
                 },
                 new TourGuest
                 {
                     Id = 604,
                     FirstName = "Dositej",
                     LastName = "Obradovic",
                     Username = "dositej69420",
                     Password = "dositej",
                     Gender = Gender.Female,
                     Type = UserType.TourGuest,
                     BirthDate = DateTime.ParseExact("21-01-2007 21:00:00", "dd-MM-yyyy HH:mm:ss", null),
                     Age = 16
                 }
            );
            modelBuilder.Entity<TourGuest>().ToTable("TourGuest");
        }

        private static void SeedAccomodationReservation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccommodationReservation>().HasKey(e => e.Id);
            //Accommodation reservation
            modelBuilder.Entity<AccommodationReservation>().HasData(
                new AccommodationReservation
                {
                    Id = 1,
                    AccommodationGuestId = 1,
                    Date = DateTime.ParseExact("02-05-2023 17:16:15", "dd-MM-yyyy HH:mm:ss", null),
                    AccommodationId = 1,
                    GuestsNumber = 1,
                    ReservedDayNumber = 3,
                    Status = AccommodationReservationStatus.Active

                }, new AccommodationReservation
                {
                    Id = 2,
                    AccommodationGuestId = 1,
                    Date = DateTime.ParseExact("04-04-2023 14:13:11", "dd-MM-yyyy HH:mm:ss", null),
                    AccommodationId = 2,
                    GuestsNumber = 2,
                    ReservedDayNumber = 4,
                    Status = AccommodationReservationStatus.Rescheduled

                }, new AccommodationReservation
                {
                    Id = 3,
                    AccommodationGuestId = 1,
                    Date = DateTime.ParseExact("10-04-2023 14:13:11", "dd-MM-yyyy HH:mm:ss", null),
                    AccommodationId = 3,
                    GuestsNumber = 2,
                    ReservedDayNumber = 5,
                    Status = AccommodationReservationStatus.Active

                }, new AccommodationReservation
                {
                    Id = 4,
                    AccommodationGuestId = 7,
                    Date = DateTime.ParseExact("30-04-2023 19:17:12", "dd-MM-yyyy HH:mm:ss", null),
                    AccommodationId = 2,
                    GuestsNumber = 4,
                    ReservedDayNumber = 7,
                    Status = AccommodationReservationStatus.Active
                }, new AccommodationReservation
                {
                    Id = 5,
                    AccommodationGuestId = 7,
                    Date = DateTime.ParseExact("30-06-2023 19:17:12", "dd-MM-yyyy HH:mm:ss", null),
                    AccommodationId = 2,
                    GuestsNumber = 4,
                    ReservedDayNumber = 7,
                    Status = AccommodationReservationStatus.Active
                }, new AccommodationReservation
                {
                    Id = 6,
                    AccommodationGuestId = 2,
                    Date = DateTime.ParseExact("22-05-2023 12:19:52", "dd-MM-yyyy HH:mm:ss", null),
                    AccommodationId = 1,
                    GuestsNumber = 3,
                    ReservedDayNumber = 6,
                    Status = AccommodationReservationStatus.Active
                }

            );
            modelBuilder.Entity<AccommodationReservation>().ToTable("AccommodationReservation");
        }

        private static void SeedAccomodation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accommodation>().HasKey(e => e.Id);

            //Accommodation
            modelBuilder.Entity<Accommodation>().HasData(
                     new Accommodation
                     {
                         Id = 1,
                         Name = "Vila Gotiva",
                         //Location = new Location("Vrnjacka banja","Serbia"),
                         LocationId = 1,
                         Type = AccommodationType.House,
                         MaxGuestNumber = 15,
                         MinDayNumber = 1,
                         MinCancelationDays = 7,
                         Images = "https://lh5.googleusercontent.com/p/AF1QipPj5m4UiukpZcUOIRwnMW6RdVt8a6EOQqxPuk_Z=w1440-h810-k-no",
                         OwnerId = 3

                     },
                     new Accommodation
                     {
                         Id = 2,
                         Name = "Spring cottage",
                         //Location = new Location("Vienna", "Austria"),
                         LocationId = 2,
                         Type = AccommodationType.Cottage,
                         MaxGuestNumber = 5,
                         MinDayNumber = 3,
                         MinCancelationDays = 5,
                         Images = "https://lh3.googleusercontent.com/p/AF1QipNi12W91jvcQhOfwL6flwnLE8x67E1vcywNfcGM=w768-h768-n-o-k-v1",
                         OwnerId = 3

                     },
                     new Accommodation
                     {
                         Id = 3,
                         Name = "Mariposa",
                         //Location = new Location("Milan", "Italy"),
                         LocationId = 3,
                         Type = AccommodationType.Apartment,
                         MaxGuestNumber = 6,
                         MinDayNumber = 2,
                         MinCancelationDays = 7,
                         Images = "https://sobeiapartmani.com/wp-content/uploads/2022/03/gotiva-00-800.jpg",
                         OwnerId = 4

                     }, new Accommodation
                     {
                         Id = 4,
                         Name = "Villa Vienna",
                         //Location = new Location("Vienna", "Austria"),
                         LocationId = 2,
                         Type = AccommodationType.House,
                         MaxGuestNumber = 6,
                         MinDayNumber = 2,
                         MinCancelationDays = 6,
                         Images = "https://www.engelvoelkers.com/images/07e43544-9e5f-4571-ae73-7170dc2d6809/modern-villa-project-with-innovative-concept",
                         OwnerId = 3

                     }
                );
            modelBuilder.Entity<Accommodation>().ToTable("Accommodation");
        }

        private static void SeedLocation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasKey(e => e.Id);
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    City = "Vrnjacka banja",
                    State = "Serbia",
                },
                new Location
                {
                    Id = 2,
                    City = "Vienna",
                    State = "Austria",
                },
                new Location
                {
                    Id = 3,
                    City = "Milan",
                    State = "Italy",
                },
                new Location
                {
                    Id = 4,
                    City = "London",
                    State = "England",
                },
                new Location
                {
                    Id = 5,
                    City = "Paris",
                    State = "France"
                }
            );
            modelBuilder.Entity<Location>().ToTable("Location");
        }

        private static void SeedTourGuide(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);

            modelBuilder.Entity<TourGuide>().HasData(
                new TourGuide
                {
                    Id = 5,
                    FirstName = "Matej",
                    LastName = "Mihailovic",
                    Username = "matej",
                    Password = "matej01",
                    Gender = Gender.Male,
                    Type = UserType.TourGuide,
                    BirthDate = DateTime.ParseExact("27-09-2001 19:30:00", "dd-MM-yyyy HH:mm:ss", null),
                    Age = 21,
                    Status = Status.Regular
                },
                 new TourGuide
                 {
                     Id = 6,
                     FirstName = "Mika",
                     LastName = "Mikic",
                     Username = "mika",
                     Password = "mika123",
                     Gender = Gender.Male,
                     Type = UserType.TourGuide,
                     BirthDate = DateTime.ParseExact("21-01-2001 21:00:00", "dd-MM-yyyy HH:mm:ss", null),
                     Age = 21,
                     Status = Status.Regular
                 }
            );

            modelBuilder.Entity<TourGuide>().ToTable("TourGuide");
        }

        private static void SeedOwner(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);

            modelBuilder.Entity<Owner>().HasData(
                            new Owner
                            {
                                Id = 3,
                                FirstName = "Dusan",
                                LastName = "Stojanovic",
                                Username = "dusan01",
                                Password = "dulejelud",
                                Status = Status.Regular,
                                Gender = Gender.Male,
                                Type = UserType.Owner,
                                BirthDate = DateTime.ParseExact("21-12-2001 19:30:00", "dd-MM-yyyy HH:mm:ss", null),
                                Age = 21
                            },
                            new Owner
                            {
                                Id = 4,
                                FirstName = "Mitar",
                                LastName = "Miric",
                                Username = "mira123",
                                Password = "mitar1389",
                                Status = Status.Regular,
                                Gender = Gender.Male,
                                Type = UserType.Owner,
                                BirthDate = DateTime.ParseExact("16-01-1957 11:15:00", "dd-MM-yyyy HH:mm:ss", null),
                                Age = 66
                            }
                        );
            modelBuilder.Entity<Owner>().ToTable("Owner");
        }

        private static void SeedAccomodationGuest(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            //AccommodationGuest
            modelBuilder.Entity<AccommodationGuest>().HasData(
                 new AccommodationGuest
                 {
                     Id = 1,
                     FirstName = "Ana",
                     LastName = "Parovic",
                     Username = "anaparovic",
                     Password = "anavolimilovana",
                     Gender = Gender.Female,
                     Type = UserType.AccommodationGuest,
                     BirthDate = DateTime.ParseExact("13-12-2001 04:40:00", "dd-MM-yyyy HH:mm:ss", null),
                     Age = 21,
                     Status = Status.Regular,
                     Credits = 0
                 },
                new AccommodationGuest
                {
                    Id = 2,
                    FirstName = "Marija",
                    LastName = "Maric",
                    Username = "marijamaric",
                    Password = "marijacarica",
                    Gender = Gender.Female,
                    Type = UserType.AccommodationGuest,
                    BirthDate = DateTime.ParseExact("12-11-1997 04:40:00", "dd-MM-yyyy HH:mm:ss", null),
                    Age = 26,
                    Status = Status.Regular,
                    Credits = 0
                },
                new AccommodationGuest
                {
                    Id = 7,
                    FirstName = "Kevin",
                    LastName = "Punter",
                    Username = "kevin123",
                    Password = "kevin123",
                    Gender = Gender.Male,
                    Type = UserType.AccommodationGuest,
                    BirthDate = DateTime.ParseExact("25-06-1993 08:15:12", "dd-MM-yyyy HH:mm:ss", null),
                    Age = 29,
                    Status = Status.Regular,
                    Credits = 0
                },
                new AccommodationGuest
                {
                    Id = 8,
                    FirstName = "Milan",
                    LastName = "Milanovic",
                    Username = "milan123",
                    Password = "milan123",
                    Gender = Gender.Male,
                    Type = UserType.AccommodationGuest,
                    BirthDate = DateTime.ParseExact("20-11-1987 08:15:12", "dd-MM-yyyy HH:mm:ss", null),
                    Age = 35,
                    Status = Status.Regular,
                    Credits = 0
                }, new AccommodationGuest
                {
                    Id = 9,
                    FirstName = "Jovan",
                    LastName = "Jovanovic",
                    Username = "jovan123",
                    Password = "jovan123",
                    Gender = Gender.Male,
                    Type = UserType.AccommodationGuest,
                    BirthDate = DateTime.ParseExact("02-01-1991 08:15:12", "dd-MM-yyyy HH:mm:ss", null),
                    Age = 33,
                    Status = Status.Regular,
                    Credits = 0
                }

            );
            modelBuilder.Entity<AccommodationGuest>().ToTable("AccommodationGuests");
        }

        private static void RescheduleReservationRequest(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RescheduleReservationRequest>().HasKey(e => e.Id);

            modelBuilder.Entity<RescheduleReservationRequest>().HasData(

                new RescheduleReservationRequest
                {
                    Id = 1,
                    ReservationId = 1,
                    NewDate = DateTime.ParseExact("21-12-2023 19:30:00", "dd-MM-yyyy HH:mm:ss", null),
                    Status = RescheduleReservationStatus.Pending,
                    RejectionSummary = ""

                },
                new RescheduleReservationRequest
                {
                    Id = 2,
                    ReservationId = 2,
                    NewDate = DateTime.ParseExact("14-05-2023 19:30:00", "dd-MM-yyyy HH:mm:ss", null),
                    Status = RescheduleReservationStatus.Denied,
                    RejectionSummary = "The accommodation is already booked"

                },
                 new RescheduleReservationRequest
                 {
                     Id = 3,
                     ReservationId = 2,
                     NewDate = DateTime.ParseExact("13-12-2023 19:30:00", "dd-MM-yyyy HH:mm:ss", null),
                     Status = RescheduleReservationStatus.Approved,
                     RejectionSummary = ""

                 },
                  new RescheduleReservationRequest
                  {
                      Id = 4,
                      ReservationId = 4,
                      NewDate = DateTime.ParseExact("06-10-2023 19:30:00", "dd-MM-yyyy HH:mm:ss", null),
                      Status = RescheduleReservationStatus.Pending,
                      RejectionSummary = ""

                  },
                  new RescheduleReservationRequest
                  {
                      Id = 5,
                      ReservationId = 4,
                      NewDate = DateTime.ParseExact("18-05-2023 19:30:00", "dd-MM-yyyy HH:mm:ss", null),
                      Status = RescheduleReservationStatus.Pending,
                      RejectionSummary = ""

                  },
                  new RescheduleReservationRequest
                  {
                      Id = 6,
                      ReservationId = 4,
                      NewDate = DateTime.ParseExact("10-02-2023 19:30:00", "dd-MM-yyyy HH:mm:ss", null),
                      Status = RescheduleReservationStatus.Pending,
                      RejectionSummary = ""

                  },
                  new RescheduleReservationRequest
                  {
                      Id = 7,
                      ReservationId = 5,
                      NewDate = DateTime.ParseExact("02-07-2023 19:30:00", "dd-MM-yyyy HH:mm:ss", null),
                      Status = RescheduleReservationStatus.Pending,
                      RejectionSummary = ""

                  },
                  new RescheduleReservationRequest
                  {
                      Id = 8,
                      ReservationId = 3,
                      NewDate = DateTime.ParseExact("10-08-2023 19:30:00", "dd-MM-yyyy HH:mm:ss", null),
                      Status = RescheduleReservationStatus.Pending,
                      RejectionSummary = ""

                  },
                  new RescheduleReservationRequest
                  {
                      Id = 9,
                      ReservationId = 1,
                      NewDate = DateTime.ParseExact("18-07-2023 19:30:00", "dd-MM-yyyy HH:mm:ss", null),
                      Status = RescheduleReservationStatus.Pending,
                      RejectionSummary = ""

                  },
                  new RescheduleReservationRequest
                  {
                      Id = 10,
                      ReservationId = 6,
                      NewDate = DateTime.ParseExact("02-07-2023 13:35:00", "dd-MM-yyyy HH:mm:ss", null),
                      Status = RescheduleReservationStatus.Pending,
                      RejectionSummary = ""

                  },
                  new RescheduleReservationRequest
                  {
                      Id = 11,
                      ReservationId = 6,
                      NewDate = DateTime.ParseExact("08-11-2023 11:45:00", "dd-MM-yyyy HH:mm:ss", null),
                      Status = RescheduleReservationStatus.Pending,
                      RejectionSummary = ""

                  }

                );
            modelBuilder.Entity<RescheduleReservationRequest>().ToTable("RescheduleReservationRequest");



        }


        private void SeedTourGuideReview(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TourGuideReview>().HasKey(e => e.Id);

            modelBuilder.Entity<TourGuideReview>().HasData(
                new TourGuideReview
                {
                    Id = 1,
                    Knowledge = 5,
                    Language = 4,
                    Interestingness = 3,
                    Comment = "Everything was perfect",
                    TourArrangementId = 1,
                    GuestId = 600,
                    Images = ""
                },
                new TourGuideReview
                {
                    Id = 2,
                    Knowledge = 3,
                    Language = 3,
                    Interestingness = 3,
                    Comment = "It was ok",
                    TourArrangementId = 1,
                    GuestId = 601,
                    Images = ""
                });
            modelBuilder.Entity<TourGuideReview>().ToTable("TourGuideReview");
        }


        private static void SeedVoucher(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voucher>().HasData(
                 new Voucher
                 {
                     Id = 1,
                     Name = "Voucher XYZ",
                     ExpirationDate = DateTime.Today.AddMonths(6),
                     GuestId = 600,
                     TourId = 1
                 },
                 new Voucher
                 {
                     Id = 2,
                     Name = "Spring Voucher",
                     ExpirationDate = DateTime.Today.AddMonths(6),
                     GuestId = 600,
                     TourId = 4
                 },
                 new Voucher
                 {
                     Id = 3,
                     Name = "Voucher ABC",
                     ExpirationDate = DateTime.Today.AddMonths(6),
                     GuestId = 601,
                     TourId = 1
                 },
                 new Voucher
                 {
                     Id = 4,
                     Name = "Voucher abc",
                     ExpirationDate = DateTime.Today.AddMonths(6),
                     GuestId = 602,
                     TourId = 1
                 },
                 new Voucher
                 {
                     Id = 5,
                     Name = "Voucher winter",
                     ExpirationDate = DateTime.Today.AddMonths(6),
                     GuestId = 602,
                     TourId = 4
                 }
            );
            modelBuilder.Entity<Voucher>().ToTable("Voucher");
        }

        private void SeedOwnerReview(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OwnerReview>().HasKey(o => o.Id);

            modelBuilder.Entity<OwnerReview>().HasData(
                new OwnerReview
                {
                    Id = 1,
                    Cleanness = 5,
                    OwnerFairness = 5,
                    Comment = "Everything was nice",
                    AccommodationId = 1,
                    OwnerId = 3,
                    AccommodationGuestId = 1,
                    Images = "lista urlova"

                }, new OwnerReview
                {
                    Id = 2,
                    Cleanness = 5,
                    OwnerFairness = 4,
                    Comment = "It was ok",
                    AccommodationId = 2,
                    OwnerId = 3,
                    AccommodationGuestId = 2,
                    Images = "slika.jpg"

                }, new OwnerReview
                {
                    Id = 3,
                    Cleanness = 5,
                    OwnerFairness = 4,
                    Comment = "Good job",
                    AccommodationId = 2,
                    OwnerId = 3,
                    AccommodationGuestId = 7,
                    Images = "lista urlovaaa"

                }, new OwnerReview
                {
                    Id = 4,
                    Cleanness = 5,
                    OwnerFairness = 5,
                    Comment = "Perfect",
                    AccommodationId = 2,
                    OwnerId = 3,
                    AccommodationGuestId = 8,
                    Images = "urlovi"

                }, new OwnerReview
                {
                    Id = 5,
                    Cleanness = 3,
                    OwnerFairness = 3,
                    Comment = "It was ok",
                    AccommodationId = 2,
                    OwnerId = 4,
                    AccommodationGuestId = 2,
                    Images = "lista urlova"

                }, new OwnerReview
                {
                    Id = 6,
                    Cleanness = 5,
                    OwnerFairness = 5,
                    Comment = "Nice",
                    AccommodationId = 2,
                    OwnerId = 3,
                    AccommodationGuestId = 9,
                    Images = "lista urlova12345"

                }
                );
            modelBuilder.Entity<OwnerReview>().ToTable("OwnerReviews");
        }

        private void SeedAccommodationGuestReview(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccommodationGuestReview>().HasKey(a => a.Id);

            modelBuilder.Entity<AccommodationGuestReview>().HasData(
                new AccommodationGuestReview
                {
                    Id = 1,
                    Cleanness = 5,
                    ObeyingRules = 3,
                    Comment = "Nicce",
                    OwnerId = 3,
                    AccommodationGuestId = 1

                }, new AccommodationGuestReview
                {
                    Id = 2,
                    Cleanness = 5,
                    ObeyingRules = 3,
                    Comment = "Good",
                    OwnerId = 3,
                    AccommodationGuestId = 2
                }, new AccommodationGuestReview
                {
                    Id = 3,
                    Cleanness = 2,
                    ObeyingRules = 4,
                    Comment = "Poor hygiene",
                    OwnerId = 4,
                    AccommodationGuestId = 2
                });
            modelBuilder.Entity<AccommodationGuestReview>().ToTable("AccommodationGuestReviews");
        }
    }
}
