using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{
    [Table("OwnerReviews")]
    public class OwnerReview
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Cleanness { get; set; }

        public int OwnerFairness { get; set; }

        public string Comment { get; set; }

        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual Owner Owner { get; set; }

        public int AccommodationId { get; set; }

        [ForeignKey("AccommodationId")]
        public virtual Accommodation Accommodation { get; set; }

        public int AccommodationGuestId { get; set; }
        [ForeignKey("AccommodationGuestId")]
        public virtual AccommodationGuest AccommodationGuest { get; set; }

        public string Images { get; set; }

        public OwnerReview()
        {

        }

        public OwnerReview(int cleanness, int ownerFairness, string comment, int ownerId, int accommodationId, int accommodationGuestId, string images)
        {
            // dodati validacije
            Cleanness = cleanness;
            OwnerFairness = ownerFairness;
            Comment = comment;
            OwnerId = ownerId;
            AccommodationId = accommodationId;
            AccommodationGuestId = accommodationGuestId;
            Images = images;

        }

        public OwnerReview(int id, int cleanness, int ownerFairness, string comment, int ownerId, int accommodationId, int accommodationGuestId, string images)
        {
            // dodati validacije
            Id = id;
            Cleanness = cleanness;
            OwnerFairness = ownerFairness;
            Comment = comment;
            OwnerId = ownerId;
            AccommodationId = accommodationId;
            AccommodationGuestId = accommodationGuestId;
            Images = images;
        }




    }
}
