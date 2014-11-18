using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMHBooking.Entities
{
    public enum RepeatType
    {
        None,
        Daily,
        Weekly,
        Monthly
    }
    public class Repeat
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public RepeatType Type { get; set; }
        [Required]
        public int Reccurences { get; set; }

        public virtual Booking Booking { get; set; }
    }
}