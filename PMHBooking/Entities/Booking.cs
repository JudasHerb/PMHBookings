using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMHBooking.Entities
{
    public enum BookingState
    {
        Provisional,
        Confirmed
    }
    public class Booking
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Purpose { get; set; }
        [Required]
        public virtual Contact Contact { get; set; }
        public string Description { get; set; }
        [Required]
        public BookingState State { get; set; }
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
        [Required]
        public Repeat Repeat { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}