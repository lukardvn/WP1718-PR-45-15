namespace SmartTaxi.Api.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string CustomerId { get; set; }
        public long BookingId { get; set; }
        public int Rate { get; set; }
    }
}