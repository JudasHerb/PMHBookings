using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMHBooking.Models
{
    public class Invoices
    {
        public Invoices(List<PMHBooking.Entities.Invoice> invoices)
        {
            InvoiceList = new List<Invoice>();
            foreach (var invoice in invoices)
            {
                InvoiceList.Add(new Invoice
                {
                    BookingId=invoice.Booking.ID,
                    Amount=invoice.Amount,
                    Description=invoice.Desciption,
                    Id=invoice.ID,
                    State=invoice.State,
                    StringAmount = string.Format("{0:C}", invoice.Amount),
                    Date=invoice.Date.ToString("dd/MM/yyyy")
                });
            }
        }
        public List<Invoice> InvoiceList { get; set; }
    }
}