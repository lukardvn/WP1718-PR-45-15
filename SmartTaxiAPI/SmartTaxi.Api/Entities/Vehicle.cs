namespace SmartTaxi.Api.Entities
{
    public class Vehicle
    {
        public long Id { get; set; }
        public int Year { get; set; }
        public string RegistrationNumber { get; set; }
        public int TaxiNumber { get; set; }
        public VehicleType VehicleType { get; set; }
        public string CreatedBy { get; set; }
    }
}