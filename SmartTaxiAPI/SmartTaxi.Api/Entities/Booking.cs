using System;

namespace SmartTaxi.Api.Entities
{
    public class Booking
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? PickUpLocationId { get; set; }
        public long? DropOffLOcationId { get; set; }
        public decimal? Amount { get; set; }
        public string DispatcherId { get; set; }
        public string DriverId { get; set; }
        public string CustomerId { get; set; }
        public long? CommentId { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public virtual Location PickUpLocation { get; set; }
        public virtual Location DropOffLocation { get; set; }
        public virtual Comment Comment { get; set; }
    }
}