using SmartTaxi.Web.Domain.Enums;
using System;
using SmartTaxi.Web.Models;

namespace SmartTaxi.Web.Domain
{
    public class Booking
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public VehicleType VehicleType { get; set; }
        public long? CommentId { get; set; }
        public BookingStatus Status { get; set; }
        public Location PickUpLocation { get; set; }
        public Location DropOffLocation { get; set; }
        public virtual Comment Comment { get; set; }
    }
}