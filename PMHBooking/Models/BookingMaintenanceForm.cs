using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMHBooking.Models
{
    public class BookingMaintenanceForm
    {
        public BookingMaintenanceForm(PMHBooking.Entities.Booking booking)
        {
            Booking = new Booking(booking);
            Invoices = new Invoices(booking.Invoices.ToList());
        }
        public Booking Booking { get; set; }
        public Invoices Invoices { get; set; }
    }
}