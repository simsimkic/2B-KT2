using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{
    [Table("TourGuideReview")]
    public class TourGuideReview
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public int Knowledge { get; set; }
        public int Language { get; set; }
        public int Interestingness { get; set; }
        public string Comment { get; set; }
        public string Images { get; set; }
        public int TourArrangementId { get; set; }
        public int GuestId { get; set; }
        [ForeignKey("TourArrangementId, GuestId")]
        public virtual TourAttendance TourAttendance { get; set; }

        public TourGuideReview()
        {
        }

        public TourGuideReview(int knowledge, int language, int interestingness, string comment, string images, int tourArrangementId, int guestId)
        {
            Knowledge = knowledge;
            Language = language;
            Interestingness = interestingness;
            Comment = comment;
            Images = images;
            TourArrangementId = tourArrangementId;
            GuestId = guestId;

        }
    }
}
