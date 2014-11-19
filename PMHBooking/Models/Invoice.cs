using PMHBooking.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMHBooking.Models
{
    public class Invoice
    {

        [Required]
        public int BookingId { get; set; }
        
        public int Id { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public string StringAmount { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "State")]
        public InvoiceState State { get; set; }

        [Required]
        [Display(Name = "Date")]
        public InvoiceState Date { get; set; }

    }
}