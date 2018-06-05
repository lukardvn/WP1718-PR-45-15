using SmartTaxi.Web.Domain;
using System.ComponentModel.DataAnnotations;

namespace SmartTaxi.Web.Models.ViewModels
{
    public class CancelBookingViewModel
    {
        public Booking Booking { get; set; }

        [Required(ErrorMessage = "Morate uneti razlog zbog kojeg otkazujete voznju")]
        public string Reason { get; set; }
    }
}