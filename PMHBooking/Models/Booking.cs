using PMHBooking.Entities;
using PMHBooking.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMHBooking.Models
{
    public class Booking
    {
        public Booking()
        {
            Repeats = new List<SelectListItem>();
            var values = Enum.GetValues(typeof(RepeatType));
            foreach(var value in values)
            {
                Repeats.Add(new SelectListItem { Text = value.ToString(), Value = value.ToString() });
            }
            StartHour = "9";
            StartMinute = "0";
            EndHour = "17";
            EndMinute = "0";
        }
        [Required]
        [Display(Name = "Purpose of booking")]
        public string Purpose { get; set; }

        [Required]
        [Display(Name = "Date of booking")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Start Time (Hrs) field is required")]
        [Display(Name = "Start Time")]
        public string StartHour{ get; set; }
        [Required]
        [Display(Name = "Start Time (Mins)")]
        public string StartMinute { get; set; }

        [Required(ErrorMessage="End Time (Hrs) field is required")]
        [Display(Name = "End Time")]
        public string EndHour { get; set; }
        [Required]
        [Display(Name = "End Minute (Mins)")]
        public string EndMinute { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ContactName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string ContactAddress { get; set; }

        [AtLeastOneRequired("ContactPhone","ContactEmail",ErrorMessage="At least Phone or Email is required.")]
        [Phone]
        [Display(Name = "Phone")]
        public string ContactPhone { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string ContactEmail { get; set; }

        [Required]
        [Display(Name = "Repeat")]
        public string SelectedRepeat { get; set; }
        public List<SelectListItem> Repeats { get; set; }

    }
}