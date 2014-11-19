using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMHBooking.Entities
{
    public enum InvoiceState
    {
        Generated,
        Sent,
        Paid
    }
    public class Invoice
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public virtual Booking Booking { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public InvoiceState State { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Desciption{ get; set; }
    }
}