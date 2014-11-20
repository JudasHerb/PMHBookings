using PMHBooking.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMHBooking.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult InvoiceForm(int bookingId)
        {
            
            return PartialView("_Invoice", new Invoice() { BookingId=bookingId});
        }
        [HttpPost]
        [ActionName("Invoice")]
        public ActionResult InvoicePost(Invoice booking)
        {
            booking.State=Entities.InvoiceState.Generated;            

            decimal amount;
            if (decimal.TryParse(booking.StringAmount.Replace("£","").Replace(",",""),out amount))
            {
                booking.Amount = amount;
            }

            if (ModelState.IsValid)
            {
                return Json(true);
            }
            return PartialView("_Invoice", booking);
        }
        public ActionResult Invoice(int id)
        {
            return PartialView("_InvoiceManage", new Invoice {StringAmount="£100.00",Description="Studd" });
        }
        //public ActionResult Invoices(int bookingId)
        //{
        //    return PartialView("_Invoices", new Invoices(new List<PMHBooking.Entities.Invoice> 
        //    { 
        //        new PMHBooking.Entities.Invoice { Amount = 100, State = Entities.InvoiceState.Sent }, 
        //        new PMHBooking.Entities.Invoice { Amount = 200, State = Entities.InvoiceState.Paid } 
        //    }));
        //}
    }
}