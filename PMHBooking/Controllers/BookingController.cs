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
        // GET: Booking
        public ActionResult Booking(string selectedDate)
        {
            DateTime date = DateTime.Parse(selectedDate.Substring(0,24), CultureInfo.InvariantCulture);

            return PartialView("_Booking", new Booking() { Date = date.ToString("dd/MM/yyyy") });
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
        public ActionResult Events(string startDate, string endDate)
        {
            var events = new List<Event>
            {
                new Event{title = "Poo", start = "2014-11-01T12:00:00", end = "2014-11-01T13:00:00"}
            };
            return Json(events,JsonRequestBehavior.AllowGet);
        }
    }
    public class Event
    {
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }
}