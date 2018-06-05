using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartTaxi.Web.Domain;

namespace SmartTaxi.Web.Models.ViewModels
{
    public class FinalizeBookingViewModel
    {
        public int BookingStatus { get; set; }

        public Location DropOffLocation { get; set; }
        public decimal Amount { get; set; }
        public string CancelReasonDescription { get; set; }
    }
}