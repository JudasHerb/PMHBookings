using PMHBooking.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMHBooking.Controllers
{
    public class BookingController : Controller
    {
        // GET: BookingForm
        public ActionResult BookingForm(string selectedDate)
        {
            DateTime date = DateTime.Parse(selectedDate.Substring(0,24), CultureInfo.InvariantCulture);

            return PartialView("_Booking", new Booking() { Date = date.ToString("dd/MM/yyyy") });
        }
        public ActionResult Booking(int id)
        {

            return PartialView("_BookingView",
                new Booking(new PMHBooking.Entities.Booking
                {
                    ID = 1,
                    From = DateTime.Now,
                    To = DateTime.Now,
                    Purpose="Wedding Reception",
                    Description="A wedding reception for 100 guests. DJ required.",
                    Contact = new Entities.Contact { Name = "Bob", Address="14 Craignair Avenue. BN18UH", Email="Lucy@Lou.com" },
                    Repeat = new Entities.Repeat { Type = Entities.RepeatType.Monthly }
                }));
        }
        public ActionResult BookingMaintenanceForm(int id)
        {
            return View(new BookingMaintenanceForm(new PMHBooking.Entities.Booking
                {
                    ID = 1,
                    From = DateTime.Now,
                    To = DateTime.Now,
                    Purpose = "Wedding Reception",
                    Description = "A wedding reception for 100 guests. DJ required.",
                    Contact = new Entities.Contact { Name = "Bob", Address = "14 Craignair Avenue. BN18UH", Email = "Lucy@Lou.com" },
                    Repeat = new Entities.Repeat { Type = Entities.RepeatType.Monthly },
                    Invoices = new List<PMHBooking.Entities.Invoice> 
                        { 
                            new PMHBooking.Entities.Invoice {Booking = new Entities.Booking{ID=1},Date=DateTime.Now.AddMonths(-1), Amount = 100, State = Entities.InvoiceState.Paid, ID=1,Desciption="Deposit" }, 
                            new PMHBooking.Entities.Invoice {Booking = new Entities.Booking{ID=1},Date=DateTime.Now.AddMonths(-1), Amount = 200, State = Entities.InvoiceState.Sent, ID=2,Desciption="Remaining Balanace" } 
                        }
                }));
        }
        [HttpPost]
        [ActionName("Booking")]
        public ActionResult BookingPost(Booking booking)
        {
            if(ModelState.IsValid)
            {
                return Json("ReFetch");
            }
            return PartialView("_Booking", booking);
        }
        public ActionResult CalendarEvents(string startDate, string endDate)
        {
            var events = new List<CalendarEvent>
            {
                new CalendarEvent{id="1",title = "Wedding", start = "2014-11-01T13:00:00", end = "2014-11-01T17:00:00"}
            };
            return Json(events,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Tasks()
        {
            var events = new List<Tasks>
            {
                new Tasks{BookingId=1,Header="20/11/2014 - Await Payment - EarthKids", Description="Earth Kids... Contact: J. Little" },
                new Tasks{BookingId=1,Header="30/11/2014 - Submitted - Barn Dance", Description="Some one else... Contact: Jo Jangles"},
                new Tasks{BookingId=1,Header="01/01/2015 - Invoice - Reception", Description="Wedding.... Contact: Lucy Lou"}
            };
            return Json(events, JsonRequestBehavior.AllowGet);
        }
    }
    public class Tasks
    {
        public int BookingId { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
    }
    public class CalendarEvent
    {
        public string id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }
}