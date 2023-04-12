using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{
    [Table("Voucher")]
    public class Voucher
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        public int GuestId { get; set; }

        [ForeignKey("GuestId")]
        public virtual TourGuest TourGuest { get; set; }

        public int TourId { get; set; }

        [ForeignKey("TourId")]
        public virtual TourArrangement TourArrangement { get; set; }

        public Voucher()
        {
        }

        public Voucher(string name, DateTime expirationDate, int guestId, int tourId)
        {
            Name = name;
            ExpirationDate = expirationDate;
            GuestId = guestId;
            TourId = tourId;
        }
    }
}
