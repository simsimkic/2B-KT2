using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject.Domain.Model
{
    [Table("Forum")]
    public class Forum
    {
        [Key]
        public int Id { get; set; }
        public string GuestComments { get; set; }

        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        public bool isActive { get; set; }

        public string OwnerComments { get; set; }

        public Forum(int id, string guestComments, Location location, bool isActive, string ownerComments)
        {
            Id = id;
            GuestComments = guestComments;
            Location = location;
            this.isActive = isActive;
            OwnerComments = ownerComments;
        }

        public Forum()
        {
        }
    }
}
