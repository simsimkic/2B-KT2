using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{
    [Table("ForumGuestComment")]
    public class ForumGuestComment

    {
        [Key]
        public int Id { get; set; }
        public int AccommodationGuestId { get; set; }
        [ForeignKey("AccommodationGuestId")]
        public virtual AccommodationGuest AccommodationGuest { get; set; }
        public string Content { get; set; }

        public int ReportNumber { get; set; }

        public ForumGuestComment(int id, AccommodationGuest accommodationGuest, string content, int reportNumber)
        {
            Id = id;
            AccommodationGuest = accommodationGuest;
            Content = content;
            ReportNumber = reportNumber;
        }

        public ForumGuestComment()
        {
        }
    }
}
