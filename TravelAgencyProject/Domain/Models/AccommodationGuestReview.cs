using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{
    [Table("AccommodationGuestReview")]
    public class AccommodationGuestReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Cleanness { get; set; }

        public int ObeyingRules { get; set; }

        public string Comment { get; set; }

        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual Owner Owner { get; set; }

        public int AccommodationGuestId { get; set; }
        [ForeignKey("AccommodationGuestId")]
        public virtual AccommodationGuest AccommodationGuest { get; set; }

        public AccommodationGuestReview(int cleanness, int obeyingRules, string comment, Owner owner, AccommodationGuest accommodationGuest)
        {
            Cleanness = cleanness;
            ObeyingRules = obeyingRules;
            Comment = comment;
            Owner = owner;
            AccommodationGuest = accommodationGuest;
        }

        public AccommodationGuestReview(int cleanness, int obeyingRules, string comment, int ownerId, int accommodationGuestId)
        {
            Cleanness = cleanness;
            ObeyingRules = obeyingRules;
            Comment = comment;
            OwnerId = ownerId;
            AccommodationGuestId = accommodationGuestId;
        }

        public AccommodationGuestReview(int id, int cleanness, int obeyingRules, string comment, int ownerId, int accommodationGuestId)
        {
            Id = id;
            Cleanness = cleanness;
            ObeyingRules = obeyingRules;
            Comment = comment;
            OwnerId = ownerId;
            AccommodationGuestId = accommodationGuestId;
        }

        public AccommodationGuestReview()
        {
        }
    }
}
